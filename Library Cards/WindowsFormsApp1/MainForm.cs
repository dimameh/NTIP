using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using LibraryCards;
using Newtonsoft.Json;

namespace CardListApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			_cardList = new BindingList<ICard>();
			Icon = new Icon("ico.ico");
			RenameForm();
		}

		/// <summary>
		///     Переименовать форму (Используется при сохранении или открытии файла)
		/// </summary>
		private void RenameForm()
		{
			Text = _currentFileName + " - Library Cards";
		}

		#region Private properties

		/// <summary>
		///     Главный список карточек
		/// </summary>
		private BindingList<ICard> _cardList;

		/// <summary>
		///     Название файла с которым ведется работа
		/// </summary>
		private string _currentFileName = "New card list";

		#endregion

		#region Table methods

		/// <summary>
		///     Возвращает true если указанная карточка уже добавлена, false в обратном случае
		/// </summary>
		private bool IsInTable(ICard newCard)
		{
			foreach (var card in _cardList)
				if (card.BibliographyInfo == newCard.BibliographyInfo)
					return true;

			return false;
		}

		/// <summary>
		///     Удалить указанную карточку из Главного списка
		/// </summary>
		public void RemoveCard(ICard removingCard)
		{
			if (removingCard != null)
			{
				_cardList.Remove(removingCard);
				dataGridView1.DataSource = _cardList;
			}
			else
			{
				MessageBox.Show("No such record at list.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Click events

		#region Form openers

		/// <summary>
		///     Открытие окна с формой добавления новой карточки
		/// </summary>
		private void AddButtonClick(object sender, EventArgs e)
		{
			var newRecordForm = new AddRecordForm();
			newRecordForm.ShowDialog();
			if (newRecordForm.DialogResult == DialogResult.OK)
			{
				if (!IsInTable(newRecordForm.NewCard))
				{
					if (newRecordForm.NewCard != null)
					{
						_cardList.Add(newRecordForm.NewCard);
						dataGridView1.DataSource = _cardList;
					}
					else
					{
						MessageBox.Show("You cant add empty record", "Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("This record is already exist", "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
				}
			}
		}

		/// <summary>
		///     Открытие окна с формой поиска карточек
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			var listCopy = new BindingList<ICard>(_cardList);

			var newSearchForm = new SearchForm(listCopy);
			newSearchForm.ShowDialog();

			if (newSearchForm.DialogResult == DialogResult.None) _cardList = newSearchForm.ResultList;
		}

		#endregion

		#region Save/Open

		/// <summary>
		/// Перегрузка SerializationBinder
		/// </summary>
		public class TypeNameSerializationBinder : SerializationBinder
		{
			public string TypeFormat { get; }

			public TypeNameSerializationBinder(string typeFormat)
			{
				TypeFormat = typeFormat;
			}

			public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
			{
				assemblyName = null;
				typeName = serializedType.Name;
			}

			public override Type BindToType(string assemblyName, string typeName)
			{
				var resolvedTypeName = string.Format(TypeFormat, typeName);
				return Type.GetType(resolvedTypeName, true);
			}
		}

		/// <summary>
		///     Окно сохранения данных таблицы
		/// </summary>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//настройка окна сохранения файла
			saveFileDialog.AddExtension = true;
			saveFileDialog.CheckPathExists = true;
			saveFileDialog.DefaultExt = ".cardDB";
			saveFileDialog.InitialDirectory = "/data";
			saveFileDialog.OverwritePrompt = true;
			saveFileDialog.RestoreDirectory = true;
			saveFileDialog.ShowHelp = false;
			saveFileDialog.Filter = "card files (*.cardDB)|*.cardDB";

			//сериализация данных в файл JSon сериализацией
			if (saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				var savingList = JsonConvert.SerializeObject(_cardList, Formatting.Indented, new JsonSerializerSettings
				{
					TypeNameHandling = TypeNameHandling.Objects
				});
				File.WriteAllText(saveFileDialog.FileName, savingList);

				_currentFileName = Path.GetFileName(saveFileDialog.FileName);
				RenameForm();
			}
		}

		/// <summary>
		///     Окно открытия файла сохранения данных таблицы
		/// </summary>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//настройка окна сохранения файла
			openFileDialog.AddExtension = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.CheckFileExists = true;
			openFileDialog.DefaultExt = ".cardDB";
			openFileDialog.InitialDirectory = "/data";
			openFileDialog.RestoreDirectory = true;
			openFileDialog.ShowHelp = false;
			openFileDialog.Filter = "cardDB | *.cardDB";
			openFileDialog.Multiselect = false;
			openFileDialog.SupportMultiDottedExtensions = false;
			openFileDialog.ValidateNames = true;

			//Открытие выбранного файла сериализатором
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				_cardList.Clear();

				_currentFileName = Path.GetFileName(openFileDialog.SafeFileName);
				RenameForm();

				if (openFileDialog.SafeFileName != null)
				{
					var binder = new TypeNameSerializationBinder("{0}, LibraryCards");
					_cardList = JsonConvert.DeserializeObject<BindingList<ICard>>(File.ReadAllText(openFileDialog.FileName),
						new JsonSerializerSettings
						{
							TypeNameHandling = TypeNameHandling.Objects,
							Binder = binder
						});
				}

				dataGridView1.DataSource = _cardList;
			}
		}

		#endregion

		/// <summary>
		///     Удаление выбранного поля таблицы
		/// </summary>
		private void Remove_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow != null)
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
		}

		#endregion
	}
}