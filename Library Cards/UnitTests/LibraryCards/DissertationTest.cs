using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryCards;
using NUnit.Framework;

namespace UnitTests.LibraryCards
{
	class DissertationTest
	{
		#region ConstructorTest

		[Test]
		[TestCase("Особенности регулирования труда творческих работников театров",
			168,
			"канд. юрид. наук",
			2009,
			"Москва",
			"12.00.05",
			ExpectedResult =
				"Мех, Д. А. Особенности регулирования труда творческих работников театров : дис. ...канд. юрид. наук : 12.00.05 / Мех Дмитрий Александрович. - Москва, 2009. - 168 c.",
			TestName = "Тестирование конструктора")]

		public string ConstructorTest(string title, int page, string authorStatus, int year, string cityOfPublication,
			string specializationNumber)
		{
			var dissertation = new Dissertation
			(
				new FullName("Мех", "Дмитрий", "Александрович"),
				title,
				page,
				authorStatus,
				year,
				cityOfPublication,
				specializationNumber
			);

			FullName tempQualifier = dissertation.FirstAuthor;
			var firstPart = tempQualifier.Surname + ", " + tempQualifier.Name[0] + ". " + tempQualifier.Patronymic[0] + '.' + ' ' + dissertation.Title + " : дис. ..." + dissertation.AuthorStatus + " : " +
			                dissertation.SpecializationNumber + " / " + dissertation.FirstAuthor.GetFullName() + ". - ";
			//Информация о публикации
			var publicationInfo = dissertation.CityOfPublication + ", " + dissertation.Year + ". - " + dissertation.Page + " c.";

			//Генерация нужной строки
			return firstPart + publicationInfo;
		}

		[Test]
		[TestCase("", 168, "канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с пустым полем title")]
		[TestCase(" ", 168, "канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем title при передаче \" \"")]
		[TestCase(" Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем title, при передаче \" Особенности регулирования труда творческих работников театров\"")]
		[TestCase("Особенности регулирования труда творческих работников театров ", 168, "канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем title, при передаче \"Особенности регулирования труда творческих работников театров \"")]

		[TestCase("Особенности регулирования труда творческих работников театров", -1, "канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем page при передаче \"-1\"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 0, "канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем page при передаче \"0\"")]

