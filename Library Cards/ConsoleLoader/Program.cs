using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Library_Cards;

namespace ConsoleLoader
{
	class Program
	{

		static Names GenerateFullName()
		{
			string[] femaleNames =
			{
				"София",
				"Альвина" ,
				"Арина" ,
				"Амира" ,
				"Алиса" ,
				"Сафина" ,
				"Лиза",
				"марина"
			};
			string[] femaleSurnames =
			{
				"Цветкова",
				"Кононова" ,
				"Белоусова" ,
				"Воронова" ,
				"Емельянова" ,
				"Беспалова" ,
				"Новикава",
				"Белядко"
			};
			string[] femalePatronymics =
			{
				"Иванова",
				"Антониновна" ,
				"Серпантиновна" ,
				"Петровна" ,
				"Максимовна" ,
				"Евсеевна" ,
				"Вртемовна",
				"Дмитреевна"
			};
			string[] maleNames =
			{
				"Леонард" ,
				"Кондратий" ,
				"Феликс" ,
				"Виктор" ,
				"Родион" ,
				"Даниил" ,
				"Август" ,
				"Антуан"
			};
			string[] maleSurnames =
			{
				"Третяков" ,
				"Михеев" ,
				"Терентьев" ,
				"Павлов" ,
				"Маслов" ,
				"Соловьев" ,
				"Бобилёв" ,
				"Гробовозов"
			};
			string[] malePatronymics =
			{
				"Агафонович" ,
				"Михайлович" ,
				"Германович" ,
				"Владимирович" ,
				"Аристархович" ,
				"Глебович" ,
				"Мэлсович" ,
				"Борисович"
			};

			Random rand = new Random();
			bool sex = rand.Next(100) <= 50 ? true : false;

			if (sex == true)
			{
				return SetNames(maleNames, maleSurnames, malePatronymics);
			}
			else
			{
				return SetNames(femaleNames, femaleSurnames, femalePatronymics);
			}
		}
		static Names SetNames(string[] names, string[] surnames, string[] patronymics)
		{
			Random rand = new Random(DateTime.Now.Millisecond);
			int randomNumber = rand.Next(0, 7);
			Names fullName = new Names();

			fullName.SetName(names[randomNumber]);

			randomNumber = rand.Next(0,7);
			fullName.SetSurname(surnames[randomNumber]);
			
			randomNumber = rand.Next(0, 7);
			fullName.SetPatronymic(patronymics[randomNumber]);

			return fullName;
		}
		
		static void Main()
		{
			ICards card;

			var journal = new Journal
				(
					GenerateFullName(), 
					GenerateFullName(), 
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
			var book = new Book
				(
					GenerateFullName(), 
					GenerateFullName(), 
					"Информатика", 
					"Учебник для вузов", 
					"Питер", 
					2012, 
					573, 
					"Санкт-Петербург"
				);
			var miscellanea = new Miscellanea
				(
					GenerateFullName(), 
					GenerateFullName(), 
					new DateTime(2013, 06, 30), 
					"Энерго- и ресурсосбережение – XXI век", 
					"материалы XI международной научно-практической интернет-конференции", 
					237, 
					239, 
					"Орел"
				);

			card = journal;
			Console.WriteLine(card.GetBibliographyInfo() + "\n\n ---------------------------------------- \n");
			card = dissertation;
			System.Console.WriteLine(card.GetBibliographyInfo() + "\n\n ---------------------------------------- \n");
			card = book;
			System.Console.WriteLine(card.GetBibliographyInfo() + "\n\n ---------------------------------------- \n");
			card = miscellanea;
			System.Console.WriteLine(card.GetBibliographyInfo() + "\n\n ---------------------------------------- \n");

			Console.Read();
		}
	}
}
