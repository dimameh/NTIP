using System;
using System.Collections.Generic;
using LibraryCards;
using NUnit.Framework;

namespace UnitTests.LibraryCards
{
	internal class BookArticleTest
	{
		#region ConstructorTest

		[Test]
		[TestCase("Информатика", "Учебник для вузов",
			"Питер", 2012, 573, "Санкт-Петербург",
			ExpectedResult =
				"Мех, Д. А. Информатика : Учебник для вузов / Д. А. Мех, D. A. Mekh . - Санкт-Петербург : Питер, 2012. - 573 c.",
			TestName = "Тестирование конструктора без поля additionalInfo")]
		[TestCase("Информатика", "Учебник для вузов",
			"Питер", 2012, 573, "Санкт-Петербург", "Версия для российских школ",
			ExpectedResult =
				"Мех, Д. А. Информатика : Учебник для вузов / Д. А. Мех, D. A. Mekh . - Версия для российских школ. - Санкт-Петербург : Питер, 2012. - 573 c.",
			TestName = "Тестирование конструктора с полем additionalInfo")]
		[TestCase("Информатика", "Учебник для вузов",
			"Питер", 2012, 573, "Санкт-Петербург", " ",
			ExpectedResult =
				"Мех, Д. А. Информатика : Учебник для вузов / Д. А. Мех, D. A. Mekh . - Санкт-Петербург : Питер, 2012. - 573 c.",
			TestName = "Тестирование конструктора с полем additionalInfo при передаче \" \"")]
		public string ConstructorTest(string title, string materialType, string publishingHouse, int year,
			int volume, string cityOfPublication, string additionalInfo = "")
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var bookArticle = new BookCard
			(
				authors,
				title,
				materialType,
				publishingHouse,
				year,
				volume,
				cityOfPublication,
				additionalInfo
			);

			var firstPart = bookArticle.FirstAuthor.GetSurnameWithInitials() + ' ' + bookArticle.Title + " : " +
			                bookArticle.MaterialType + " / ";
			//Все авторы издания
			var allAuthors = "";
			allAuthors += bookArticle.FirstAuthor.GetInitials() + ' ' + bookArticle.FirstAuthor.Surname + ", ";
			for (var i = 1; i < bookArticle.Authors.Count - 1; i++)
				allAuthors += bookArticle.Authors[i].GetInitials() + ' ' + bookArticle.Authors[i].Surname + ", ";
			allAuthors += bookArticle.Authors[bookArticle.Authors.Count - 1].GetInitials() + ' ' +
			              bookArticle.Authors[bookArticle.Authors.Count - 1].Surname;
			allAuthors += ' ';
			//Информация о публикации
			var publicationInfo = ". - " + bookArticle.CityOfPublication + " : " + bookArticle.PublishingHouse + ", " +
			                      bookArticle.Year + ". - " + bookArticle.Volume + " c.";

			var additionalInfoTemp = "";
			if (bookArticle.AdditionalInfo != string.Empty && bookArticle.AdditionalInfo[0] != ' ' &&
			    bookArticle.AdditionalInfo[bookArticle.AdditionalInfo.Length - 1] != ' ')
				additionalInfoTemp = ". - " + bookArticle.AdditionalInfo;
			// Формат меняется в зависимости от количества авторов
			switch (bookArticle.Authors.Count)
			{
				case 1:
					return firstPart + bookArticle.FirstAuthor.GetInitials() + ' ' + bookArticle.FirstAuthor.Surname +
					       additionalInfoTemp + publicationInfo;
				case 2:
					return firstPart + allAuthors + additionalInfoTemp + publicationInfo;
				case 3:
					return firstPart + allAuthors + additionalInfoTemp + publicationInfo;
				default:
					return bookArticle.Title + " : " + bookArticle.MaterialType + " / " + allAuthors + additionalInfoTemp +
					       publicationInfo;
			}
		}

