using System;
using System.Collections.Generic;
using LibraryCards;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace UnitTests.LibraryCards
{
    internal class ArticleInCollectionTest
	{
		#region ConstructorTest

		[Test]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			ExpectedResult =
				"Мех, Д. А. Энерго- и ресурсосбережение - XXI век / Д. А. Мех, D. A. Mekh  // материалы XI международной научно-практической интернет-конференции, 30 июня 2013 г., г. Орел. - Орел, 2013. - C. 237-239.",
			TestName = "Тестирование конструктора")]
		public string ConstructorTest(DateTime date, string title, string materialType, int firstPage, int lastPage,
			string cityOfPublication)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				date,
				title,
				materialType,
				firstPage,
				lastPage,
				cityOfPublication
			);

			var allAuthors = "";
			allAuthors += article.FirstAuthor.GetInitials() + ' ' + article.FirstAuthor.Surname + ", ";
			for (var i = 1; i < article.Authors.Count - 1; i++)
				allAuthors += article.Authors[i].GetInitials() + ' ' + article.Authors[i].Surname + ", ";
			allAuthors += article.Authors[article.Authors.Count - 1].GetInitials() + ' ' +
			              article.Authors[article.Authors.Count - 1].Surname;
			allAuthors += ' ';
			//Первая часть карточки, один автор, название и тип материала
			var firstPart = article.FirstAuthor.GetSurnameWithInitials() + ' ' + article.Title + " / " + allAuthors + " // ";

			//Информация о публикации
			var publicationInfo = article.MaterialType + ", " + article.Date.ToLongDateString() + ", г. " +
			                      article.CityOfPublication + ". - " +
			                      article.CityOfPublication + ", " + article.Date.Year + ". - C. " + article.FirstPage + '-' +
			                      article.LastPage + '.';
			//Генерация нужной строки

			return firstPart + publicationInfo;
		}

		[Test]
		[TestCase("2013/06/30", "",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			TestName = "Тестирование конструктора c пустым названием")]
		[TestCase("2013/06/30", " ",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			TestName = "Тестирование конструктора c полем Title при передаче \" \"")]
		[TestCase("2013/06/30", " Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			TestName = "Тестирование конструктора c полем Title при передаче \" Энерго- и ресурсосбережение - XXI век\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век ",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			TestName = "Тестирование конструктора c полем Title,  при передаче \"Энерго- и ресурсосбережение - XXI век \"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"", 237, 239, "Орел",
			TestName = "Тестирование конструктора c пустым полем MaterialType")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			" ", 237, 239, "Орел",
			TestName = "Тестирование конструктора c полем MaterialType при передаче \" \"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			" материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			TestName =
				"Тестирование конструктора c полем MaterialType, при передаче \" материалы XI международной научно-практической интернет-конференции\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции ", 237, 239, "Орел",
			TestName =
				"Тестирование конструктора c полем MaterialType,  при передаче \"материалы XI международной научно-практической интернет-конференции \"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", -1, 239, "Орел",
			TestName = "Тестирование конструктора c полем FirstPage при передаче \"-1\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 0, 239, "Орел",
			TestName = "Тестирование конструктора c полем FirstPage при передаче \"0\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, -1, "Орел",
			TestName = "Тестирование конструктора c полем LastPage при передаче \"-1\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 0, "Орел",
			TestName = "Тестирование конструктора c полем LastPage при передаче \"0\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 236, "Орел",
			TestName =
				"Тестирование конструктора c допустимым полем LastPage, но меньшим чем поле FirstPage  при передаче \"237 и 236\"")]
		[TestCase("2013/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "орел",
			TestName = "Тестирование конструктора c полем City которое не является именем собственным, \"орел\"")]
		[TestCase("2100/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			TestName = "Тестирование конструктора c полем Date с датой, которая еще не наступила \"2100/06/30\"")]
		public void ConstructorExceptionTest(DateTime date, string title, string materialType, int firstPage, int lastPage,
			string cityOfPublication)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			Assert.Throws<Exception>(
				delegate
				{
					new CollectionCard
					(
						authors,
						date,
						title,
						materialType,
						firstPage,
						lastPage,
						cityOfPublication
					);
				});
		}

		[Test]
		[TestCase(TestName = "Тестирование конструктора со списком авторов равным null")]
		public void Constructor_NullAuthors_ExceptionTest()
		{
			List<FullName> authors = null;

			Exception exception = null;
			try
			{
				var article = new CollectionCard
				(
					authors,
					new DateTime(2013, 06, 30),
					"Энерго- и ресурсосбережение – XXI век",
					"материалы XI международной научно-практической интернет-конференции",
					237,
					239,
					"Орел"
				);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[TestCase(TestName = "Тестирование конструктора с пустым списком авторов")]
		public void Constructor_NoAuthors_ExceptionTest()
		{
			List<FullName> authors = new List<FullName>();

			Exception exception = null;
			try
			{
				var article = new CollectionCard
				(
					authors,
					new DateTime(2013, 06, 30),
					"Энерго- и ресурсосбережение – XXI век",
					"материалы XI международной научно-практической интернет-конференции",
					237,
					239,
					"Орел"
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
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);
			Assert.Throws<Exception>(
				delegate
				{
					article.Title = title;
				});
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
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);

			article.Title = title;
			return article.Title;
		}

		#endregion

		#region FirstPageTest

		[Test]
		[TestCase(-1, TestName = "Тестирование FirstPage при передаче \"-1\".")]
		[TestCase(0, TestName = "Тестирование FirstPage при передаче \"0\".")]
		[TestCase(int.MinValue, TestName = "Тестирование FirstPage при передаче \"int.MinValue\".")]
		[TestCase(int.MinValue + 1, TestName = "Тестирование FirstPage при передаче \"int.MinValue + 1\".")]
		public void FirstPageExceptionsTest(int firstPage)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);
			Exception exception = null;
			try
			{
				article.FirstPage = firstPage;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase(1, ExpectedResult = 1, TestName = "Тестирование FirstPage при передаче \"1\".")]
		[TestCase(2, ExpectedResult = 2, TestName = "Тестирование FirstPage при передаче \"2\".")]
		[TestCase(int.MaxValue, ExpectedResult = int.MaxValue,
			TestName = "Тестирование FirstPage при передаче \"int.MaxValue\".")]
		[TestCase(int.MaxValue - 1, ExpectedResult = int.MaxValue - 1,
			TestName = "Тестирование FirstPage при передаче \"int.MaxValue-1\".")]
		[TestCase(100, ExpectedResult = 100, TestName = "Тестирование FirstPage при передаче \"100\".")]
		public int FirstPageTest(int firstPage)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);

			article.FirstPage = firstPage;
			return article.FirstPage;
		}

		#endregion

		#region LastPageTest

		[Test]
		[TestCase(-1, TestName = "Тестирование FirstPage при передаче \"-1\".")]
		[TestCase(0, TestName = "Тестирование FirstPage при передаче \"0\".")]
		[TestCase(int.MinValue, TestName = "Тестирование FirstPage при передаче \"int.MinValue\".")]
		[TestCase(int.MinValue + 1, TestName = "Тестирование FirstPage при передаче \"int.MinValue + 1\".")]
		[TestCase(99, TestName = "Тестирование FirstPage при передаче \"99\".")]
		[TestCase(98, TestName = "Тестирование FirstPage при передаче \"98\".")]
		public void LastPageExceptionsTest(int lastPage)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				100,
				239,
				"Орел"
			);
			Exception exception = null;
			try
			{
				article.LastPage = lastPage;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase(100, ExpectedResult = 100, TestName = "Тестирование LastPage при передаче \"100\".")]
		[TestCase(101, ExpectedResult = 101, TestName = "Тестирование LastPage при передаче \"101\".")]
		[TestCase(int.MaxValue, ExpectedResult = int.MaxValue,
			TestName = "Тестирование LastPage при передаче \"int.MaxValue\".")]
		[TestCase(int.MaxValue - 1, ExpectedResult = int.MaxValue - 1,
			TestName = "Тестирование LastPage при передаче \"int.MaxValue - 1\".")]
		public int LastPageTest(int lastPage)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				100,
				239,
				"Орел"
			);

			article.LastPage = lastPage;
			return article.LastPage;
		}

		#endregion

		#region CityOfPublicationTest

		[Test]
		[TestCase(" Астана", TestName = "Тестирование CityOfPublication при передаче \" Астана\".")]
		[TestCase("Astana ", TestName = "Тестирование CityOfPublication при передаче \"Astana \".")]
		[TestCase("СанКт Петербург", TestName = "Тестирование CityOfPublication при передаче \"СанКт Петербург\".")]
		[TestCase("Kemyl Jaraevo ", TestName = "Тестирование CityOfPublication при передаче \"Kemyl Jaraevo \".")]
		[TestCase("St  Peterburg", TestName = "Тестирование CityOfPublication при передаче \"St  Peterburg\".")]
		[TestCase(" Лос Анджелес", TestName = "Тестирование CityOfPublication при передаче \" Лос Анджелес\".")]
		public void CityOfPublicationExceptionsTest(string сityOfPublication)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);
			Exception exception = null;
			try
			{
				article.CityOfPublication = сityOfPublication;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("Астана", ExpectedResult = "Астана", TestName = "Тестирование CityOfPublication при передаче \"Астана\".")]
		[TestCase("Astana", ExpectedResult = "Astana", TestName = "Тестирование CityOfPublication при передаче \"Astana\".")]
		[TestCase("Санкт-Петербург", ExpectedResult = "Санкт-Петербург",
			TestName = "Тестирование CityOfPublication при передаче \"Санкт-Петербург\".")]
		[TestCase("Kemyl-Jaraevo", ExpectedResult = "Kemyl-Jaraevo",
			TestName = "Тестирование CityOfPublication при передаче \"Kemyl-Jaraevo\".")]
		[TestCase("St Peterburg", ExpectedResult = "St Peterburg",
			TestName = "Тестирование CityOfPublication при передаче \"St Peterburg\".")]
		[TestCase("Лос Анджелес", ExpectedResult = "Лос Анджелес",
			TestName = "Тестирование CityOfPublication при передаче \"Лос Анджелес\".")]
		public string CityOfPublicationTest(string сityOfPublication)
		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);

			article.CityOfPublication = сityOfPublication;
			return article.CityOfPublication;
		}

		#endregion

		#region BibliographyInfoTest

		[Test]
		[TestCase("2012/06/30", "Энерго- и ресурсосбережение - XXI век",
			"материалы XI международной научно-практической интернет-конференции", 237, 239, "Орел",
			ExpectedResult =
				"Мех, Д. А. Энерго- и ресурсосбережение - XXI век / Д. А. Мех, D. A. Mekh  // материалы XI международной научно-практической интернет-конференции, 30 июня 2012 г., г. Орел. - Орел, 2012. - C. 237-239.",
			TestName = "Тестирование BibliographyInfo")]
		[TestCase("2013/06/30", "Математика",
			"Сборник задач", 2, 13, "Санкт-Петербург",
			ExpectedResult =
				"Мех, Д. А. Математика / Д. А. Мех, D. A. Mekh  // Сборник задач, 30 июня 2013 г., г. Санкт-Петербург. - Санкт-Петербург, 2013. - C. 2-13.",
			TestName = "Тестирование BibliographyInfo")]
		[TestCase("1998/08/27", "Тестирование для чайников",
			"материалы XXI международного съезда писателей огромных текстов", 123, 1000, "Los Angeles",
			ExpectedResult =
				"Мех, Д. А. Тестирование для чайников / Д. А. Мех, D. A. Mekh  // материалы XXI международного съезда писателей огромных текстов, 27 августа 1998 г., г. Los Angeles. - Los Angeles, 1998. - C. 123-1000.",
			TestName = "Тестирование BibliographyInfo")]
		public string BibliographyInfoTest(DateTime date, string title, string materialType, int firstPage, int lastPage,
			string cityOfPublication)

		{
			var authors = new List<FullName>
			{
				new FullName("Мех", "Дмитрий", "Александрович"),
				new FullName("Mekh", "Dmitriy", "Alexandrovich")
			};
			var article = new CollectionCard
			(
				authors,
				date,
				title,
				materialType,
				firstPage,
				lastPage,
				cityOfPublication
			);

			return article.BibliographyInfo;
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
			var article = new CollectionCard
			(
				authors,
				new DateTime(2013, 06, 30),
				"Title",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);
			Exception exception = null;
			try
			{
				article.RemoveAllAuthors();
				string card = article.BibliographyInfo;
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