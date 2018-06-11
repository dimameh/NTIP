using System;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class DissertationControl : UserControl
	{
		public DissertationControl()
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
				if (value is Dissertation article)
				{
					TitleTextBox.Text = article.Title;
					PageTextBox.Text = article.Page.ToString();
					ScienceDegreeTextBox.Text = article.AuthorStatus;
					CityTextBox.Text = article.CityOfPublication;
					YearTextBox.Text = article.Year.ToString();
					SpecializationNumberMaskedTextBox.Text = article.SpecializationNumber;
				}
			}
		}

		public string Title
		{
			get => TitleTextBox.Text;
			set => TitleTextBox.Text = value;
		}

		public int Page
		{
			get => Convert.ToInt32(PageTextBox.Text);
			set => PageTextBox.Text = value.ToString();
		}

		public string ScienceDegree
		{
			get => ScienceDegreeTextBox.Text;
			set => ScienceDegreeTextBox.Text = value;
		}

		public string CityOfPublication
		{
			get => CityTextBox.Text;
			set => CityTextBox.Text = value;
		}

		public int Year
		{
			get => Convert.ToInt32(YearTextBox.Text);
			set => YearTextBox.Text = value.ToString();
		}

		public string SpecializationNumber
		{
			get => SpecializationNumberMaskedTextBox.Text;
			set => SpecializationNumberMaskedTextBox.Text = value;
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
				PageTextBox.ReadOnly = value;
				ScienceDegreeTextBox.ReadOnly = value;
				CityTextBox.ReadOnly = value;
				YearTextBox.ReadOnly = value;
				SpecializationNumberMaskedTextBox.ReadOnly = value;
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
			if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char) Keys.Back)
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
			return TitleTextBox.Text != string.Empty && PageTextBox.Text != string.Empty &&
			       ScienceDegreeTextBox.Text != string.Empty &&
			       CityTextBox.Text != string.Empty && YearTextBox.Text != string.Empty &&
			       SpecializationNumberMaskedTextBox.Text != string.Empty;
		}

		#endregion

		#region Fields "key press" settings

		private void Title_KeyPress(object sender, KeyPressEventArgs e)
		{
			//Не допускается начинать ввод с пробела
			CantStartWithSpace(e, TitleTextBox.Text);
		}

		private void Page_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		private void ScienceDegree_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, ScienceDegreeTextBox.Text);
		}

		private void City_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, CityTextBox.Text);
		}

		private void Year_KeyPress(object sender, KeyPressEventArgs e)
		{
			// допускается ввод только цифр
			ReadOnlyNumbers(e);
		}

		private void SpecializationNumber_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		#endregion
	}
}