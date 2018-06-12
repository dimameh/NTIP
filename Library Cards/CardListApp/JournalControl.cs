using System;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class JournalControl : UserControl
	{
		public JournalControl()
		{
			InitializeComponent();
		}

		/// <summary>
		///     Карточка, с которой ведется работа
		/// </summary>
		public ICard Card
		{
			set
			{
				if (value is JournalCard article)
				{
					TitleTextBox.Text = article.Title;
					TitleOfPeriodicalTextBox.Text = article.MaterialType;
					JournalNumberTextBox.Text = article.JournalNumber.ToString();
					StartingPageTextBox.Text = article.FirstPage.ToString();
					LastPageTextBox.Text = article.LastPage.ToString();
					YearTextBox.Text = article.Year.ToString();
				}
			}
		}

		public string Title
		{
			get => TitleTextBox.Text;
			set => TitleTextBox.Text = value;
		}

		public string TitleOfPeriodical
		{
			get => TitleOfPeriodicalTextBox.Text;
			set => TitleOfPeriodicalTextBox.Text = value;
		}

		public int JournalNumber
		{
			get => Convert.ToInt32(JournalNumberTextBox.Text);
			set => JournalNumberTextBox.Text = value.ToString();
		}

		public int FirstPage
		{
			get => Convert.ToInt32(StartingPageTextBox.Text);
			set => StartingPageTextBox.Text = value.ToString();
		}

		public int LastPage
		{
			get => Convert.ToInt32(LastPageTextBox.Text);
			set => LastPageTextBox.Text = value.ToString();
		}

		public int Year
		{
			get => Convert.ToInt32(YearTextBox.Text);
			set => YearTextBox.Text = value.ToString();
		}

		/// <summary>
		///     При передаче true, делает все поля ReadOnly. При false снимает данный параметр
		/// </summary>
		/// <param name="isItReadOnly"></param>
		public bool ReadOnly
		{
			set
			{
				TitleTextBox.ReadOnly = value;
				TitleOfPeriodicalTextBox.ReadOnly = value;
				JournalNumberTextBox.ReadOnly = value;
				StartingPageTextBox.ReadOnly = value;
				LastPageTextBox.ReadOnly = value;
				YearTextBox.ReadOnly = value;
			}
		}

		#region Fields methods

		/// <summary>
		///     Допускает ввод в поле только десятичных цифр
		/// </summary>
		/// <param name="e">Переменная обработчика событий нажатия</param>
		private void ReadOnlyNumbers(KeyPressEventArgs e)
		{
			//e.KeyChar != (Char)Keys.Back - нужно для того чтобы не блокировалось нажатие клавиши backspace
			if (char.IsDigit(e.KeyChar) || e.KeyChar == (char) Keys.Back)
				CantInputSpace(e);
			else
				e.Handled = true;
		}

		/// <summary>
		///     Допускает ввод в поле только букв и символов пробела. Исправляет первую букву на заглавную
		/// </summary>
		/// <param name="e">Переменная обработчика событий нажатия</param>
		private void ReadOnlyChar(KeyPressEventArgs e, string text)
		{
			//Допусаем ввод только буквы и пробелы
			//e.KeyChar != (Char)Keys.Back - нужно для того чтобы не блокировалось нажатие клавиши backspace
			if (char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar != (char) Keys.Back)
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
		///     Если хотя бы одно поле не заполнено возвращает false, в другом случае true
		/// </summary>
		/// <returns></returns>
		public bool IsFieldsFilled()
		{
			//Поле additional info является необязательным
			return TitleTextBox.Text != string.Empty && TitleOfPeriodicalTextBox.Text != string.Empty &&
			       JournalNumberTextBox.Text != string.Empty &&
			       StartingPageTextBox.Text != string.Empty && LastPageTextBox.Text != string.Empty &&
			       YearTextBox.Text != string.Empty;
		}

		#endregion

		#region Fields "key press" settings

		private void Title_KeyPress(object sender, KeyPressEventArgs e)
		{
			//Не допускается начинать ввод с пробела
			CantStartWithSpace(e, TitleTextBox.Text);
		}

		private void TitleOfPeriodical_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, TitleOfPeriodicalTextBox.Text);
		}

		private void JournalNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		private void StartingPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		private void LastPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			// допускается ввод только цифр
			ReadOnlyNumbers(e);
		}

		private void Year_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		#endregion
	}
}