		[TestCase("Особенности регулирования труда творческих работников театров", 168, "", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с пустым полем authorStatus")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, " ", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем authorStatus при передаче \" \"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, " канд. юрид. наук", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем authorStatus, при передаче \" канд. юрид. наук\"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук ", 2009, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем authorStatus, при передаче \"канд. юрид. наук \"")]

		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 0, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем year при передаче \"0\"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2100, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем year при передаче \"2100\"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", -1, "Москва", "12.00.05", TestName = "Тестирование конструктора с полем year при передаче \"-1\"")]

		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "", "12.00.05", TestName = "Тестирование конструктора с пустым полем cityOfPublication")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, " ", "12.00.05", TestName = "Тестирование конструктора с полем cityOfPublication при передаче \" \"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, " Москва", "12.00.05", TestName = "Тестирование конструктора с полем cityOfPublication, при передаче \" Москва\"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва ", "12.00.05", TestName = "Тестирование конструктора с полем cityOfPublication, при передаче \"Москва \"")]

		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "", TestName = "Тестирование конструктора с пустым полем specializationNumber")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", " ", TestName = "Тестирование конструктора с полем specializationNumber при передаче \" \"")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "112.00.05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"112.00.05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12.030.05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12.030.05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12.00.035", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12.00.035\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "112.100.015", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"112.100.015\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "1.00.05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"1.00.05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12.0.05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12.0.05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12.00.5", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12.00.5\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12/00/05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12/00/05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12 00 05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12 00 05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "123", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"123\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "двенадцать", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"двенадцать\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "двенадцать.шесть.три", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"двенадцать.шесть.три\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "ф.ы.в", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"ф.ы.в\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "фф.ыы.вв", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"фф.ыы.вв\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", " 12.00.05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \" 12.00.05\" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12.00.05 ", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12.00.05 \" ")]
		[TestCase("Особенности регулирования труда творческих работников театров", 168, "канд. юрид. наук", 2009, "Москва", "12-00-05", TestName = "Тестирование конструктора с полем specializationNumber при передаче \"12-00-05\" ")]

		public void ConstructorExctencionsTest(string title, int page, string authorStatus, int year, string cityOfPublication,
			string specializationNumber)
		{
			Exception exception = null;
			try
			{
				var dissertation = new Dissertation
				(
					new FullName("Мех", "Дмитрий", "Александрович"),
					title,
					page,
					authorStatus,
					year,
					cityOfPublication,
					specializationNumber
				);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		#endregion

		#region FirstAuthorTest

		[Test]
		[TestCase("Mekh", "Dmitriy", "Alexandrovich", ExpectedResult = "Dmitriy Mekh Alexandrovich", TestName = "Тестирование FirstAuthor при передаче \"Mekh\",\"Dmitriy\",\"Alexandrovich\".")]
		[TestCase("Мех", "Дмитрий", "Александрович", ExpectedResult = "Дмитрий Мех Александрович", TestName = "Тестирование FirstAuthor при передаче \"Mekh\",\"Dmitriy\",\"Alexandrovich\".")]
		public string FirstAuthorTest(string name, string surname, string patronymic)
		{
			FullName author = new FullName(surname, name, patronymic);
			var dissertation = new Dissertation
			(
				author,
				"Особенности регулирования труда творческих работников театров",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);

			return dissertation.FirstAuthor.ToString();
		}

		[Test]
		[TestCase(TestName = "Тестирование FirstAuthor при передаче поля author равным null.")]
		public void FirstAuthor_Null_ExceptionTest()
		{
			FullName author = new FullName("Mekh", "Dmitriy", "Alexandrovich");

			var dissertation = new Dissertation
			(
				author,
				"Особенности регулирования труда творческих работников театров",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);
			Exception exception = null;
			try
			{
				FullName nullAuthor = null;
				dissertation.FirstAuthor = nullAuthor;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		#endregion

		#region AuthorStatusTest
		[Test]
		[TestCase("12.00.05", ExpectedResult = "12.00.05", TestName = "Тестирование AuthorStatus при передаче \"12.00.05\"")]
		[TestCase("00.00.00", ExpectedResult = "00.00.00", TestName = "Тестирование AuthorStatus при передаче \"00.00.00\"")]
		[TestCase("99.99.99", ExpectedResult = "99.99.99", TestName = "Тестирование AuthorStatus при передаче \"99.99.99\"")]
		public string AuthorStatusTest(string status)
		{
			FullName author = new FullName("Mekh", "Dmitriy", "Alexadrovich");
			var dissertation = new Dissertation
			(
				author,
				"Особенности регулирования труда творческих работников театров",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);

			dissertation.AuthorStatus = status;
			return dissertation.AuthorStatus;
		}


		[Test]
		[TestCase("", TestName = "Тестирование конструктора с пустым полем authorStatus")]
		[TestCase(" ", TestName = "Тестирование конструктора с полем authorStatus при передаче \" \"")]
		[TestCase(" канд. юрид. наук", TestName = "Тестирование конструктора с полем authorStatus, при передаче \" канд. юрид. наук\"")]
		[TestCase("канд. юрид. наук ", TestName = "Тестирование конструктора с полем authorStatus, при передаче \"канд. юрид. наук \"")]
		public void AuthorStatusExceptionsTest(string status)
		{
			FullName author = new FullName("Mekh", "Dmitriy", "Alexadrovich");
			var dissertation = new Dissertation
			(
				author,
				"Особенности регулирования труда творческих работников театров",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);
			Exception exception = null;
			try
			{
				dissertation.AuthorStatus = status;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}
		#endregion

		#region SpecializationNumberTest

		[Test]
		[TestCase("", TestName = "Тестирование SpecializationNumber с пустым полем specializationNumber")]
		[TestCase(" ", TestName = "Тестирование SpecializationNumber при передаче \" \"")]
		[TestCase("112.00.05", TestName = "Тестирование SpecializationNumber при передаче \"112.00.05\" ")]
		[TestCase("12.030.05", TestName = "Тестирование SpecializationNumber при передаче \"12.030.05\" ")]
		[TestCase("12.00.035", TestName = "Тестирование SpecializationNumber при передаче \"12.00.035\" ")]
		[TestCase("112.100.015", TestName = "Тестирование SpecializationNumber при передаче \"112.100.015\" ")]
		[TestCase("1.00.05", TestName = "Тестирование SpecializationNumber при передаче \"1.00.05\" ")]
		[TestCase("12.0.05", TestName = "Тестирование SpecializationNumber при передаче \"12.0.05\" ")]
		[TestCase("12.00.5", TestName = "Тестирование SpecializationNumber при передаче \"12.00.5\" ")]
		[TestCase("12/00/05", TestName = "Тестирование SpecializationNumber при передаче \"12/00/05\" ")]
		[TestCase("12 00 05", TestName = "c")]
		[TestCase("123", TestName = "Тестирование SpecializationNumber при передаче \"123\" ")]
		[TestCase("двенадцать", TestName = "Тестирование SpecializationNumber при передаче \"двенадцать\" ")]
		[TestCase("двенадцать.шесть.три", TestName = "Тестирование SpecializationNumber при передаче \"двенадцать.шесть.три\" ")]
		[TestCase("ф.ы.в", TestName = "Тестирование SpecializationNumber при передаче \"ф.ы.в\" ")]
		[TestCase("фф.ыы.вв", TestName = "Тестирование SpecializationNumber при передаче \"фф.ыы.вв\" ")]
		[TestCase(" 12.00.05", TestName = "Тестирование SpecializationNumber при передаче \" 12.00.05\" ")]
		[TestCase("12.00.05 ", TestName = "Тестирование SpecializationNumber при передаче \"12.00.05 \" ")]
		[TestCase("12-00-05", TestName = "Тестирование SpecializationNumber при передаче \"12-00-05\" ")]

		public void SpecializationNumberExceptionTest(string specializationNumber)
		{
			FullName author = new FullName("Mekh", "Dmitriy", "Alexadrovich");
			var dissertation = new Dissertation
			(
				author,
				"Особенности регулирования труда творческих работников театров",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);
			Exception exception = null;
			try
			{

				dissertation.SpecializationNumber = specializationNumber;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("00.00.00", ExpectedResult = "00.00.00", TestName = "Тестирование SpecializationNumber при передаче \"00.00.00\" ")]
		[TestCase("99.99.99", ExpectedResult = "99.99.99", TestName = "Тестирование SpecializationNumber при передаче \"00.00.00\" ")]
		public string SpecializationNumberTest(string specializationNumber)
		{
			FullName author = new FullName("Mekh", "Dmitriy", "Alexadrovich");
			var dissertation = new Dissertation
			(
				author,
				"Особенности регулирования труда творческих работников театров",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);
			
			dissertation.SpecializationNumber = specializationNumber;

			return dissertation.SpecializationNumber;
		}

		#endregion

		#region BiblyographyInfoTest

		[Test]
		[TestCase("Особенности регулирования труда творческих работников театров",
			168,
			"канд. юрид. наук",
			2009,
			"Москва",
			"12.00.05",
			ExpectedResult =
				"Мех, Д. А. Особенности регулирования труда творческих работников театров : дис. ...канд. юрид. наук : 12.00.05 / Мех Дмитрий Александрович. - Москва, 2009. - 168 c.",
			TestName = "Тестирование BiblyographyInfo")]

		public string BiblyographyInfoTest(string title, int page, string authorStatus, int year, string cityOfPublication,
			string specializationNumber)
		{
			var dissertation = new Dissertation
			(
				new FullName("Мех", "Дмитрий", "Александрович"),
				title,
				page,
				authorStatus,
				year,
				cityOfPublication,
				specializationNumber
			);

			return dissertation.BibliographyInfo;
		}
		#endregion
	}
}
