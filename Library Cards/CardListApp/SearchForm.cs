using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class SearchForm : Form
	{
		public SearchForm(BindingList<ICard> mainList)
		{
			InitializeComponent();
			ShowHint();

			_resultList = mainList;
			_searchList = new BindingList<ICard>();
		}

		/// <summary>
		///     Возвращает копию Результирующего списка карточек
		/// </summary>
		public BindingList<ICard> ResultList
		{
			get
			{
				var cardListCopy = new BindingList<ICard>(_resultList);
				return cardListCopy;
			}
		}

		#region Private properties

		/// <summary>
		///     Список, являющийся результатом действий после поиска
		///     Результирующий список
		/// </summary>
		private readonly BindingList<ICard> _resultList;

		/// <summary>
		///     Список, являющийся результатом поиска
		///     Результирующий список
		/// </summary>
		private readonly BindingList<ICard> _searchList;

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
			_searchList.Clear();

			// поиск записи в Главной таблице
			foreach (var card in _resultList)
				// поиск только по Автору
				if (AuthorTextBox.Text == string.Empty && TitleTextBox.Text != string.Empty)
				{
					if (card.Title == TitleTextBox.Text) _searchList.Add(card);
				}
				// поиск только по Названию
				else if (AuthorTextBox.Text != string.Empty && TitleTextBox.Text == string.Empty)
				{
					if (card.FirstAuthor.ToString() == AuthorTextBox.Text) _searchList.Add(card);
				}
				// поиск по Автору и Названию
				else if (AuthorTextBox.Text != string.Empty && TitleTextBox.Text != string.Empty)
				{
					if (card.Title == TitleTextBox.Text && card.FirstAuthor.ToString() == AuthorTextBox.Text) _searchList.Add(card);
				}
				else
				{
					MessageBox.Show("Fill at least one field", "SearchForm error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}

			//обновление Результирующей таблицы
			dataGridView.DataSource = _searchList;

			// если поле автора не было заполнено, вывести подсказку
			if (AuthorTextBox.Text == string.Empty) ShowHint();
		}

		/// <summary>
		///     Удаляет выбранную запись из Результатирующего и Главного списка
		/// </summary>
		private void RemoveButton_Click(object sender, EventArgs e)
		{
			if (dataGridView.CurrentRow != null)
			{
				//поиск выбранной записи в списке Поиска и передача ее в метод удаление карточек из Результирующего списка
				foreach (var card in _searchList)
					if (card.BibliographyInfo == (string) dataGridView["BibliographyInfo", dataGridView.CurrentCell.RowIndex].Value)
						_resultList.Remove(card);

				//удаление карточки из таблицы Поиска
				dataGridView.Rows.Remove(dataGridView.CurrentRow);

				//обновление Результирующей таблицы
				dataGridView.DataSource = _searchList;
			}
			else
			{
				MessageBox.Show("Select record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion
	}
}