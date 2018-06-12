using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using LibraryCards;

namespace CardListApp
{
	public partial class AddRecordForm : Form
	{
		public AddRecordForm()
		{
			InitializeComponent();

#if !DEBUG
			RandomButton.Visible = false;
#endif
			ReadOnly = false;
			journalControl.Visible = false;
			collectionControl.Visible = false;
			dissertationControl.Visible = false;
			bookControl.Visible = true;
		}

		public ICard Card
		{
			get
			{
				if (BookRadioButton.Checked && bookControl.IsFieldsFilled() && authorsControl.Authors.Count != 0)
					return new BookCard
					(
						authorsControl.Authors.ToList(),
						bookControl.Title,
						bookControl.Genre,
						bookControl.PublishingHouse,
						Convert.ToInt32(bookControl.Year),
						Convert.ToInt32(bookControl.Volume),
						bookControl.CityOfPublication,
						bookControl.AdditionalInfo
					);

				if (DissertationRadioButton.Checked && dissertationControl.IsFieldsFilled() && authorsControl.Authors.Count != 0)
					return new DissertationCard
					(
						authorsControl.Authors[0],
						dissertationControl.Title,
						Convert.ToInt32(dissertationControl.Page),
						dissertationControl.ScienceDegree,
						Convert.ToInt32(dissertationControl.Year),
						dissertationControl.CityOfPublication,
						dissertationControl.SpecializationNumber
					);

				if (JournalRadioButton.Checked && journalControl.IsFieldsFilled() && authorsControl.Authors.Count != 0)
					return new JournalCard
					(
						authorsControl.Authors.ToList(),
						journalControl.Title,
						journalControl.TitleOfPeriodical,
						Convert.ToInt32(journalControl.JournalNumber),
						Convert.ToInt32(journalControl.FirstPage),
						Convert.ToInt32(journalControl.LastPage),
						Convert.ToInt32(journalControl.Year)
					);
				if (CollectionRadioButton.Checked && collectionControl.IsFieldsFilled() && authorsControl.Authors.Count != 0)
					return new CollectionCard
					(
						authorsControl.Authors.ToList(),
						collectionControl.Date,
						collectionControl.Title,
						collectionControl.ThemeOfCollection,
						Convert.ToInt32(collectionControl.FirstPage),
						Convert.ToInt32(collectionControl.LastPage),
						collectionControl.City
					);
				return null;
			}
			set
			{
				if (value is BookCard book)
				{
					BookRadioButton.Checked = true;
					bookControl.ReadOnly = true;

					bookControl.Title = book.Title;
					bookControl.Genre = book.MaterialType;
					bookControl.PublishingHouse = book.PublishingHouse;
					bookControl.CityOfPublication = book.CityOfPublication;
					bookControl.Year = book.Year;
					bookControl.Volume = book.Volume;
					bookControl.AdditionalInfo = book.AdditionalInfo;

					authorsControl.SetAuthors(new BindingList<FullName>(book.Authors));
				}

				else if (value is DissertationCard dissertation)
				{
					DissertationRadioButton.Checked = true;
					dissertationControl.ReadOnly = true;


					dissertationControl.Title = dissertation.Title;
					dissertationControl.Page = dissertation.Page;
					dissertationControl.ScienceDegree = dissertation.AuthorStatus;
					dissertationControl.SpecializationNumber = dissertation.SpecializationNumber;
					dissertationControl.Year = dissertation.Year;
					dissertationControl.CityOfPublication = dissertation.CityOfPublication;

					authorsControl.SetAuthors(new BindingList<FullName> {dissertation.FirstAuthor});
				}

				else if (value is JournalCard journal)
				{
					JournalRadioButton.Checked = true;
					journalControl.ReadOnly = true;

					journalControl.Title = journal.Title;
					journalControl.TitleOfPeriodical = journal.MaterialType;
					journalControl.JournalNumber = journal.JournalNumber;
					journalControl.FirstPage = journal.FirstPage;
					journalControl.LastPage = journal.LastPage;
					journalControl.Year = journal.Year;

					authorsControl.SetAuthors(new BindingList<FullName>(journal.Authors));
				}

				else if (value is CollectionCard collection)
				{
					CollectionRadioButton.Checked = true;
					collectionControl.ReadOnly = true;

					collectionControl.Title = collection.Title;
					collectionControl.ThemeOfCollection = collection.MaterialType;
					collectionControl.City = collection.CityOfPublication;
					collectionControl.Date = collection.Date;
					collectionControl.FirstPage = collection.FirstPage;
					collectionControl.LastPage = collection.LastPage;

					authorsControl.SetAuthors(new BindingList<FullName>(collection.Authors));
				}
			}
		}

