using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryCards;

namespace WindowsFormsApp1
{
	public partial class AddRecord : Form
	{
		#region Frontand changing methods

		private const int DefaultTextBoxLength = 32767;

		
		/// <summary>
		/// Скрыть поле дополнительной информации
		/// </summary>
		private void AdditionalInfoDisable()
		{
			AdditionalInfoLabel.Visible = false;
			AdditionalInfoLabel.Enabled = false;
			AdditionalInfoTextBox.Visible = false;
			AdditionalInfoTextBox.Enabled = false;
		}
		
		/// <summary>
		/// Показать поле дополнительной информации
		/// </summary>
		private void AdditionalInfoEnable()
		{
			AdditionalInfoLabel.Visible = true;
			AdditionalInfoLabel.Enabled = true;
			AdditionalInfoTextBox.Visible = true;
			AdditionalInfoTextBox.Enabled = true;
		}

		/// <summary>
		/// Очистить поля и сбросить их настройки
		/// </summary>
		private void SetDefaultFields()
		{
			AdditionalInfoDisable();
			TextBox2.MaxLength = DefaultTextBoxLength;
			TextBox3.MaxLength = DefaultTextBoxLength;
			maskedTextBox4.Mask = string.Empty;
			TextBox5.MaxLength = DefaultTextBoxLength;
			TextBox6.MaxLength = DefaultTextBoxLength;

			TextBox1.Text = string.Empty;
			TextBox2.Text = string.Empty;
			TextBox3.Text = string.Empty;
			maskedTextBox4.Text = string.Empty;
			TextBox5.Text = string.Empty;
			TextBox6.Text = string.Empty;
			AdditionalInfoTextBox.Text = string.Empty;
		}

		#endregion

		private List<FullName> authors;

		public AddRecord()
		{
			InitializeComponent();

			authors = new List<FullName>();
			dataGridView1.ColumnCount = 3;
			dataGridView1.RowCount = 0;
		}

		#region Radiobuttons chekcings

		/// <summary>
		/// Переключатель "Book"
		/// </summary>
		private void BookRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();
			AdditionalInfoEnable();

			label2.Text = "Genre";
			label3.Text = "Publishing house";
			label4.Text = "City of publication";
			label5.Text = "Year";
			label6.Text = "Volume (Pages)";

			TextBox5.MaxLength = 4;
		}
		
		/// <summary>
		/// Переключатель "Dissertation"
		/// </summary>
		private void DissertationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();

			label2.Text = "Page";
			label3.Text = "Science degree";
			label4.Text = "Specialization number";
			label5.Text = "Year";
			label6.Text = "City of publication";

			maskedTextBox4.Mask = "00.00.00";
			TextBox5.MaxLength = 4;
		}
		
		/// <summary>
		/// Переключатель "Journal"
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
		/// Переключатель "Collecton"
		/// </summary>
		private void CollectionRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SetDefaultFields();

			label2.Text = "Theme of the collection";
			label3.Text = "City of publication";
			label4.Text = "Date of publication";
			label5.Text = "First page";
			label6.Text = "Last page";

			maskedTextBox4.Mask = "00/00/0000";
		}

		#endregion

		#region Fields input settings

		#region Fields methods

		/// <summary>
		/// Допускает ввод в поле только десятичных цифр
		/// </summary>
		/// <param name="e">Переменная обработчика событий нажатия</param>
		private void ReadOnlyNumbers(KeyPressEventArgs e)
		{
			if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (Char)Keys.Back)
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// Допускает ввод в поле только букв и символов пробела. Исправляет первую букву на заглавную
		/// </summary>
		/// <param name="e">Переменная обработчика событий нажатия</param>
		private void ReadOnlyChar(KeyPressEventArgs e, string text)
		{
			//Допусаем ввод только буквы и пробелы
			if (Char.IsLetter(e.KeyChar) || e.KeyChar == ' ' || e.KeyChar == (Char)Keys.Back)
			{
				//Если строка пустая, нужно начать с большой буквы
				CantStartWithSpace(e, text);
			}
			else
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// Запрещает первым символом вводить пробел
		/// </summary>
		private void CantStartWithSpace(KeyPressEventArgs e, string text)
		{
			//Если строка пустая, нужно начать с большой буквы
			if (text == string.Empty)
			{
				if (e.KeyChar == ' ')
				{
					e.Handled = true;
				}
				else
				{
					e.KeyChar = Char.ToUpper(e.KeyChar);
				}
			}
		}
		/// <summary>
		/// Полностью запрещает ввод пробелов
		/// </summary>
		/// <param name="e"></param>
		private void CantInputSpace(KeyPressEventArgs e)
		{
			if (e.KeyChar == ' ')
			{
				e.Handled = true;
			}
		}

		#endregion

		private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (TextBox1.Text == string.Empty)
			{
				//Жанр не может начаться с пробела
				if (e.KeyChar == ' ')
				{
					e.Handled = true;
				}
				else
				{
					e.KeyChar = Char.ToUpper(e.KeyChar);
				}
			}
		}

		private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (BookRadioButton.Checked || JournalRadioButton.Checked)
			{
				ReadOnlyChar(e, TextBox2.Text);
			}
			else if (DissertationRadioButton.Checked)
			{
				ReadOnlyNumbers(e);
			}
			else
			{
				CantStartWithSpace(e,TextBox2.Text);
			}
		}

		private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (JournalRadioButton.Checked)
			{
				ReadOnlyNumbers(e);
			}
			else
			{
				ReadOnlyChar(e, TextBox3.Text);
			}
		}

		private void maskedTextBox4_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (BookRadioButton.Checked)
			{
				ReadOnlyChar(e, maskedTextBox4.Text);
			}
			else
			{
				ReadOnlyNumbers(e);
			}
		}

		private void TextBox5_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyNumbers(e);
		}

		private void TextBox6_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (DissertationRadioButton.Checked)
			{
				ReadOnlyChar(e, TextBox6.Text);
			}
			else
			{
				ReadOnlyNumbers(e);
			}
		}

		private void AdditionalInfoTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			CantStartWithSpace(e, AdditionalInfoTextBox.Text);
		}

		private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, NameTextBox.Text);
			CantInputSpace(e);
		}

		private void SurnameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, SurnameTextBox.Text);
			CantInputSpace(e);
		}

		private void PatronymicTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			ReadOnlyChar(e, PatronymicTextBox.Text);
			CantInputSpace(e);
		}


		#endregion



		private void AddAuthor_Click(object sender, EventArgs e)
		{
			if (NameTextBox.Text != string.Empty || SurnameTextBox.Text != string.Empty ||
			    PatronymicTextBox.Text != string.Empty)
			{
				authors.Add(new FullName(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text));
				
			}
		}
	}
}
