using System;
using System.ComponentModel;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class AuthorsControl : UserControl
	{
		/// <summary>
		///     Список добавляемых авторов
		/// </summary>
		private readonly BindingList<FullName> _authors;

		public BindingList<FullName> Authors => new BindingList<FullName>(_authors);

		public void SetAuthors(BindingList<FullName> authors)
		{
			if (authors != null || authors.Count == 0)
			{
				_authors.Clear();
				for (var i = 0; i < authors.Count; i++) _authors.Add(authors[i]);

				dataGridView1.DataSource = _authors;
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
				NameTextBox.ReadOnly = value;
				SurnameTextBox.ReadOnly = value;
				PatronymicTextBox.ReadOnly = value;
				AddAuthor.Enabled = RemoveButton.Enabled = value;
			}
		}

		public AuthorsControl()
		{
			InitializeComponent();

			_authors = new BindingList<FullName>();
		}

		/// <summary>
		///     Если хотя бы одно из полей ФИО автора не заполнено, возвращает false, в другом случае true
		/// </summary>
		/// <returns></returns>
		public bool IsAuthorFilled()
		{
			return NameTextBox.Text != string.Empty && SurnameTextBox.Text != string.Empty &&
			       PatronymicTextBox.Text != string.Empty;
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

		private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Допускается ввод только букв
			// Ввод пробелов не допускается
			ReadOnlyChar(e, NameTextBox.Text);
			CantInputSpace(e);
		}

		private void PatronymicTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			// Допускается ввод только букв
			// Ввод пробелов не допускается
			ReadOnlyChar(e, PatronymicTextBox.Text);
			CantInputSpace(e);
		}

		private void SurnameTextBox_KeyPress_1(object sender, KeyPressEventArgs e)
		{
			// Допускается ввод только букв
			// Ввод пробелов не допускается
			ReadOnlyChar(e, SurnameTextBox.Text);
			CantInputSpace(e);
		}


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
	}
}