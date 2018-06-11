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
			journalControl1.Visible = false;
			collectionControl1.Visible = false;
			dissertationControl1.Visible = false;
			bookControl1.Visible = true;
		}

		public ICard Card
		{
			get
			{
				if (BookRadioButton.Checked && bookControl1.IsFieldsFilled() && authorsControl1.Authors.Count != 0)
					return new BookArticle
					(
						authorsControl1.Authors.ToList(),
						bookControl1.Title,
						bookControl1.Genre,
						bookControl1.PublishingHouse,
						Convert.ToInt32(bookControl1.Year),
						Convert.ToInt32(bookControl1.Volume),
						bookControl1.CityOfPublication,
						bookControl1.AdditionalInfo
					);

				if (DissertationRadioButton.Checked && dissertationControl1.IsFieldsFilled() && authorsControl1.Authors.Count != 0)
					return new Dissertation
					(
						authorsControl1.Authors[0],
						dissertationControl1.Title,
						Convert.ToInt32(dissertationControl1.Page),
						dissertationControl1.ScienceDegree,
						Convert.ToInt32(dissertationControl1.Year),
						dissertationControl1.CityOfPublication,
						dissertationControl1.SpecializationNumber
					);

				if (JournalRadioButton.Checked && journalControl1.IsFieldsFilled() && authorsControl1.Authors.Count != 0)
					return new JournalArticle
					(
						authorsControl1.Authors.ToList(),
						journalControl1.Title,
						journalControl1.TitleOfPeriodical,
						Convert.ToInt32(journalControl1.JournalNumber),
						Convert.ToInt32(journalControl1.FirstPage),
						Convert.ToInt32(journalControl1.LastPage),
						Convert.ToInt32(journalControl1.Year)
					);
				if (CollectionRadioButton.Checked && collectionControl1.IsFieldsFilled() && authorsControl1.Authors.Count != 0)
					return new CollectionArticle
					(
						authorsControl1.Authors.ToList(),
						collectionControl1.Date,
						collectionControl1.Title,
						collectionControl1.ThemeOfCollection,
						Convert.ToInt32(collectionControl1.FirstPage),
						Convert.ToInt32(collectionControl1.LastPage),
						collectionControl1.City
					);
				return null;
			}
			set
			{
				if (value is BookArticle book)
				{
					BookRadioButton.Checked = true;
					bookControl1.ReadOnly = true;

					bookControl1.Title = book.Title;
					bookControl1.Genre = book.MaterialType;
					bookControl1.PublishingHouse = book.PublishingHouse;
					bookControl1.CityOfPublication = book.CityOfPublication;
					bookControl1.Year = book.Year;
					bookControl1.Volume = book.Volume;
					bookControl1.AdditionalInfo = book.AdditionalInfo;

					authorsControl1.SetAuthors(new BindingList<FullName>(book.Authors));
				}

				else if (value is Dissertation dissertation)
				{
					DissertationRadioButton.Checked = true;
					dissertationControl1.ReadOnly = true;


					dissertationControl1.Title = dissertation.Title;
					dissertationControl1.Page = dissertation.Page;
					dissertationControl1.ScienceDegree = dissertation.AuthorStatus;
					dissertationControl1.SpecializationNumber = dissertation.SpecializationNumber;
					dissertationControl1.Year = dissertation.Year;
					dissertationControl1.CityOfPublication = dissertation.CityOfPublication;

					authorsControl1.SetAuthors(new BindingList<FullName> {dissertation.FirstAuthor});
				}

				else if (value is JournalArticle journal)
				{
					JournalRadioButton.Checked = true;
					journalControl1.ReadOnly = true;

					journalControl1.Title = journal.Title;
					journalControl1.TitleOfPeriodical = journal.MaterialType;
					journalControl1.JournalNumber = journal.JournalNumber;
					journalControl1.FirstPage = journal.FirstPage;
					journalControl1.LastPage = journal.LastPage;
					journalControl1.Year = journal.Year;

					authorsControl1.SetAuthors(new BindingList<FullName>(journal.Authors));
				}

				else if (value is CollectionArticle collection)
				{
					CollectionRadioButton.Checked = true;
					collectionControl1.ReadOnly = true;

					collectionControl1.Title = collection.Title;
					collectionControl1.ThemeOfCollection = collection.MaterialType;
					collectionControl1.City = collection.CityOfPublication;
					collectionControl1.Date = collection.Date;
					collectionControl1.FirstPage = collection.FirstPage;
					collectionControl1.LastPage = collection.LastPage;

					authorsControl1.SetAuthors(new BindingList<FullName>(collection.Authors));
				}
			}
		}

		public bool ReadOnly
		{
			set
			{
				authorsControl1.ReadOnly = value;
				journalControl1.ReadOnly = value;
				collectionControl1.ReadOnly = value;
				dissertationControl1.ReadOnly = value;
				bookControl1.ReadOnly = value;
			}
		}

		private void BookRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl1.Visible = false;
			collectionControl1.Visible = false;
			dissertationControl1.Visible = false;
			bookControl1.Visible = true;
		}

		private void DissertationRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl1.Visible = false;
			collectionControl1.Visible = false;
			dissertationControl1.Visible = true;
			bookControl1.Visible = false;
		}

		private void JournalRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl1.Visible = true;
			collectionControl1.Visible = false;
			dissertationControl1.Visible = false;
			bookControl1.Visible = false;
		}

		private void CollectionRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			journalControl1.Visible = false;
			collectionControl1.Visible = true;
			dissertationControl1.Visible = false;
			bookControl1.Visible = false;
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
					bookControl1.Title = "Book";
					bookControl1.Genre = "Genre";
					bookControl1.PublishingHouse = "Publishing house";
					bookControl1.CityOfPublication = "City";
					bookControl1.Year = 2018;
					bookControl1.Volume = 222;
					bookControl1.AdditionalInfo = "";
					authorsControl1.SetAuthors(bookAuthors);
					break;
				case 2:
					var dissertationAuthors = new BindingList<FullName> {NameRandomizer.GenerateFullName()};
					DissertationRadioButton.Checked = true;
					dissertationControl1.Title = "Dissertation";
					dissertationControl1.Page = 222;
					dissertationControl1.ScienceDegree = "Author status";
					dissertationControl1.SpecializationNumber = "000000";
					dissertationControl1.Year = 2017;
					dissertationControl1.CityOfPublication = "City";
					authorsControl1.SetAuthors(dissertationAuthors);
					break;
				case 3:
					var journalAuthors =
						new BindingList<FullName> {NameRandomizer.GenerateFullName(), NameRandomizer.GenerateFullName()};
					JournalRadioButton.Checked = true;
					journalControl1.Title = "Journal";
					journalControl1.TitleOfPeriodical = "Title  of periodical";
					journalControl1.FirstPage = 111;
					journalControl1.LastPage = 222;
					journalControl1.JournalNumber = 333;
					journalControl1.Year = 2016;
					authorsControl1.SetAuthors(journalAuthors);
					break;
				default:
					var collectionAuthors =
						new BindingList<FullName> {NameRandomizer.GenerateFullName(), NameRandomizer.GenerateFullName()};
					CollectionRadioButton.Checked = true;
					collectionControl1.Title = "Collection";
					collectionControl1.ThemeOfCollection = "Theme of collection";
					collectionControl1.City = "City";
					collectionControl1.Date = new DateTime(1998,8,27);
					collectionControl1.FirstPage = 222;
					collectionControl1.LastPage = 333;
					authorsControl1.SetAuthors(collectionAuthors);
					break;
			}
		}
	}
}