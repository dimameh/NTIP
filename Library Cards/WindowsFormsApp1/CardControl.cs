using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LibraryCards;

namespace WindowsFormsApp1
{
    //TODO: Кнопки Ok, Cancel, Random должны находиться на форме, а не на контроле
    // Они же связаны с закрытием формы, так почему они располагаются на контроле?
    //TODO: Здоровенный контрол получается. Не приходила мысль поделить его на более мелкие для простоты его редактирования? AuthorControl, BookControl, DissertationControl и т.д...
    public partial class CardControl : UserControl
	{
		public CardControl()
		{
			InitializeComponent();
#if !DEBUG
			RandomButton.Visible = false;
#endif
			_authors = new BindingList<FullName>();
		}

		/// <summary>
		///     Карточка, с которой ведется работа
		/// </summary>
		public ICard Card
		{
			get
			{
				if (IsFieldsFilled())
				{
					if (BookRadioButton.Checked)
						return new BookArticle
						(
							_authors.ToList(),
							TextBox1.Text,
							TextBox2.Text,
							TextBox3.Text,
							Convert.ToInt32(TextBox5.Text),
							Convert.ToInt32(TextBox6.Text),
							maskedTextBox4.Text,
							AdditionalInfoTextBox.Text
						);

					if (DissertationRadioButton.Checked)
						return new Dissertation
						(
							_authors[0],
							TextBox1.Text,
							Convert.ToInt32(TextBox2.Text),
							TextBox3.Text,
							Convert.ToInt32(TextBox5.Text),
							TextBox6.Text,
							maskedTextBox4.Text
						);

					if (JournalRadioButton.Checked)
						return new JournalArticle
						(
							_authors.ToList(),
							TextBox1.Text,
							TextBox2.Text,
							Convert.ToInt32(TextBox3.Text),
							Convert.ToInt32(maskedTextBox4.Text),
							Convert.ToInt32(TextBox5.Text),
							Convert.ToInt32(TextBox6.Text)
						);
					return new CollectionArticle
					(
						_authors.ToList(),
						DateTime.Parse(maskedTextBox4.Text),
						TextBox1.Text,
						TextBox2.Text,
						Convert.ToInt32(TextBox5.Text),
						Convert.ToInt32(TextBox6.Text),
						TextBox3.Text
					);
				}

				return null;
			}
			set
			{
				if (value is BookArticle book)
				{
					BookRadioButton.Checked = true;

					TextBox1.Text = book.Title;
					TextBox2.Text = book.MaterialType;
					TextBox3.Text = book.PublishingHouse;
					maskedTextBox4.Text = book.CityOfPublication;
					TextBox5.Text = book.Year.ToString();
					TextBox6.Text = book.Volume.ToString();
					AdditionalInfoTextBox.Text = book.AdditionalInfo;

					_authors = new BindingList<FullName>(book.Authors);
					dataGridView1.DataSource = _authors;
				}

				else if (value is Dissertation dissertation)
				{
					DissertationRadioButton.Checked = true;

					TextBox1.Text = dissertation.Title;
					TextBox2.Text = dissertation.Page.ToString();
					TextBox3.Text = dissertation.AuthorStatus;
					maskedTextBox4.Text = dissertation.SpecializationNumber;
					TextBox5.Text = dissertation.Year.ToString();
					TextBox6.Text = dissertation.CityOfPublication;
					IsAdditionalInfoShow = false;

					_authors = new BindingList<FullName> {dissertation.FirstAuthor};
					dataGridView1.DataSource = _authors;
				}

				else if (value is JournalArticle journal)
				{
					JournalRadioButton.Checked = true;

					TextBox1.Text = journal.Title;
					TextBox2.Text = journal.MaterialType;
					TextBox3.Text = journal.JournalNumber.ToString();
					maskedTextBox4.Text = journal.FirstPage.ToString();
					TextBox5.Text = journal.LastPage.ToString();
					TextBox6.Text = journal.Year.ToString();
					IsAdditionalInfoShow = false;

					_authors = new BindingList<FullName>(journal.Authors);
					dataGridView1.DataSource = _authors;
				}

				else if (value is CollectionArticle collection)
				{
					JournalRadioButton.Checked = true;

					TextBox1.Text = collection.Title;
					TextBox2.Text = collection.MaterialType;
					TextBox3.Text = collection.CityOfPublication;
					maskedTextBox4.Text = collection.Date.ToShortDateString();
					TextBox5.Text = collection.FirstPage.ToString();
					TextBox6.Text = collection.LastPage.ToString();
					IsAdditionalInfoShow = false;

					_authors = new BindingList<FullName>(collection.Authors);
					dataGridView1.DataSource = _authors;
				}
			}
		}