		public bool ReadOnly
		{
			set
			{
				authorsControl.ReadOnly = value;
				journalControl.ReadOnly = value;
				collectionControl.ReadOnly = value;
				dissertationControl.ReadOnly = value;
				bookControl.ReadOnly = value;
			}
		}

		private void BookRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl.Visible = false;
			collectionControl.Visible = false;
			dissertationControl.Visible = false;
			bookControl.Visible = true;
		}

		private void DissertationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl.Visible = false;
			collectionControl.Visible = false;
			dissertationControl.Visible = true;
			bookControl.Visible = false;
		}

		private void JournalRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl.Visible = true;
			collectionControl.Visible = false;
			dissertationControl.Visible = false;
			bookControl.Visible = false;
		}

		private void CollectionRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl.Visible = false;
			collectionControl.Visible = true;
			dissertationControl.Visible = false;
			bookControl.Visible = false;
		}

		private void RandomButton_Click(object sender, EventArgs e)
		{
			var rnd = new Random();
			// Вынеси генератор в отдельный класс и используй где хочешь
			switch (rnd.Next(1, 5))
			{
				case 1:
					var bookAuthors = new BindingList<FullName> {NameRandomizer.GenerateFullName(), NameRandomizer.GenerateFullName()};
					BookRadioButton.Checked = true;
					bookControl.Title = "Book";
					bookControl.Genre = "Genre";
					bookControl.PublishingHouse = "Publishing house";
					bookControl.CityOfPublication = "City";
					bookControl.Year = 2018;
					bookControl.Volume = 222;
					bookControl.AdditionalInfo = "";
					authorsControl.SetAuthors(bookAuthors);
					break;
				case 2:
					var dissertationAuthors = new BindingList<FullName> {NameRandomizer.GenerateFullName()};
					DissertationRadioButton.Checked = true;
					dissertationControl.Title = "Dissertation";
					dissertationControl.Page = 222;
					dissertationControl.ScienceDegree = "Author status";
					dissertationControl.SpecializationNumber = "000000";
					dissertationControl.Year = 2017;
					dissertationControl.CityOfPublication = "City";
					authorsControl.SetAuthors(dissertationAuthors);
					break;
				case 3:
					var journalAuthors =
						new BindingList<FullName> {NameRandomizer.GenerateFullName(), NameRandomizer.GenerateFullName()};
					JournalRadioButton.Checked = true;
					journalControl.Title = "Journal";
					journalControl.TitleOfPeriodical = "Title  of periodical";
					journalControl.FirstPage = 111;
					journalControl.LastPage = 222;
					journalControl.JournalNumber = 333;
					journalControl.Year = 2016;
					authorsControl.SetAuthors(journalAuthors);
					break;
				default:
					var collectionAuthors =
						new BindingList<FullName> {NameRandomizer.GenerateFullName(), NameRandomizer.GenerateFullName()};
					CollectionRadioButton.Checked = true;
					collectionControl.Title = "Collection";
					collectionControl.ThemeOfCollection = "Theme of collection";
					collectionControl.City = "City";
					collectionControl.Date = new DateTime(1998,8,27);
					collectionControl.FirstPage = 222;
					collectionControl.LastPage = 333;
					authorsControl.SetAuthors(collectionAuthors);
					break;
			}
		}
	}
}