using System;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class CollectionControl : UserControl
	{
		public CollectionControl()
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
				if (value is CollectionCard article)
				{
					TitleTextBox.Text = article.Title;
					ThemeTextBox.Text = article.MaterialType;
					CityTextBox.Text = article.CityOfPublication;
					DateMaskedTextBox.Text = article.Date.ToString();
					FirstPageTextBox.Text = article.FirstPage.ToString();
					LastPageTextBox.Text = article.LastPage.ToString();
				}
			}
		}

		public string Title
		{
			get => TitleTextBox.Text;
			set => TitleTextBox.Text = value;
		}

		public string ThemeOfCollection
		{
			get => ThemeTextBox.Text;
			set => ThemeTextBox.Text = value;
		}

		public string City
		{
			get => CityTextBox.Text;
			set => CityTextBox.Text = value;
		}

		public DateTime Date
		{
			get => DateTime.Parse(DateMaskedTextBox.Text);
			set => DateMaskedTextBox.Text = value.ToShortDateString();
		}

		public int FirstPage
		{
			get => Convert.ToInt32(FirstPageTextBox.Text);
			set => FirstPageTextBox.Text = value.ToString();
		}

		public int LastPage
		{
			get => Convert.ToInt32(LastPageTextBox.Text);
			set => LastPageTextBox.Text = value.ToString();
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
				ThemeTextBox.ReadOnly = value;
				CityTextBox.ReadOnly = value;
				DateMaskedTextBox.ReadOnly = value;
				FirstPageTextBox.ReadOnly = value;
				LastPageTextBox.ReadOnly = value;
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
		///     Если хотя бы одно поле не заполнено возвращает false, в другом случае true
		/// </summary>
		/// <returns></returns>
		public bool IsFieldsFilled()
		{
			//Поле additional info является необязательным
			return TitleTextBox.Text != string.Empty && ThemeTextBox.Text != string.Empty &&
			       CityTextBox.Text != string.Empty &&
			       DateMaskedTextBox.Text != string.Empty && FirstPageTextBox.Text != string.Empty &&
			       LastPageTextBox.Text != string.Empty;
		}

		#endregion

		#region Fields "key press" settings

		private void Title_KeyPress(object sender, KeyPressEventArgs e)
		{
			//Не допускается начинать ввод с пробела
			CantStartWithSpace(e, TitleTextBox.Text);
		}

		private void Theme_KeyPress(object sender, KeyPressEventArgs e)
		{
			CantStartWithSpace(e, ThemeTextBox.Text);
		}

		private void City_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, CityTextBox.Text);
		}

		private void Date_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		private void FirstPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			// допускается ввод только цифр
			ReadOnlyNumbers(e);
		}

		private void LastPage_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		#endregion
	}
}