		/// <summary>
		///     При передаче true, делает все поля ReadOnly. При false снимает данный параметр
		/// </summary>
		/// <param name="isItReadOnly"></param>
		public bool ReadOnly
		{
			set
			{
				TextBox1.ReadOnly = value;
				TextBox2.ReadOnly = value;
				TextBox3.ReadOnly = value;
				maskedTextBox4.ReadOnly = value;
				TextBox5.ReadOnly = value;
				TextBox6.ReadOnly = value;
				AdditionalInfoTextBox.ReadOnly = value;
				NameTextBox.ReadOnly = value;
				SurnameTextBox.ReadOnly = value;
				PatronymicTextBox.ReadOnly = value;
			}
		}

		#region Private properties

		/// <summary>
		///     Стандартная длина TextBox
		/// </summary>
		private const int DefaultTextBoxLength = 32767;

		/// <summary>
		///     Список добавляемых авторов
		/// </summary>
		private BindingList<FullName> _authors;

        #endregion

        //TODO: фронтэнд пишется по-другому
        #region Frontand changing methods

        /// <summary>
        ///     Скрыть поле дополнительной информации
        /// </summary>
        private bool IsAdditionalInfoShow
		{
			set
			{
				AdditionalInfoLabel.Visible = value;
				AdditionalInfoLabel.Enabled = value;
				AdditionalInfoTextBox.Visible = value;
				AdditionalInfoTextBox.Enabled = value;
			}
		}

		/// <summary>
		///     Очистить поля и сбросить их настройки
		/// </summary>
		private void SetDefaultFields()
		{
			IsAdditionalInfoShow = false;

			//сброс настроек длины поля
			TextBox2.MaxLength = DefaultTextBoxLength;
			TextBox3.MaxLength = DefaultTextBoxLength;
			maskedTextBox4.Mask = string.Empty;
			TextBox5.MaxLength = DefaultTextBoxLength;
			TextBox6.MaxLength = DefaultTextBoxLength;

			//сброс введенных данных
			TextBox1.Text = string.Empty;
			TextBox2.Text = string.Empty;
			TextBox3.Text = string.Empty;
			maskedTextBox4.Text = string.Empty;
			TextBox5.Text = string.Empty;
			TextBox6.Text = string.Empty;
			AdditionalInfoTextBox.Text = string.Empty;

			//сброс введенных авторов
			SurnameTextBox.Text = string.Empty;
			NameTextBox.Text = string.Empty;
			PatronymicTextBox.Text = string.Empty;
			_authors.Clear();
		}

        #endregion

        #region Random methods

