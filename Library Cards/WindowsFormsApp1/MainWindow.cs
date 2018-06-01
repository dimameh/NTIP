using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using LibraryCards;

namespace WindowsFormsApp1
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
			_cardList = new BindingList<ICard>();
			RenameForm();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
		}

		/// <summary>
		///     Переименовать форму (Используется при сохранении или открытии файла)
		/// </summary>
		private void RenameForm()
		{
			Text = Text + " | " + _currentFileName;
		}

		/// <summary>
		///     Возвращает копию Главного списка карточек
		/// </summary>
		public BindingList<ICard> DataList
		{
			get
			{
				var cardListCopy = new BindingList<ICard>(_cardList);
				return cardListCopy;
			}
		}

		#region Private properties

		/// <summary>
		///     Главный список карточек
		/// </summary>
		private BindingList<ICard> _cardList;

		/// <summary>
		///     Название файла с которым ведется работа
		/// </summary>
		private string _currentFileName = "Not Saved";

		/// <summary>
		///     Сериализатор для сохранения и открытия файлов
		/// </summary>
		private BindingSource _serializer;

		#endregion

		#region Table methods

		/// <summary>
		///     Обновить таблицу
		/// </summary>
		private void RefreshTable()
		{
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = _cardList;
		}

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
		///     Добавить книгу в Главный список карточек
		/// </summary>
		public void AddBookInList(BookArticle book)
		{
			if (!IsInTable(book))
			{
				_cardList.Add(book);
				RefreshTable();
			}
			else
			{
				MessageBox.Show("That record is already exist.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Добавить диссертацию в Главный список карточек
		/// </summary>
		public void AddDissertationInList(Dissertation dissertation)
		{
			if (!IsInTable(dissertation))
			{
				_cardList.Add(dissertation);
				RefreshTable();
			}
			else
			{
				MessageBox.Show("That record is already exist.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Добавить журнал в Главный список карточек
		/// </summary>
		public void AddJournalInList(JournalArticle journal)
		{
			if (!IsInTable(journal))
			{
				_cardList.Add(journal);
				RefreshTable();
			}
			else
			{
				MessageBox.Show("That record is already exist.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Добавить сборник в Главный список карточек
		/// </summary>
		public void AddCollectionInList(CollectionArticle collections)
		{
			if (!IsInTable(collections))
			{
				_cardList.Add(collections);
				RefreshTable();
			}
			else
			{
				MessageBox.Show("That record is already exist.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Удалить указанную карточку из Главного списка
		/// </summary>
		public void RemoveCard(ICard removingCard)
		{
			if (removingCard != null)
			{
				_cardList.Remove(removingCard);
				RefreshTable();
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
			var newRecordForm = new AddRecord(this);
			newRecordForm.Show();
		}

		/// <summary>
		///     Открытие окна с формой поиска карточек
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			var newSearchForm = new Search(this);
			newSearchForm.Show();
		}

		#endregion

		/// <summary>
		///     Окно сохранения данных таблицы
		/// </summary>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//настройка окна сохранения файла
			saveFileDialog1.AddExtension = true;
			saveFileDialog1.CheckPathExists = true;
			saveFileDialog1.DefaultExt = ".cardDB";
			saveFileDialog1.InitialDirectory = "/data";
			saveFileDialog1.OverwritePrompt = true;
			saveFileDialog1.RestoreDirectory = true;
			saveFileDialog1.ShowHelp = false;
			saveFileDialog1.Filter = "card files (*.cardDB)|*.cardDB";

			//бинарная сериализация данных в файл
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				var saveStream = new FileStream(saveFileDialog1.FileName, FileMode.Create);

				var serializer = new BinaryFormatter();
				serializer.Serialize(saveStream, _cardList);
				saveStream.Close();

				_currentFileName = saveFileDialog1.FileName;
				RenameForm();
			}
		}

		/// <summary>
		///     Окно открытия файла сохранения данных таблицы
		/// </summary>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//настройка окна сохранения файла
			openFileDialog1.AddExtension = true;
			openFileDialog1.CheckPathExists = true;
			openFileDialog1.CheckFileExists = true;
			openFileDialog1.DefaultExt = ".cardDB";
			openFileDialog1.InitialDirectory = "/data";
			openFileDialog1.RestoreDirectory = true;
			openFileDialog1.ShowHelp = false;
			openFileDialog1.Filter = "card files (*.cardDB)|*.cardDB";
			openFileDialog1.Multiselect = false;
			openFileDialog1.SupportMultiDottedExtensions = false;
			openFileDialog1.ValidateNames = true;

			//Открытие выбранного файла сериализатором
			if (openFileDialog1.ShowDialog() == DialogResult.OK)
			{
				_cardList.Clear();

				_currentFileName = openFileDialog1.SafeFileName;
				RenameForm();

				var openStream = openFileDialog1.OpenFile();
				var desializer = new BinaryFormatter();
				_cardList = desializer.Deserialize(openStream) as BindingList<ICard>;
				openStream.Close();

				RefreshTable();
			}
		}

		/// <summary>
		///     Удаление выбранного поля таблицы
		/// </summary>
		private void Remove_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow != null)
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
			else
				MessageBox.Show("Select record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		#endregion
	}
}