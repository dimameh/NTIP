using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LibraryCards;

namespace WindowsFormsApp1
{
	public partial class Search : Form
	{
		public Search(MainWindow parentForm)
		{
			InitializeComponent();
			_parent = parentForm;

			ShowHint();

			_resultList = new BindingList<ICard>();
		}

		#region Private properties

		/// <summary>
		///     Форма предок
		/// </summary>
		private readonly MainWindow _parent;

		/// <summary>
		///     Список, являющийся результатом поиска
		///     Результирующий список
		/// </summary>
		private readonly BindingList<ICard> _resultList;

		/// <summary>
		///     Возвращает true, если подсказка формата ввода ФИО открыта, false в других случаях
		/// </summary>
		private bool _isHint = true;

		#endregion

		#region Frontand changing methods

		/// <summary>
		///     Показать подсказку формата ввода ФИО
		/// </summary>
		private void ShowHint()
		{
			//подсказка высвечивается только если поле пустое
			if (AuthorTextBox.Text == string.Empty)
			{
				AuthorTextBox.Text = "Surname Name Patronymic";
				AuthorTextBox.ForeColor = Color.Gray;
				_isHint = true;
			}
		}

		/// <summary>
		///     Скрыть подсказку формата ввода ФИО
		/// </summary>
		private void HideHint()
		{
			if (_isHint)
			{
				AuthorTextBox.Text = null;
				AuthorTextBox.ForeColor = Color.Black;
				_isHint = false;
			}
		}

		#endregion

		#region Fields actions

		/// <summary>
		///     Скрывает подсказку при выборе формы ввода автора
		/// </summary>
		private void AuthorTextBox_Enter(object sender, EventArgs e)
		{
			HideHint();
		}

		/// <summary>
		///     Выводит подсказку при выходе из формы ввода автора
		/// </summary>
		private void AuthorTextBox_Leave(object sender, EventArgs e)
		{
			ShowHint();
		}

		#endregion

		#region Click events

		/// <summary>
		///     Выполняет поиск в Главной таблице по данным одного из полей, либо сразу двух.
		///     При нахождении полей, выводит их в Результирующую таблицу
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			// если нужно, убираем подсказку, чтобы поле не использовалось как заполненное
			if (_isHint) HideHint();
			_resultList.Clear();

			// поиск записи в Главной таблице
			foreach (var card in _parent.DataList)
				// поиск только по Автору
				if (AuthorTextBox.Text == string.Empty && TitleTextBox.Text != string.Empty)
				{
					if (card.Title == TitleTextBox.Text) _resultList.Add(card);
				}
				// поиск только по Названию
				else if (AuthorTextBox.Text != string.Empty && TitleTextBox.Text == string.Empty)
				{
					if (card.FirstAuthor.ToString() == AuthorTextBox.Text) _resultList.Add(card);
				}
				// поиск по Автору и Названию
				else if (AuthorTextBox.Text != string.Empty && TitleTextBox.Text != string.Empty)
				{
					if (card.Title == TitleTextBox.Text && card.FirstAuthor.ToString() == AuthorTextBox.Text) _resultList.Add(card);
				}
				else
				{
					MessageBox.Show("Fill at least one field", "Search error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			//обновление Результирующей таблицы
			dataGridView1.DataSource = null;
			dataGridView1.DataSource = _resultList;

			// если поле автора не было заполнено, вывести подсказку
			if (AuthorTextBox.Text == string.Empty) ShowHint();
		}

		/// <summary>
		///     Удаляет выбранную запись из Результатирующего и Главного списка
		/// </summary>
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			if (dataGridView1.CurrentRow != null)
			{
				//поиск выбранной записи в Результирующем списке и передача ее в метод удаления карточек из Главной таблицы
				foreach (var card in _resultList)
					if (card.BibliographyInfo == (string) dataGridView1["BibliographyInfo", dataGridView1.CurrentCell.RowIndex].Value)
						_parent.RemoveCard(card);

				//удаление карточки из Результирующей таблицы
				dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

				//обновление Результирующей таблицы
				dataGridView1.DataSource = null;
				dataGridView1.DataSource = _resultList;
			}
			else
			{
				MessageBox.Show("Select record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion
	}
}