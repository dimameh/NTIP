using System;
using LibraryCards;
using NUnit.Framework;

namespace UnitTests.LibraryCards
{
	/// <summary>
	///     Набор тестов для класса LibraryCards
	/// </summary>
	[TestFixture]
	internal class FullNameTest
	{                                                                                                                      
		#region IsProperNounTest

		[Test]
		[TestCase("Dima", ExpectedResult = true, TestName = "Тестирование IsProperNoun при передаче \"Dima\".")]
		[TestCase("Дима", ExpectedResult = true, TestName = "Тестирование IsProperNoun при передаче \"Дима\".")]
		[TestCase("Жан-Жак", ExpectedResult = true, TestName = "Тестирование IsProperNoun при передаче \"Жан-Жак\".")]
		[TestCase("Charles-Marie-Rene", ExpectedResult = true,
			TestName = "Тестирование IsProperNoun при передаче \"Charles-Marie-Rene\".")]
		[TestCase("", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"\".")]
		[TestCase(" ", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \" \".")]
		[TestCase(" Дима", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \" Дима\".")]
		[TestCase("-Дима", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"-Дима\".")]
		[TestCase(" Dima", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \" Dima\".")]
		[TestCase("-Dimas", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"-Dima\".")]
		[TestCase("Дима ", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Дима \".")]
		[TestCase("Дима-", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Дима-\".")]
		[TestCase("Dima ", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Dima \".")]
		[TestCase("Dima-", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Dima-\".")]
		[TestCase("D-ima", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"D-ima\".")]
		[TestCase("D ima", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"D ima\".")]
		[TestCase("Д-има", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Д-има\".")]
		[TestCase("Д има", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Д има\".")]
		[TestCase("Dim a", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Dim a\".")]
		[TestCase("Dim-a", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Dim-a\".")]
		[TestCase("Дим а", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Дим а\".")]
		[TestCase("Дим-а", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Дим-а\".")]
		[TestCase("Dиma", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Dиma\".")]
		[TestCase("Диmа", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Диmа\".")]
		[TestCase("Di--Ma", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Di--Ma\".")]
		[TestCase("Ди--Ма", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"Ди--Ма\".")]
		[TestCase("dima", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"dima\".")]
		[TestCase("дима", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"дима\".")]
		[TestCase("DIma", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"DIma\".")]
		[TestCase("DiMA", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"DiMA\".")]
		[TestCase("ДИма", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"ДИма\".")]
		[TestCase("ДиМА", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"ДиМА\".")]
		[TestCase("DiMa", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"DiMa\".")]
		[TestCase("ДиМа", ExpectedResult = false, TestName = "Тестирование IsProperNoun при передаче \"ДиМа\".")]
		public bool IsProperNounTest(string noun)
		{
			return FullName.IsProperNoun(noun);
		}

		#endregion

		#region NameTest

