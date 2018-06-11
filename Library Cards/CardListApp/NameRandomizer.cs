using System;
using System.Threading;
using LibraryCards;

namespace CardListApp
{
	internal class NameRandomizer
	{
		public static FullName GenerateFullName()
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
			var sex = rand.Next(100) <= 50;
			Thread.Sleep(10);
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
	}
}