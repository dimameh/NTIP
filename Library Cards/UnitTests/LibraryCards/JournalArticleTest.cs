using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCards;
using NUnit.Framework;

namespace UnitTests.LibraryCards
{
	class JournalArticleTest
	{
		#region ConstructorTest

		[Test]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
			"Пищевая промышленность", 8, 17, 19, 2014,
			ExpectedResult =
				"Мех, Д. А. Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода / Д. А. Мех, D. A. Mekh  // Пищевая промышленность. - 2014. - №8. - C. 17 19.",
			TestName = "Тестирование конструктора")]
		public string ConstructorTest(string title, string materialType, int journalNumber, int firstPage,
			int lastPage, int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				title,
				materialType,
				journalNumber,
				firstPage,
				lastPage,
				year
			);

			var allAuthors = "";
			allAuthors += journal.FirstAuthor.GetInitials() + ' ' + journal.FirstAuthor.Surname + ", ";
			for (var i = 1; i < journal.Authors.Count - 1; i++) allAuthors += journal.Authors[i].GetInitials() + ' ' + journal.Authors[i].Surname + ", ";
			allAuthors += journal.Authors[journal.Authors.Count - 1].GetInitials() + ' ' + journal.Authors[journal.Authors.Count - 1].Surname;
			allAuthors += ' ';
			//Первая часть карточки, один автор, название и тип материала
			FullName tempQualifier = journal.FirstAuthor;
			var firstPart = tempQualifier.Surname + ", " + tempQualifier.Name[0] + ". " + tempQualifier.Patronymic[0] + '.' + ' ' + journal.Title + " / " + allAuthors + " // ";

			//Информация о публикации
			var publicationInfo = journal.MaterialType + ". - " + journal.Year + ". - №" + journal.JournalNumber + ". - C. " + journal.FirstPage + ' ' +
			                      journal.LastPage + '.';
			//Генерация нужной строки

			return firstPart + publicationInfo;
		}

		[Test]
		[TestCase("", "Пищевая промышленность", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем Title, при передаче \"\"")]
		[TestCase(" ", "Пищевая промышленность", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем Title, при передаче \" \"")]
		[TestCase(" Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем Title, при передаче \" Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода ", "Пищевая промышленность", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем Title, при передаче \"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода \"")]

		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем MaterialType, при передаче \"\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", " ", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем MaterialType, при передаче \" \"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", " Пищевая промышленность", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем MaterialType, при передаче \" Пищевая промышленность\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность ", 8, 17, 19, 2014, TestName = "Тестирование конструктора с полем MaterialType, при передаче \"Пищевая промышленность \"")]

		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", -1, 17, 19, 2014, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"-1\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", -2, 17, 19, 2014, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"-2\"")]

		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 0, 19, 2014, TestName = "Тестирование конструктора с полем FirstPage, при передаче \"0\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, -1, 19, 2014, TestName = "Тестирование конструктора с полем FirstPage, при передаче \"-1\"")]

		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, 0, 2014, TestName = "Тестирование конструктора с полем LastPage, при передаче \"0\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, -1, 2014, TestName = "Тестирование конструктора с полем LastPage, при передаче \"-1\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, 16, 2014, TestName = "Тестирование конструктора с полем LastPage, при передаче \"16\"")]

		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, 19, 0, TestName = "Тестирование конструктора с полем Year, при передаче \"0\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, 19, -1, TestName = "Тестирование конструктора с полем Year, при передаче \"-1\"")]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода", "Пищевая промышленность", 8, 17, 19, 2100, TestName = "Тестирование конструктора с полем Year, при передаче \"2100\"")]
		public void ConstructorExceptionsTest(string title, string materialType, int journalNumber, int firstPage,
			int lastPage, int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};

			Exception exception = null;
			try
			{
				var journal = new JournalArticle
				(
					authors,
					title,
					materialType,
					journalNumber,
					firstPage,
					lastPage,
					year
				);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		#endregion

		#region YearTest

		[Test]
		[TestCase(1, ExpectedResult = 1, TestName = "Тестирование Year, при передаче \"1\"")]
		[TestCase(2, ExpectedResult = 2, TestName = "Тестирование Year, при передаче \"2\"")]
		[TestCase(2017, ExpectedResult = 2017, TestName = "Тестирование Year, при передаче \"2017\"")]
		[TestCase(2018, ExpectedResult = 2018, TestName = "Тестирование Year, при передаче \"2018\"")]
		public int YearTest(int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
				"Пищевая промышленность",
				8,
				17,
				19,
				2014
			);

			journal.Year = year;
			return journal.Year;
		}

		[TestCase(0, TestName = "Тестирование Year, при передаче \"0\"")]
		[TestCase(-1, TestName = "Тестирование Year, при передаче \"-1\"")]
		[TestCase(2100, TestName = "Тестирование Year, при передаче \"2100\"")]
		[TestCase(2019, TestName = "Тестирование Year, при передаче \"2019\"")]
		[TestCase(int.MaxValue, TestName = "Тестирование Year, при передаче \"int.MaxValue\"")]
		public void YearExceptionsTest(int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
				"Пищевая промышленность",
				8,
				17,
				19,
				2014
			);
			Exception exception = null;
			try
			{
				journal.Year = year;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}


		#endregion

		#region JournalNumberTest

		[Test]
		[TestCase(0, ExpectedResult = 0, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"0\"")]
		[TestCase(1, ExpectedResult = 1, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"1\"")]
		[TestCase(int.MaxValue, ExpectedResult = int.MaxValue, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"int.MaxValue\"")]
		[TestCase(int.MaxValue - 1, ExpectedResult = int.MaxValue - 1, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"int.MaxValue - 1\"")]
		public int JournalNumberTest(int journalNumber)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
				"Пищевая промышленность",
				8,
				17,
				19,
				2014
			);

			journal.JournalNumber = journalNumber;
			return journal.JournalNumber;
		}

		[Test]
		[TestCase(-1, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"0\"")]
		[TestCase(-2, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"1\"")]
		[TestCase(int.MinValue, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"int.MinValue\"")]
		[TestCase(int.MinValue + 1, TestName = "Тестирование конструктора с полем JournalNumber, при передаче \"int.MinValue + 1\"")]
		public void JournalNumberExceptionsTest(int journalNumber)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
				"Пищевая промышленность",
				8,
				17,
				19,
				2014
			);
			Exception exception = null;
			try
			{
				journal.JournalNumber = journalNumber;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}
		#endregion

		#region TitleTest

		[Test]
		[TestCase(" ", TestName = "Тестирование Title при передаче \" \".")]
		[TestCase("", TestName = "Тестирование Title при передаче \"\".")]
		[TestCase(" Энерго- и ресурсосбережение - XXI век", TestName =
			"Тестирование Title при передаче \" Энерго- и ресурсосбережение - XXI век\".")]
		[TestCase("Энерго- и ресурсосбережение - XXI век ", TestName =
			"Тестирование Title при передаче \"Энерго- и ресурсосбережение - XXI век \".")]
		public void TitleExceptionsTest(string title)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
				"Пищевая промышленность",
				8,
				17,
				19,
				2014
			);
			Exception exception = null;
			try
			{
				journal.Title = title;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("Энерго- и ресурсосбережение - XXI век", ExpectedResult = "Энерго- и ресурсосбережение - XXI век",
			TestName = "Тестирование Title при передаче \"Энерго- и ресурсосбережение - XXI век\".")]
		public string TitleTest(string title)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				"Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
				"Пищевая промышленность",
				8,
				17,
				19,
				2014
			);

			journal.Title = title;
			return journal.Title;
		}

		#endregion

		#region BiblyographyInfoTest

		[Test]
		[TestCase("Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода",
			"Пищевая промышленность", 8, 17, 19, 2014,
			ExpectedResult =
				"Мех, Д. А. Глубокая переработка отходов виноделия с применением экстракции диоксидом углерода / Д. А. Мех, D. A. Mekh  // Пищевая промышленность. - 2014. - №8. - C. 17 19.",
			TestName = "Тестирование конструктора")]
		public string BiblyographyInfoTest(string title, string materialType, int journalNumber, int firstPage,
			int lastPage, int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var journal = new JournalArticle
			(
				authors,
				title,
				materialType,
				journalNumber,
				firstPage,
				lastPage,
				year
			);

			return journal.BibliographyInfo;
		}
	
		#endregion
	}
}
