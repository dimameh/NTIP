using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using LibraryCards;
using Newtonsoft.Json;

//TODO: А папка с проектом называется по-старому.
//TODO: Почему-то в репозитории лежит две папки с формами вместо одной - лишний проект надо удалить
namespace CardListApp
{
    //TODO: кнопки на формах обычно располагаются впритык на расстоянии марджина
    public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			_cardList = new BindingList<ICard>();
            //TODO: иконку можно задать в свойствах проекта и настройках формы в дизайнере - тогда она еще автоматически добавится в ресурсы
            //TODO: Иконка отваливается при запуске приложения
            //Icon = new Icon("ico.ico");
            RenameForm();
			SetDefaultWindowSize();
		}

		public MainForm(string fileName)
		{
			InitializeComponent();
			_cardList = new BindingList<ICard>();
            //TODO: иконку можно задать в свойствах проекта и настройках формы в дизайнере - тогда она еще автоматически добавится в ресурсы
            //TODO: Иконка отваливается при запуске приложения
            Icon = new Icon("ico.ico");
			RenameForm();
			SetDefaultWindowSize();

            //Открытие выбранного файла сериализатором
            //TODO: код повторяется с тем, что происходит в загрузке файлов - может нужно вынести в отдельный метод?
            _cardList.Clear();

			_currentFileName = fileName;
			RenameForm();
            //TODO: зачем OpenFileDialog, если имя файла уже известно?
            if (openFileDialog.SafeFileName != null)
			{
                //TODO: сериализацию вынести в отдельный класс
                var binder = new TypeNameSerializationBinder("{0}, LibraryCards");
				_cardList = JsonConvert.DeserializeObject<BindingList<ICard>>(File.ReadAllText(fileName),
					new JsonSerializerSettings
					{
						TypeNameHandling = TypeNameHandling.Objects,
						Binder = binder
					});


				dataGridViewMain.DataSource = _cardList;
			}
		}

		#region Frontand changing methods

		/// <summary>
		///     Переименовать форму (Используется при сохранении или открытии файла)
		/// </summary>
		private void RenameForm()
		{
			Text = _currentFileName + " - Library Cards";
		}

		/// <summary>
		///     Установить начальный размер окна и скрыть информацию о карточках
		/// </summary>
		private void SetDefaultWindowSize()
		{
			IsLabelVisible = false;
			Size = new Size(860, 350);
		}

		#endregion

		#region Private properties

		/// <summary>
		///     Главный список карточек
		/// </summary>
		private BindingList<ICard> _cardList;

		/// <summary>
		///     Название файла с которым ведется работа
		/// </summary>
		private string _currentFileName = "New card list";

        //TODO: комментарий бесполезный - я так вижу, что он меняет видимость лейблов. А что за лейблы - непонятно?
        /// <summary>
        ///     True делает label'ы видимыми, falsе - скрывает
        /// </summary>
        private bool IsLabelVisible
		{
			set
			{
                //TODO: лейблы переименовать
                label7.Visible = value;
				label1.Visible = value;
				label2.Visible = value;
				label3.Visible = value;
				label4.Visible = value;
				label5.Visible = value;
				label6.Visible = value;
				label7.Visible = value;

				label11.Visible = value;
				label12.Visible = value;
				label13.Visible = value;
				label14.Visible = value;
				label15.Visible = value;
				label16.Visible = value;
				label17.Visible = value;
			}
		}

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
				dataGridViewMain.DataSource = _cardList;
			}
			else
			{
                //TODO: Не надо этого сообщения. Зачем говорить об ошибке, если ничего не надо удалять?
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
				if (newRecordForm.NewCard != null)
				{
					if (!IsInTable(newRecordForm.NewCard))
					{
						_cardList.Add(newRecordForm.NewCard);
						dataGridViewMain.DataSource = _cardList;
					}
					else
					{
						MessageBox.Show("This record is already exist", "Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show("You cant add empty record", "Error", MessageBoxButtons.OK,
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

		/// <summary>
		///     Открытие окна с формой редактирования выбранной карточки
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ModifyButton_Click(object sender, EventArgs e)
		{
			IsLabelVisible = false;
            //TODO: а размер-то чего меняется при модификации записи?
            Size = new Size(860, 350);
			if (dataGridViewMain.CurrentRow != null)
			{
				var newModifyForm = new AddRecordForm
				{
					NewCard = _cardList[dataGridViewMain.CurrentRow.Index]
				};

				newModifyForm.ShowDialog();

				if (newModifyForm.DialogResult == DialogResult.OK)
				{
					if (newModifyForm.NewCard != null)
						_cardList[dataGridViewMain.CurrentRow.Index] = newModifyForm.NewCard;
					else
						MessageBox.Show("You cant add empty record", "Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
				}
			}
		}

        #endregion

        #region Save/Open

        //TODO: Лихо, но не нужно. Сериализация может работать и без этого. См. класс JsonSerializer и его настройки
        /// <summary>
        ///     Перегрузка SerializationBinder
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
            //TODO: это всё можно настроить через дизайнер, чтобы не валялось здесь
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
                //TODO: сериализацию вынести в отдельный класс
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
            //TODO: это всё можно настроить через дизайнер, чтобы не валялось здесь
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
                    //TODO: сериализацию вынести в отдельный класс
                    var binder = new TypeNameSerializationBinder("{0}, LibraryCards");
					_cardList = JsonConvert.DeserializeObject<BindingList<ICard>>(File.ReadAllText(openFileDialog.FileName),
						new JsonSerializerSettings
						{
							TypeNameHandling = TypeNameHandling.Objects,
							Binder = binder
						});
				}

				dataGridViewMain.DataSource = _cardList;
			}
		}

		#endregion

		/// <summary>
		///     Удаление выбранного поля таблицы
		/// </summary>
		private void Remove_Click(object sender, EventArgs e)
		{
			if (dataGridViewMain.CurrentRow != null)
				dataGridViewMain.Rows.Remove(dataGridViewMain.CurrentRow);

			SetDefaultWindowSize();
		}

		/// <summary>
		///     Выводит информацию о карточке при клике на нее в таблице
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			IsLabelVisible = true;
            //TODO: зачем играешься с формой наживую? Почему нельзя всегда отображать подробные данные о выбранной записи?
            Size = new Size(860, 690);
			var currentCard = _cardList[dataGridViewMain.CurrentRow.Index];

            //TODO: У тебя есть CardControl, и он может показывать данные о карточке - зачем ты здесь дублируешь его функцоинальность?
            if (currentCard is BookArticle book)
			{                
                label7.Visible = label17.Visible = true;
				label1.Text = "Title";
				label2.Text = "Genre";
				label3.Text = "Publishing house";
				label4.Text = "City of publication";
				label5.Text = "Year";
				label6.Text = "Volume (pages)";
				label7.Text = "AdditionalInfo";

				label11.Text = book.Title;
				label12.Text = book.MaterialType;
				label13.Text = book.PublishingHouse;
				label14.Text = book.CityOfPublication;
				label15.Text = book.Year.ToString();
				label16.Text = book.Volume.ToString();
				label17.Text = book.AdditionalInfo;

				dataGridViewAuthors.DataSource = book.Authors;
			}

			else if (currentCard is Dissertation dissertation)
			{
				label7.Visible = label17.Visible = false;

				label1.Text = "Title";
				label2.Text = "Page";
				label3.Text = "Science degree";
				label4.Text = "Specialization number";
				label5.Text = "Year";
				label6.Text = "City of publication";

				label11.Text = dissertation.Title;
				label12.Text = dissertation.Page.ToString();
				label13.Text = dissertation.AuthorStatus;
				label14.Text = dissertation.SpecializationNumber;
				label15.Text = dissertation.Year.ToString();
				label16.Text = dissertation.CityOfPublication;

				var dissertationAuthor = new List<FullName>();
				dissertationAuthor.Add(dissertation.FirstAuthor);
				dataGridViewAuthors.DataSource = dissertationAuthor;
			}

			else if (currentCard is JournalArticle journal)
			{
				label7.Visible = label17.Visible = false;

				label1.Text = "Title";
				label2.Text = "Title of periodical";
				label3.Text = "Journal number";
				label4.Text = "Starting page";
				label5.Text = "Last page";
				label6.Text = "Year";

				label11.Text = journal.Title;
				label12.Text = journal.MaterialType;
				label13.Text = journal.JournalNumber.ToString();
				label14.Text = journal.FirstPage.ToString();
				label15.Text = journal.LastPage.ToString();
				label16.Text = journal.Year.ToString();

				dataGridViewAuthors.DataSource = journal.Authors;
			}

			else if (currentCard is CollectionArticle collection)
			{
				label7.Visible = label17.Visible = false;

				label1.Text = "Title";
				label2.Text = "Theme of collection";
				label3.Text = "City of publication";
				label4.Text = "Date of publication";
				label5.Text = "First page";
				label6.Text = "Last page";

				label11.Text = collection.Title;
				label12.Text = collection.MaterialType;
				label13.Text = collection.CityOfPublication;
				label14.Text = collection.Date.ToShortDateString();
				label15.Text = collection.FirstPage.ToString();
				label16.Text = collection.LastPage.ToString();

				dataGridViewAuthors.DataSource = collection.Authors;
			}
		}

		#endregion
	}
}