        //TODO: Вынести в отдельный класс
        private static FullName GenerateFullName()
		{
			string[] femaleNames =
			{
				"София",
				"Альвина",
				"Арина",
				"Амира",
				"Алиса",
				"Сафина",
				"Лиза",
				"марина"
			};
			string[] femaleSurnames =
			{
				"Цветкова",
				"Кононова",
				"Белоусова",
				"Воронова",
				"Емельянова",
				"Беспалова",
				"Новикава",
				"Белядко"
			};
			string[] femalePatronymics =
			{
				"Иванова",
				"Антониновна",
				"Серпантиновна",
				"Петровна",
				"Максимовна",
				"Евсеевна",
				"Вртемовна",
				"Дмитреевна"
			};
			string[] maleNames =
			{
				"Леонард",
				"Кондратий",
				"Феликс",
				"Виктор",
				"Родион",
				"Даниил",
				"Август",
				"Антуан"
			};
			string[] maleSurnames =
			{
				"Третяков",
				"Михеев",
				"Терентьев",
				"Павлов",
				"Маслов",
				"Соловьев",
				"Бобилев",
				"Гробовозов"
			};
			string[] malePatronymics =
			{
				"Агафонович",
				"Михайлович",
				"Германович",
				"Владимирович",
				"Аристархович",
				"Глебович",
				"Мэлсович",
				"Борисович"
			};

			var rand = new Random();
			var sex = rand.Next(100) <= 50 ? true : false;

			if (sex)
				return SetNames(maleNames, maleSurnames, malePatronymics);
			return SetNames(femaleNames, femaleSurnames, femalePatronymics);
		}

		private static FullName SetNames(string[] names, string[] surnames, string[] patronymics)
		{
			var rand = new Random(DateTime.Now.Millisecond);
			var randomNumber = rand.Next(0, 7);
			var fullName = new FullName(surnames[randomNumber], names[randomNumber], patronymics[randomNumber]);

			return fullName;
		}

		#endregion

		#region Fields methods