		[Test]
		[TestCase("", "Учебник для вузов", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с пустым полем title")]
		[TestCase(" ", "Учебник для вузов", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем title при передаче \" \"")]
		[TestCase(" Информатика", "Учебник для вузов", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем title, при передаче \" Информатика\"")]
		[TestCase("Информатика ", "Учебник для вузов", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем title, при передаче \"Информатика \"")]
		[TestCase("Информатика", "", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с пустым полем materialType")]
		[TestCase("Информатика", " ", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем materialType при передаче \" \"")]
		[TestCase("Информатика", " Учебник для вузов", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем materialType, при передаче \" Учебник для вузов\"")]
		[TestCase("Информатика", "Учебник для вузов ", "Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем materialType, при передаче \"Учебник для вузов \"")]
		[TestCase("Информатика", "Учебник для вузов", "", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с пустым полем publishingHouse")]
		[TestCase("Информатика", "Учебник для вузов", " ", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем publishingHouse при передаче \" \"")]
		[TestCase("Информатика", "Учебник для вузов", " Питер", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем publishingHouse, при передаче \" Питер\"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер ", 2012, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем publishingHouse, при передаче \"Питер \"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер", 0, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем year при передаче \"0\"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер", 2100, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем year при передаче \"2100\"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер", -1, 573, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем year при передаче \"-1\"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер", 2012, 0, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем volume при передаче \"0\"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер", 2012, -1, "Санкт-Петербург", TestName =
			"Тестирование конструктора с полем volume при передаче \"-1\"")]
		[TestCase("Информатика", "Учебник для вузов", "", 2012, 573, "", TestName =
			"Тестирование конструктора с пустым полем cityOfPublication")]
		[TestCase("Информатика", "Учебник для вузов", " ", 2012, 573, " ", TestName =
			"Тестирование конструктора с полем cityOfPublication при передаче \" \"")]
		[TestCase("Информатика", "Учебник для вузов", " Питер", 2012, 573, " Санкт-Петербург", TestName =
			"Тестирование конструктора с полем cityOfPublication, при передаче \" Санкт-Петербург\"")]
		[TestCase("Информатика", "Учебник для вузов", "Питер ", 2012, 573, "Санкт-Петербург ", TestName =
			"Тестирование конструктора с полем cityOfPublication, при передаче \"Санкт-Петербург \"")]
		public void ConstructorExctencionsTest(string title, string materialType, string publishingHouse, int year,
			int volume, string cityOfPublication, string additionalInfo = "")
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			Exception exception = null;
			try
			{
				var bookArticle = new BookCard
				(
					authors,
					title,
					materialType,
					publishingHouse,
					year,
					volume,
					cityOfPublication
				);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase(TestName = "Тестирование конструктора со списком авторов равным null")]
		public void Constructor_NullAuthors_ExctencionTest()
		{
			List<FullName> authors = null;
			Exception exception = null;
			try
			{
				var bookArticle = new BookCard
				(
					authors,
					"Информатика",
					"Учебник для вузов",
					"Питер",
					2012,
					573,
					"Санкт-Петербург"
				);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase(TestName = "Тестирование конструктора с пустым списком авторов")]
		public void Constructor_NoAuthors_ExctencionTest()
		{
			List<FullName> authors = new List<FullName>();
			;
			Exception exception = null;
			try
			{
				var bookArticle = new BookCard
				(
					authors,
					"Информатика",
					"Учебник для вузов",
					"Питер",
					2012,
					573,
					"Санкт-Петербург"
				);
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
			var bookArticle = new BookCard
			(
				authors,
				"Математика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);
			Exception exception = null;
			try
			{
				bookArticle.Title = title;
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
			var bookArticle = new BookCard
			(
				authors,
				"Математика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);

			bookArticle.Title = title;
			return bookArticle.Title;
		}

		#endregion

		#region YearTest

		[Test]
		[TestCase(2100, TestName = "Тестирование Year при передаче 2100.")]
		[TestCase(0, TestName = "Тестирование Year при передаче 0.")]
		[TestCase(-1, TestName = "Тестирование Year при передаче -1.")]
		[TestCase(int.MaxValue, TestName = "Тестирование Year при передаче int.MaxValue.")]
		[TestCase(2019, TestName = "Тестирование Year при передаче 2019.")]
		public void YearExceptionsTest(int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var bookArticle = new BookCard
			(
				authors,
				"Математика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);
			Exception exception = null;
			try
			{
				bookArticle.Year = year;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase(1, ExpectedResult = 1, TestName = "Тестирование Year при передаче 1.")]
		[TestCase(2, ExpectedResult = 2, TestName = "Тестирование Year при передаче 2.")]
		[TestCase(2017, ExpectedResult = 2017, TestName = "Тестирование Year при передаче 2017.")]
		[TestCase(2018, ExpectedResult = 2018, TestName = "Тестирование Year при передаче 2018.")]
		public int YearTest(int year)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var bookArticle = new BookCard
			(
				authors,
				"Математика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);

			bookArticle.Year = year;
			return bookArticle.Year;
		}

		#endregion

		#region VolumeTest

		[Test]
		[TestCase(0, TestName = "Тестирование Volume при передаче 0.")]
		[TestCase(-1, TestName = "Тестирование Volume при передаче -1.")]
		public void VolumeExceptionsTest(int volume)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var bookArticle = new BookCard
			(
				authors,
				"Математика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);
			Exception exception = null;
			try
			{
				bookArticle.Volume = volume;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase(1, ExpectedResult = 1, TestName = "Тестирование Title при передаче 1.")]
		[TestCase(2, ExpectedResult = 2, TestName = "Тестирование Title при передаче 2.")]
		[TestCase(int.MaxValue, ExpectedResult = int.MaxValue, TestName = "Тестирование Title при передаче int.MaxValue.")]
		[TestCase(int.MaxValue - 1, ExpectedResult = int.MaxValue - 1,
			TestName = "Тестирование Title при передаче int.MaxValue - 1.")]
		public int VolumeTest(int volume)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var bookArticle = new BookCard
			(
				authors,
				"Математика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);

			bookArticle.Volume = volume;
			return bookArticle.Volume;
		}

		#endregion

		#region BiblyographyInfoTest

		[Test]
		[TestCase("Информатика", "Учебник для вузов",
			"Питер", 2012, 573, "Санкт-Петербург",
			ExpectedResult =
				"Мех, Д. А. Информатика : Учебник для вузов / Д. А. Мех, D. A. Mekh . - Санкт-Петербург : Питер, 2012. - 573 c.",
			TestName = "Тестирование BiblyographyInfo без поля additionalInfo")]
		[TestCase("Информатика", "Учебник для вузов",
			"Питер", 2012, 573, "Санкт-Петербург", "Версия для российских школ",
			ExpectedResult =
				"Мех, Д. А. Информатика : Учебник для вузов / Д. А. Мех, D. A. Mekh . - Версия для российских школ. - Санкт-Петербург : Питер, 2012. - 573 c.",
			TestName = "Тестирование BiblyographyInfo с полем additionalInfo при передаче \"Версия для российских школ\"")]
		[TestCase("Информатика", "Учебник для вузов",
			"Питер", 2012, 573, "Санкт-Петербург", " ",
			ExpectedResult =
				"Мех, Д. А. Информатика : Учебник для вузов / Д. А. Мех, D. A. Mekh . - Санкт-Петербург : Питер, 2012. - 573 c.",
			TestName = "Тестирование BiblyographyInfo с полем additionalInfo при передаче \" \"")]
		public string BiblyographyInfoTest(string title, string materialType, string publishingHouse, int year,
			int volume, string cityOfPublication, string additionalInfo = "")
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var bookArticle = new BookCard
			(
				authors,
				title,
				materialType,
				publishingHouse,
				year,
				volume,
				cityOfPublication,
				additionalInfo
			);

			return bookArticle.BibliographyInfo;
		}

		[Test]
		[TestCase(TestName = "Тестирование BiblyographyInfo со статьей без авторов")]
		public void BiblyographyInfo_NoAuthors_ExctencionsTest()
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			Exception exception = null;

			var bookArticle = new BookCard
			(
				authors,
				"Информатика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург",
				"Версия для российских школ"
			);
			try
			{
				bookArticle.RemoveAllAuthors();
				var card = bookArticle.BibliographyInfo;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		#endregion
	}
}