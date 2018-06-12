using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
			_cardList = new BindingList<ICard>();
			RenameForm();
			DisableControls();
		}

		#region Frontand changing methods

		/// <summary>
		///     Переименовать форму (Используется при сохранении или открытии файла)
		/// </summary>
		private void RenameForm()
		{
			Text = _currentFileName + " - Library Cards";
		}

		private void DisableControls()
		{
			bookControl1.Visible = false;
			journalControl1.Visible = false;
			dissertationControl1.Visible = false;
			collectionControl1.Visible = false;

			bookControl1.ReadOnly = true;
			journalControl1.ReadOnly = true;
			dissertationControl1.ReadOnly = true;
			collectionControl1.ReadOnly = true;
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

		#endregion

		#region Click events

		#region Form openers

		/// <summary>
		///     Открытие окна с формой добавления новой карточки
		/// </summary>
		private void AddButtonClick(object sender, EventArgs e)
		{
			DisableControls();
			var newRecordForm = new AddRecordForm
			{
				ReadOnly = false
			};
			newRecordForm.ShowDialog();
			if (newRecordForm.DialogResult == DialogResult.OK)
			{
				try
				{
					if (newRecordForm.Card != null)
					{

						if (!IsInTable(newRecordForm.Card))
						{
							_cardList.Add(newRecordForm.Card);
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
				catch (Exception exception)
				{
					MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK,
						MessageBoxIcon.Error);
					newRecordForm.DialogResult = DialogResult.Cancel;
				}
			}
		}

		/// <summary>
		///     Открытие окна с формой поиска карточек
		/// </summary>
		private void SearchButton_Click(object sender, EventArgs e)
		{
			DisableControls();
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
			DisableControls();
			if (dataGridViewMain.CurrentRow != null)
			{
				var newModifyForm = new AddRecordForm
				{
					Card = _cardList[dataGridViewMain.CurrentRow.Index],
					ReadOnly = false
				};

				newModifyForm.ShowDialog();

				if (newModifyForm.DialogResult == DialogResult.OK)
				{
					if (newModifyForm.Card != null)
						_cardList[dataGridViewMain.CurrentRow.Index] = newModifyForm.Card;
					else
						MessageBox.Show("You cant add empty record", "Error", MessageBoxButtons.OK,
							MessageBoxIcon.Error);
				}
			}
		}

		#endregion

		#region Save/Open

		/// <summary>
		///     Окно сохранения данных таблицы
		/// </summary>
		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//сериализация данных в файл JSon сериализацией
			if (saveFileDialog.ShowDialog() == DialogResult.OK) Serialization.Save(saveFileDialog.FileName, _cardList);
		}

		/// <summary>
		///     Окно открытия файла сохранения данных таблицы
		/// </summary>
		private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Открытие выбранного файла сериализатором
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				_cardList.Clear();

				_currentFileName = Path.GetFileName(openFileDialog.SafeFileName);
				RenameForm();

				if (openFileDialog.SafeFileName != null) _cardList = Serialization.Read(openFileDialog.FileName);

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
			{
				dataGridViewMain.Rows.Remove(dataGridViewMain.CurrentRow);
				DisableControls();
				dataGridViewAuthors.DataSource = null;
			}
		}

		/// <summary>
		///     Выводит информацию о карточке при клике на нее в таблице
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			var currentCard = _cardList[dataGridViewMain.CurrentRow.Index];
			DisableControls();
			
			if (currentCard is BookCard book)
			{
				bookControl1.Visible = true;

				bookControl1.Title = book.Title;
				bookControl1.Genre = book.MaterialType;
				bookControl1.PublishingHouse = book.PublishingHouse;
				bookControl1.CityOfPublication = book.CityOfPublication;
				bookControl1.Year = book.Year;
				bookControl1.Volume = book.Volume;
				bookControl1.AdditionalInfo = book.AdditionalInfo;

				dataGridViewAuthors.DataSource = book.Authors;
			}

			else if (currentCard is DissertationCard dissertation)
			{
				dissertationControl1.Visible = true;

				dissertationControl1.Title = dissertation.Title;
				dissertationControl1.Page = dissertation.Page;
				dissertationControl1.ScienceDegree = dissertation.AuthorStatus;
				dissertationControl1.SpecializationNumber = dissertation.SpecializationNumber;
				dissertationControl1.Year = dissertation.Year;
				dissertationControl1.CityOfPublication = dissertation.CityOfPublication;

				var dissertationAuthor = new List<FullName>();
				dissertationAuthor.Add(dissertation.FirstAuthor);
				dataGridViewAuthors.DataSource = dissertationAuthor;
			}

			else if (currentCard is JournalCard journal)
			{
				journalControl1.Visible = true;
				
				journalControl1.Title = journal.Title;
				journalControl1.TitleOfPeriodical = journal.MaterialType;
				journalControl1.JournalNumber = journal.JournalNumber;
				journalControl1.FirstPage = journal.FirstPage;
				journalControl1.LastPage = journal.LastPage;
				journalControl1.Year = journal.Year;

				dataGridViewAuthors.DataSource = journal.Authors;
			}

			else if (currentCard is CollectionCard collection)
			{
				collectionControl1.Visible = true;

				collectionControl1.Title = collection.Title;
				collectionControl1.ThemeOfCollection = collection.MaterialType;
				collectionControl1.City = collection.CityOfPublication;
				collectionControl1.Date = collection.Date;
				collectionControl1.FirstPage = collection.FirstPage;
				collectionControl1.LastPage = collection.LastPage;

				dataGridViewAuthors.DataSource = collection.Authors;
			}
		}

		#endregion
	}
}