		/// <summary>
		///     Допускает ввод в поле только десятичных цифр
		/// </summary>
		/// <param name="e">Переменная обработчика событий нажатия</param>
		private void ReadOnlyNumbers(KeyPressEventArgs e)
		{
			//e.KeyChar != (Char)Keys.Back - нужно для того чтобы не блокировалось нажатие клавиши backspace
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char) Keys.Back) e.Handled = true;
		}

		/// <summary>
		///     Допускает ввод в поле только букв и символов пробела. Исправляет первую букву на заглавную
		/// </summary>
		/// <param name="e">Переменная обработчика событий нажатия</param>
		private void ReadOnlyChar(KeyPressEventArgs e, string text)
		{
			//Допусаем ввод только буквы и пробелы
			//e.KeyChar != (Char)Keys.Back - нужно для того чтобы не блокировалось нажатие клавиши backspace
			if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == (char) Keys.Back)
				CantStartWithSpace(e, text);
			else
				e.Handled = true;
		}

		/// <summary>
		///     Запрещает первым символом вводить пробел
		/// </summary>
		private void CantStartWithSpace(KeyPressEventArgs e, string text)
		{
			//Если строка пустая, нужно начать с большой буквы
			if (text == string.Empty)
			{
				if (e.KeyChar == ' ')
					e.Handled = true;
				else
					e.KeyChar = char.ToUpper(e.KeyChar);
			}
		}

		/// <summary>
		///     Полностью запрещает ввод пробелов
		/// </summary>
		/// <param name="e"></param>
		private void CantInputSpace(KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ') e.Handled = true;
		}

		/// <summary>
		///     Очистить поля ввода ФИО автора
		/// </summary>
		private void CleanAuthorFields()
		{
			SurnameTextBox.Text = string.Empty;
			NameTextBox.Text = string.Empty;
			PatronymicTextBox.Text = string.Empty;
		}

		/// <summary>
		///     Если хотя бы одно из полей ФИО автора не заполнено, возвращает false, в другом случае true
		/// </summary>
		/// <returns></returns>
		private bool IsAuthorFilled()
		{
			return NameTextBox.Text != string.Empty && SurnameTextBox.Text != string.Empty &&
			       PatronymicTextBox.Text != string.Empty;
		}

		/// <summary>
		///     Если хотя бы одно поле не заполнено возвращает false, в другом случае true
		/// </summary>
		/// <returns></returns>
		public bool IsFieldsFilled()
		{
			//Поле additional info является необязательным
			return TextBox1.Text != string.Empty && TextBox2.Text != string.Empty && TextBox3.Text != string.Empty &&
			       maskedTextBox4.Text != string.Empty && TextBox5.Text != string.Empty && TextBox6.Text != string.Empty &&
			       _authors.Count != 0;
		}

		#endregion

		#region Radiobuttons chekcings

		/// <summary>
		///     Переключатель "Book"
		/// </summary>
		private void BookRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();

			IsAdditionalInfoShow = true;

			label2.Text = "Genre";
			label3.Text = "Publishing house";
			label4.Text = "City of publication";
			label5.Text = "Year";
			label6.Text = "Volume (Pages)";

			TextBox5.MaxLength = 4;
		}

		/// <summary>
		///     Переключатель "Dissertation"
		/// </summary>
		private void DissertationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();

			label2.Text = "Page";
			label3.Text = "Science degree";
			label4.Text = "Specialization number";
			label5.Text = "Year";
			label6.Text = "City of publication";

			maskedTextBox4.Culture = new CultureInfo("en-CA");
			maskedTextBox4.Mask = "00.00.00";

			TextBox5.MaxLength = 4;
		}

		/// <summary>
		///     Переключатель "Journal"
		/// </summary>
		private void JournalRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();

			label2.Text = "Title of the periodical";
			label3.Text = "Journal number";
			label4.Text = "Starting page";
			label5.Text = "Last page";
			label6.Text = "Year";

			TextBox6.MaxLength = 4;
		}

		/// <summary>
		///     Переключатель "Collecton"
		/// </summary>
		private void CollectionRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();

			label2.Text = "Theme of the collection";
			label3.Text = "City of publication";
			label4.Text = "Date of publication";
			label5.Text = "First page";
			label6.Text = "Last page";

			maskedTextBox4.Mask = "99/99/9999";
		}

		#endregion

		#region Fields "key press" settings

		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			//Не допускается начинать ввод с пробела
			CantStartWithSpace(e, TextBox1.Text);
		}

		private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			// при заполнении формы книги или журнала
			// допускается ввод только букв
			if (BookRadioButton.Checked || JournalRadioButton.Checked)
				ReadOnlyChar(e, TextBox2.Text);
			// при заполнении формы диссертации
			// допускается ввод только цифр
			else if (DissertationRadioButton.Checked)
				ReadOnlyNumbers(e);
			// при заполнении формы сборника
			// не разрешается начинать ввод с пробела
			else
				CantStartWithSpace(e, TextBox2.Text);
		}

		private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			// при заполнении формы журнала
			// допускается ввод только цифр
			if (JournalRadioButton.Checked)
				ReadOnlyNumbers(e);
			// при заполнении формы книги, диссертации или сборника
			// допускается ввод только букв
			else
				ReadOnlyChar(e, TextBox3.Text);
		}

		private void maskedTextBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			// при заполнении формы книги
			// допускается ввод только букв
			if (BookRadioButton.Checked)
				ReadOnlyChar(e, maskedTextBox4.Text);
			// при заполнении формы журнала, диссертации или сборника
			// допускается ввод только цифр
			else
				ReadOnlyNumbers(e);
		}

		private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			// допускается ввод только цифр
			ReadOnlyNumbers(e);
		}

		private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			// при заполнении формы диссертации
			// допускается ввод только букв
			if (DissertationRadioButton.Checked)
				ReadOnlyChar(e, TextBox6.Text);
			// при заполнении формы книги, журнала или сборника
			// допускается ввод только цифр
			else
				ReadOnlyNumbers(e);
		}

		private void AdditionalInfoTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// не допускается начинать ввод с пробела
			CantStartWithSpace(e, AdditionalInfoTextBox.Text);
		}

		private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Допускается ввод только букв
			// Ввод пробелов не допускается
			ReadOnlyChar(e, NameTextBox.Text);
			CantInputSpace(e);
		}

		private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Допускается ввод только букв
			// Ввод пробелов не допускается
			ReadOnlyChar(e, SurnameTextBox.Text);
			CantInputSpace(e);
		}

		private void PatronymicTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Допускается ввод только букв
			// Ввод пробелов не допускается
			ReadOnlyChar(e, PatronymicTextBox.Text);
			CantInputSpace(e);
		}

		#endregion

		#region Click events

		/// <summary>
		///     Добавляет нового автора в таблицу авторов
		/// </summary>
		private void AddAuthor_Click(object sender, EventArgs e)
		{
			// все поля автора должны быть заполнены
			if (IsAuthorFilled())
			{
				//Проверка добавлялся ли данный автор ранее
				var isNewAuthor = true;
				foreach (var author in _authors)
					if (author.Name == NameTextBox.Text && author.Surname == SurnameTextBox.Text &&
					    author.Patronymic == PatronymicTextBox.Text)
					{
						MessageBox.Show("You have already added this author.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);

						CleanAuthorFields();
						isNewAuthor = false;
					}

				//если автор не добавлялся ранее, он вносится в список авторов
				if (isNewAuthor)
				{
					try
					{
						_authors.Add(new FullName(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text));

						CleanAuthorFields();
					}
					catch (Exception exception)
					{
						MessageBox.Show(exception.Message, "Input error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}

					dataGridView1.DataSource = _authors;
				}
			}
			else
			{
				MessageBox.Show("All author fields must be filled in to add an author.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Удаляет выбранную запись в таблице авторов
		/// </summary>
		private void RemoveAuthor_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow != null)
			{
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
				dataGridView1.DataSource = _authors;
			}
			else
			{
				MessageBox.Show("Select author.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Выполняет внесение новых данных в Главную таблицу и закрывает форму добавления записи
		/// </summary>
		private void OK_Click(object sender, EventArgs e)
		{
			// все поля должны быть заполнены
			if (IsFieldsFilled())
			{
				OKButton.DialogResult = DialogResult.OK;
			}
			else
			{
				OKButton.DialogResult = DialogResult.None;
				MessageBox.Show("All fields must be filled in to add an record.", "Error", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		/// <summary>
		///     Добавляет в Главную таблицу одну из четырех записей
		/// </summary>
		private void Rand_Click(object sender, EventArgs e)
		{
			var rnd = new Random();
			// Вынеси генератор в отдельный класс и используй где хочешь
			switch (rnd.Next(1, 5))
			{
				case 1:
					BookRadioButton.Checked = true;
					TextBox1.Text = "Book";
					TextBox2.Text = "Genre";
					TextBox3.Text = "Publishing house";
					maskedTextBox4.Text = "City";
					TextBox5.Text = "2018";
					TextBox6.Text = "222";
					AdditionalInfoTextBox.Text = "";
					_authors.Add(GenerateFullName());
					_authors.Add(GenerateFullName());
					break;
				case 2:
					DissertationRadioButton.Checked = true;
					TextBox1.Text = "Dissertation";
					TextBox2.Text = "222";
					TextBox3.Text = "Author status";
					maskedTextBox4.Text = "000000";
					TextBox5.Text = "2017";
					TextBox6.Text = "City";
					_authors.Add(GenerateFullName());
					break;
				case 3:
					JournalRadioButton.Checked = true;
					TextBox1.Text = "Journal";
					TextBox2.Text = "Title  of periodical";
					TextBox3.Text = "111";
					maskedTextBox4.Text = "222";
					TextBox5.Text = "333";
					TextBox6.Text = "2018";
					_authors.Add(GenerateFullName());
					_authors.Add(GenerateFullName());
					break;
				default:
					CollectionRadioButton.Checked = true;
					TextBox1.Text = "Collection";
					TextBox2.Text = "Theme of collection";
					TextBox3.Text = "City";
					maskedTextBox4.Text = "27/08/1998";
					TextBox5.Text = "222";
					TextBox6.Text = "333";
					_authors.Add(GenerateFullName());
					_authors.Add(GenerateFullName());
					break;
			}

			dataGridView1.DataSource = _authors;
		}

		#endregion
	}
}