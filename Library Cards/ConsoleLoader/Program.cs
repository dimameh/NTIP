using System;
using System.Collections.Generic;
using LibraryCards;

namespace ConsoleLoader
{
    //TODO: Этот проект уже не нужен. Удалить
    internal class Program
	{
		private static FullName GenerateFullName()
		{
			string[] femaleNames =
			{
				"София",
				"Альвина",
				"Арина",
				"Амира",
				"Алиса",
				"Сафина",
				"Лиза",
				"марина"
			};
			string[] femaleSurnames =
			{
				"Цветкова",
				"Кононова",
				"Белоусова",
				"Воронова",
				"Емельянова",
				"Беспалова",
				"Новикава",
				"Белядко"
			};
			string[] femalePatronymics =
			{
				"Иванова",
				"Антониновна",
				"Серпантиновна",
				"Петровна",
				"Максимовна",
				"Евсеевна",
				"Вртемовна",
				"Дмитреевна"
			};
			string[] maleNames =
			{
				"Леонард",
				"Кондратий",
				"Феликс",
				"Виктор",
				"Родион",
				"Даниил",
				"Август",
				"Антуан"
			};
			string[] maleSurnames =
			{
				"Третяков",
				"Михеев",
				"Терентьев",
				"Павлов",
				"Маслов",
				"Соловьев",
				"Бобилев",
				"Гробовозов"
			};
			string[] malePatronymics =
			{
				"Агафонович",
				"Михайлович",
				"Германович",
				"Владимирович",
				"Аристархович",
				"Глебович",
				"Мэлсович",
				"Борисович"
			};

			var rand = new Random();
			var sex = rand.Next(100) <= 50 ? true : false;

			if (sex)
				return SetNames(maleNames, maleSurnames, malePatronymics);
			return SetNames(femaleNames, femaleSurnames, femalePatronymics);
		}

		private static FullName SetNames(string[] names, string[] surnames, string[] patronymics)
		{
			var rand = new Random(DateTime.Now.Millisecond);
			var randomNumber = rand.Next(0, 7);
			var fullName = new FullName(surnames[randomNumber], names[randomNumber], patronymics[randomNumber]);

			return fullName;
		}

		private static void Main()
		{
			ICard card;

			var authors = new List<FullName> {GenerateFullName(), GenerateFullName()};

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
			var dissertation = new Dissertation
			(
				GenerateFullName(),
				"Особенности регулирования труда творческих работников театров ",
				168,
				"канд. юрид. наук",
				2009,
				"Москва",
				"12.00.05"
			);
			authors = new List<FullName> {GenerateFullName(), GenerateFullName()};
			var book = new BookArticle
			(
				authors,
				"Информатика",
				"Учебник для вузов",
				"Питер",
				2012,
				573,
				"Санкт-Петербург"
			);
			authors = new List<FullName> {GenerateFullName(), GenerateFullName()};
			var miscellanea = new CollectionArticle
			(
				authors,
				new DateTime(2013, 06, 30),
				"Энерго- и ресурсосбережение – XXI век",
				"материалы XI международной научно-практической интернет-конференции",
				237,
				239,
				"Орел"
			);

			card = journal;
			Console.WriteLine(card.BibliographyInfo + "\n\n ---------------------------------------- \n");
			card = dissertation;
			Console.WriteLine(card.BibliographyInfo + "\n\n ---------------------------------------- \n");
			card = book;
			Console.WriteLine(card.BibliographyInfo + "\n\n ---------------------------------------- \n");
			card = miscellanea;
			Console.WriteLine(card.BibliographyInfo + "\n\n ---------------------------------------- \n");

			Console.Read();
		}
	}
}