		[Test]
		[TestCase("", TestName = "Тестирование Name при передаче \"\".")]
		[TestCase(" ", TestName = "Тестирование Name при передаче \" \".")]
		[TestCase(" Дима", TestName = "Тестирование Name при передаче \" Dima\".")]
		[TestCase("-Dimas", TestName = "Тестирование Name при передаче \"-Dima\".")]
		[TestCase("Дима ", TestName = "Тестирование Name при передаче \"Дима \".")]
		[TestCase("Дима-", TestName = "Тестирование Name при передаче \"Дима-\".")]
		[TestCase("Dima ", TestName = "Тестирование Name при передаче \"Dima \".")]
		[TestCase("Dima-", TestName = "Тестирование Name при передаче \"Dima-\".")]
		[TestCase("D-ima", TestName = "Тестирование Name при передаче \"D-ima\".")]
		[TestCase("D ima", TestName = "Тестирование Name при передаче \"D ima\".")]
		[TestCase("Д-има", TestName = "Тестирование Name при передаче \"Д-има\".")]
		[TestCase("Д има", TestName = "Тестирование Name при передаче \"Д има\".")]
		[TestCase("Dim a", TestName = "Тестирование Name при передаче \"Dim a\".")]
		[TestCase("Dim-a", TestName = "Тестирование Name при передаче \"Dim-a\".")]
		[TestCase("Дим а", TestName = "Тестирование Name при передаче \"Дим а\".")]
		[TestCase("Дим-а", TestName = "Тестирование Name при передаче \"Дим-а\".")]
		[TestCase("Dиma", TestName = "Тестирование Name при передаче \"Dиma\".")]
		[TestCase("Диmа", TestName = "Тестирование Name при передаче \"Диmа\".")]
		[TestCase("Di--Ma", TestName = "Тестирование Name при передаче \"Di--Ma\".")]
		[TestCase("Ди--Ма", TestName = "Тестирование Name при передаче \"Ди--Ма\".")]
		[TestCase("dima", TestName = "Тестирование Name при передаче \"dima\".")]
		[TestCase("дима", TestName = "Тестирование Name при передаче \"дима\".")]
		[TestCase("DIma", TestName = "Тестирование Name при передаче \"DIma\".")]
		[TestCase("DiMA", TestName = "Тестирование Name при передаче \"DiMA\".")]
		[TestCase("ДИма", TestName = "Тестирование Name при передаче \"ДИма\".")]
		[TestCase("ДиМА", TestName = "Тестирование Name при передаче \"ДиМА\".")]
		[TestCase("DiMa", TestName = "Тестирование Name при передаче \"DiMa\".")]
		[TestCase("ДиМа", TestName = "Тестирование Name при передаче \"ДиМа\".")]
		public void NameExceptionTest(string name)
		{
			var Dima = new FullName("Mekh", "Dmitriy", "Alexandrovich");
			Exception exception = null;
			try
			{
				Dima.Name = name;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("Dima", ExpectedResult = "Dima", TestName = "Тестирование Name при передаче \"Dima\".")]
		[TestCase("Дима", ExpectedResult = "Дима", TestName = "Тестирование Name при передаче \"Дима\".")]
		[TestCase("Жан-Жак", ExpectedResult = "Жан-Жак", TestName = "Тестирование Name при передаче \"Жан-Жак\".")]
		[TestCase("Charles-Marie-Rene", ExpectedResult = "Charles-Marie-Rene",
			TestName = "Тестирование Name при передаче \"Charles-Marie-Rene\".")]
		public string NameTest(string name)
		{
			var Dima = new FullName("Mekh", "Dmitriy", "Alexandrovich");

			Dima.Name = name;
			return Dima.Name;
		}

		#endregion

		#region SurnameTest

		[Test]
		[TestCase("", TestName = "Тестирование Surname при передаче \"\".")]
		[TestCase(" ", TestName = "Тестирование Surname при передаче \" \".")]
		[TestCase(" Дима", TestName = "Тестирование Surname при передаче \" Dima\".")]
		[TestCase("-Dimas", TestName = "Тестирование Surname при передаче \"-Dima\".")]
		[TestCase("Дима ", TestName = "Тестирование Surname при передаче \"Дима \".")]
		[TestCase("Дима-", TestName = "Тестирование Surname при передаче \"Дима-\".")]
		[TestCase("Dima ", TestName = "Тестирование Surname при передаче \"Dima \".")]
		[TestCase("Dima-", TestName = "Тестирование Surname при передаче \"Dima-\".")]
		[TestCase("D-ima", TestName = "Тестирование Surnamen при передаче \"D-ima\".")]
		[TestCase("D ima", TestName = "Тестирование Surnamen при передаче \"D ima\".")]
		[TestCase("Д-има", TestName = "Тестирование Surnamen при передаче \"Д-има\".")]
		[TestCase("Д има", TestName = "Тестирование Surnamen при передаче \"Д има\".")]
		[TestCase("Dim a", TestName = "Тестирование Surnamen при передаче \"Dim a\".")]
		[TestCase("Dim-a", TestName = "Тестирование Surnamen при передаче \"Dim-a\".")]
		[TestCase("Дим а", TestName = "Тестирование Surnamen при передаче \"Дим а\".")]
		[TestCase("Дим-а", TestName = "Тестирование Surnamen при передаче \"Дим-а\".")]
		[TestCase("Dиma", TestName = "Тестирование Surname при передаче \"Dиma\".")]
		[TestCase("Диmа", TestName = "Тестирование Surname при передаче \"Диmа\".")]
		[TestCase("Di--Ma", TestName = "Тестирование Surname при передаче \"Di--Ma\".")]
		[TestCase("Ди--Ма", TestName = "Тестирование Surname при передаче \"Ди--Ма\".")]
		[TestCase("dima", TestName = "Тестирование Surname при передаче \"dima\".")]
		[TestCase("дима", TestName = "Тестирование Surname при передаче \"дима\".")]
		[TestCase("DIma", TestName = "Тестирование Surname при передаче \"DIma\".")]
		[TestCase("DiMA", TestName = "Тестирование Surname при передаче \"DiMA\".")]
		[TestCase("ДИма", TestName = "Тестирование Surname при передаче \"ДИма\".")]
		[TestCase("ДиМА", TestName = "Тестирование Surname при передаче \"ДиМА\".")]
		[TestCase("DiMa", TestName = "Тестирование Surname при передаче \"DiMa\".")]
		[TestCase("ДиМа", TestName = "Тестирование Surname при передаче \"ДиМа\".")]
		public void SurnameExceptionTest(string surname)
		{
			var Dima = new FullName("Mekh", "Dmitriy", "Alexandrovich");
			Exception exception = null;
			try
			{
				Dima.Surname = surname;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("Dima", ExpectedResult = "Dima", TestName = "Тестирование Surname при передаче \"Dima\".")]
		[TestCase("Дима", ExpectedResult = "Дима", TestName = "Тестирование Surname при передаче \"Дима\".")]
		[TestCase("Жан-Жак", ExpectedResult = "Жан-Жак", TestName = "Тестирование Surname при передаче \"Жан-Жак\".")]
		[TestCase("Charles-Marie-Rene", ExpectedResult = "Charles-Marie-Rene",
			TestName = "Тестирование Surname при передаче \"Charles-Marie-Rene\".")]
		public string SurnameTest(string surname)
		{
			var Dima = new FullName("Mekh", "Dmitriy", "Alexandrovich");

			Dima.Surname = surname;
			return Dima.Surname;
		}

		#endregion

		#region PatronymicTest

		[Test]
		[TestCase("", TestName = "Тестирование Patronymic при передаче \"\".")]
		[TestCase(" ", TestName = "Тестирование Patronymic при передаче \" \".")]
		[TestCase(" Дима", TestName = "Тестирование Patronymic при передаче \" Dima\".")]
		[TestCase("-Dimas", TestName = "Тестирование Patronymic при передаче \"-Dima\".")]
		[TestCase("Дима ", TestName = "Тестирование Patronymic при передаче \"Дима \".")]
		[TestCase("Дима-", TestName = "Тестирование Patronymic при передаче \"Дима-\".")]
		[TestCase("Dima ", TestName = "Тестирование Patronymic при передаче \"Dima \".")]
		[TestCase("Dima-", TestName = "Тестирование Patronymic при передаче \"Dima-\".")]
		[TestCase("D-ima", TestName = "Тестирование Patronymic при передаче \"D-ima\".")]
		[TestCase("D ima", TestName = "Тестирование Patronymic при передаче \"D ima\".")]
		[TestCase("Д-има", TestName = "Тестирование Patronymic при передаче \"Д-има\".")]
		[TestCase("Д има", TestName = "Тестирование Patronymic при передаче \"Д има\".")]
		[TestCase("Dim a", TestName = "Тестирование Patronymic при передаче \"Dim a\".")]
		[TestCase("Dim-a", TestName = "Тестирование Patronymic при передаче \"Dim-a\".")]
		[TestCase("Дим а", TestName = "Тестирование Patronymic при передаче \"Дим а\".")]
		[TestCase("Дим-а", TestName = "Тестирование Patronymic при передаче \"Дим-а\".")]
		[TestCase("Dиma", TestName = "Тестирование Patronymic при передаче \"Dиma\".")]
		[TestCase("Диmа", TestName = "Тестирование Patronymic при передаче \"Диmа\".")]
		[TestCase("Di--Ma", TestName = "Тестирование Patronymic при передаче \"Di--Ma\".")]
		[TestCase("Ди--Ма", TestName = "Тестирование Patronymic при передаче \"Ди--Ма\".")]
		[TestCase("dima", TestName = "Тестирование Patronymic при передаче \"dima\".")]
		[TestCase("дима", TestName = "Тестирование Patronymic при передаче \"дима\".")]
		[TestCase("DIma", TestName = "Тестирование Patronymic при передаче \"DIma\".")]
		[TestCase("DiMA", TestName = "Тестирование Patronymic при передаче \"DiMA\".")]
		[TestCase("ДИма", TestName = "Тестирование Patronymic при передаче \"ДИма\".")]
		[TestCase("ДиМА", TestName = "Тестирование Patronymic при передаче \"ДиМА\".")]
		[TestCase("DiMa", TestName = "Тестирование Patronymic при передаче \"DiMa\".")]
		[TestCase("ДиМа", TestName = "Тестирование Patronymic при передаче \"ДиМа\".")]
		public void PatronymicExceptionTest(string patronymic)
		{
			var Dima = new FullName("Mekh", "Dmitriy", "Alexandrovich");
			Exception exception = null;
			try
			{
				Dima.Patronymic = patronymic;
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("Dima", ExpectedResult = "Dima", TestName = "Тестирование Patronymic при передаче \"Dima\".")]
		[TestCase("Дима", ExpectedResult = "Дима", TestName = "Тестирование Patronymic при передаче \"Дима\".")]
		[TestCase("Жан-Жак", ExpectedResult = "Жан-Жак", TestName = "Тестирование Patronymic при передаче \"Жан-Жак\".")]
		[TestCase("Charles-Marie-Rene", ExpectedResult = "Charles-Marie-Rene",
			TestName = "Тестирование Patronymic при передаче \"Charles-Marie-Rene\".")]
		public string PatronymicTest(string patronymic)
		{
			var Dima = new FullName("Mekh", "Dmitriy", "Alexandrovich");

			Dima.Patronymic = patronymic;
			return Dima.Patronymic;
		}

		#endregion

		#region ConstructorTest

		[Test]
		[TestCase("", "", "", TestName = "Тестирование Конструктора FullName при передаче \"\".")]
		[TestCase(" ", " ", " ", TestName = "Тестирование  Конструктора FullName при передаче \"  , , \".")]
		[TestCase(" Дима", " Дима", " Дима", TestName =
			"Тестирование  Конструктора FullName при передаче \" Дима\", \" Дима\", \" Дима\".")]
		[TestCase("-Dimas", "-Dimas", "-Dimas", TestName =
			"Тестирование  Конструктора FullName при передаче \"-Dimas\", \"-Dimas\", \"-Dimas\".")]
		[TestCase("Дима ", "Дима ", "Дима ", TestName =
			"Тестирование  Конструктора FullName при передаче \"Дима \", \"Дима \", \"Дима \".")]
		[TestCase("Дима-", "Дима-", "Дима-", TestName =
			"Тестирование  Конструктора FullName при передаче \"Дима-\", \"Дима-\", \"Дима-\".")]
		[TestCase("Dima ", "Dima ", "Dima ", TestName =
			"Тестирование  Конструктора FullName при передаче \"Dima \", \"Dima \", \"Dima \".")]
		[TestCase("Dima-", "Dima-", "Dima-", TestName =
			"Тестирование  Конструктора FullName при передаче \"Dima-\", \"Dima-\", \"Dima-\".")]
		[TestCase("D-ima", "D-ima", "D-ima", TestName =
			"Тестирование  Конструктора FullName при передаче \"D-ima\", \"D-ima\", \"D-ima\".")]
		[TestCase("D ima", "D ima", "D ima", TestName =
			"Тестирование  Конструктора FullName при передаче \"D ima\", \"D ima\", \"D ima\".")]
		[TestCase("Д-има", "Д-има", "Д-има", TestName =
			"Тестирование  Конструктора FullName при передаче \"Д-има\", \"Д-има\", \"Д-има\".")]
		[TestCase("Д има", "Д има", "Д има", TestName =
			"Тестирование  Конструктора FullName при передаче \"Д има\", \"Д има\", \"Д има\".")]
		[TestCase("Dim a", "Dim a", "Dim a", TestName =
			"Тестирование  Конструктора FullName при передаче \"Dim a\", \"Dim a\", \"Dim a\".")]
		[TestCase("Dim-a", "Dim-a", "Dim-a", TestName =
			"Тестирование  Конструктора FullName при передаче \"Dim-a\",\"Dim-a\",\"Dim-a\".")]
		[TestCase("Дим а", "Дим а", "Дим а", TestName =
			"Тестирование  Конструктора FullName при передаче \"Дим а\",\"Дим а\",\"Дим а\".")]
		[TestCase("Дим-а", "Дим-а", "Дим-а", TestName =
			"Тестирование  Конструктора FullName при передаче \"Дим-а\",\"Дим-а\",\"Дим-а\".")]
		[TestCase("Dиma", "Dиma", "Dиma", TestName =
			"Тестирование  Конструктора FullName при передаче \"Dиma\",\"Dиma\",\"Dиma\".")]
		[TestCase("Диmа", "Диmа", "Диmа", TestName =
			"Тестирование  Конструктора FullName при передаче \"Диmа\",\"Диmа\",\"Диmа\".")]
		[TestCase("Di--Ma", "Di--Ma", "Di--Ma", TestName =
			"Тестирование  Конструктора FullName при передаче \"Di--Ma\",\"Di--Ma\",\"Di--Ma\".")]
		[TestCase("Ди--Ма", "Ди--Ма", "Ди--Ма", TestName =
			"Тестирование  Конструктора FullName при передаче \"Ди--Ма\",\"Ди--Ма\",\"Ди--Ма\".")]
		[TestCase("dima", "dima", "dima", TestName =
			"Тестирование  Конструктора FullName при передаче \"dima\",\"dima\",\"dima\".")]
		[TestCase("дима", "дима", "дима", TestName =
			"Тестирование  Конструктора FullName при передаче \"дима\",\"дима\",\"дима\".")]
		[TestCase("DIma", "DIma", "DIma", TestName =
			"Тестирование  Конструктора FullName при передаче \"DIma\",\"DIma\",\"DIma\".")]
		[TestCase("DiMA", "DiMA", "DiMA", TestName =
			"Тестирование  Конструктора FullName при передаче \"DiMA\",\"DiMA\",\"DiMA\".")]
		[TestCase("ДИма", "ДИма", "ДИма", TestName =
			"Тестирование  Конструктора FullName при передаче \"ДИма\",\"ДИма\",\"ДИма\".")]
		[TestCase("ДиМА", "ДиМА", "ДиМА", TestName =
			"Тестирование  Конструктора FullName при передаче \"ДиМА\",\"ДиМА\",\"ДиМА\".")]
		[TestCase("DiMa", "DiMa", "DiMa", TestName =
			"Тестирование  Конструктора FullName при передаче \"DiMa\",\"DiMa\",\"DiMa\".")]
		[TestCase("ДиМа", "ДиМа", "ДиМа", TestName =
			"Тестирование  Конструктора FullName при передаче \"ДиМа\", \"ДиМа\", \"ДиМа\".")]
		public void FullNameConstructorExceptionTest(string surname, string name, string patronymic)
		{
			Exception exception = null;
			try
			{
				var Dimas = new FullName(surname, name, patronymic);
			}
			catch (Exception ex)
			{
				exception = ex;
			}

			Assert.IsNotNull(exception);
		}

		[Test]
		[TestCase("Мех", "Дмитрий", "Александрович", ExpectedResult = "Мех Дмитрий Александрович",
			TestName = "Тестирование Конструктора FullName при передаче \"Мех, Дмитрий, Александрович\".")]
		[TestCase("Mekh", "Dmitriy", "Alexandrovich", ExpectedResult = "Mekh Dmitriy Alexandrovich",
			TestName = "Тестирование Конструктора FullName при передаче \"Mekh\", \"Dmitriy\", \"Alexandrovich\".")]
		public string FullNameConstructorTest(string surname, string name, string patronymic)
		{
			var Dimas = new FullName(surname, name, patronymic);

			return Dimas.GetFullName();
		}

		#endregion

		#region GetSurnameWithInitialsTest

		[Test]
		[TestCase("Мех", "Дмитрий", "Александрович", ExpectedResult = "Мех, Д. А.",
			TestName = "Тестирование Конструктора FullName при передаче \"Мех, Дмитрий, Александрович\".")]
		[TestCase("Mekh", "Dmitriy", "Alexandrovich", ExpectedResult = "Mekh, D. A.",
			TestName = "Тестирование Конструктора FullName при передаче \"Mekh\", \"Dmitriy\", \"Alexandrovich\".")]
		public string GetSurnameWithInitialsTest(string surname, string name, string patronymic)
		{
			var Dimas = new FullName(surname, name, patronymic);

			return Dimas.GetSurnameWithInitials();
		}

		#endregion

		#region GetInitialsTest

		[Test]
		[TestCase("Мех", "Дмитрий", "Александрович", ExpectedResult = "Д. А.",
			TestName = "Тестирование Конструктора FullName при передаче \"Мех, Дмитрий, Александрович\".")]
		[TestCase("Mekh", "Dmitriy", "Alexandrovich", ExpectedResult = "D. A.",
			TestName = "Тестирование Конструктора FullName при передаче \"Mekh\", \"Dmitriy\", \"Alexandrovich\".")]
		public string GetInitialsTest(string surname, string name, string patronymic)
		{
			var Dimas = new FullName(surname, name, patronymic);

			return Dimas.GetInitials();
		}

		#endregion

		#region GetFullName

		[Test]
		[TestCase("Мех", "Дмитрий", "Александрович", ExpectedResult = "Мех Дмитрий Александрович",
			TestName = "Тестирование Конструктора FullName при передаче \"Мех, Дмитрий, Александрович\".")]
		[TestCase("Mekh", "Dmitriy", "Alexandrovich", ExpectedResult = "Mekh Dmitriy Alexandrovich",
			TestName = "Тестирование Конструктора FullName при передаче \"Mekh\", \"Dmitriy\", \"Alexandrovich\".")]
		public string GetFullNameTest(string surname, string name, string patronymic)
		{
			var Dimas = new FullName(surname, name, patronymic);

			return Dimas.GetFullName();
		}

		#endregion
	}
}