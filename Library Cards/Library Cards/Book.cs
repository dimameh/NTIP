using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
	/// <summary>
	/// Книга
	/// </summary>
	public class Book : ICards
	{
		//Private переменные и методы
		//----------------------------------------------
		/// <summary>
		/// Авторы
		/// </summary>
		private List<Names> _authors;
		/// <summary>
		/// Название книги
		/// </summary>
		private string _title = "";
		/// <summary>
		/// Жанр
		/// </summary>
		private string _materialType = "";
		/// <summary>
		/// Издательство
		/// </summary>
		private string _publishingHouse = "";
		/// <summary>
		/// Номер издания и информация о нем
		/// </summary>
		private string _additionalInfo = "";
		/// <summary>
		/// Год издания
		/// </summary>
		private int _year = -1;
		/// <summary>
		/// Объем в количестве страниц
		/// </summary>
		private int _volume = -1;
		/// <summary>
		/// Город публикации
		/// </summary>
		private string _cityOfPublication = "";
		/// <summary>
		/// Формирует ошибку если одно из полей не заполнено
		/// </summary>
		private void FillingExceptions()
		{
			if (!_authors[0].IsNameFilled())
			{
				throw new Exception("No author");
			}
			else if (_title == "")
			{
				throw new Exception("No title");
			}
			else if (_materialType == "")
			{
				throw new Exception("No material type");
			}
			else if (_publishingHouse == "")
			{
				throw new Exception("No publishing house");
			}
			else if (_year == -1)
			{
				throw new Exception("No year");
			}
			else if (_volume == -1)
			{
				throw new Exception("No volume");
			}
			else if (_cityOfPublication == "")
			{
				throw new Exception("No city of publicaion");
			}
		}

		//Конструторы
		public Book()
		{
			_title = "";
			_materialType = "";
			_publishingHouse = "";
			_additionalInfo = "";
			_year = -1;
			_volume = -1;
			_cityOfPublication = "";
		}
		public Book(Names author1, Names author2, string title = "", string materialType = "", string publishingHouse = "", int year = -1, int volume = -1, string cityOfPublication = "", string additionalInfo = "")
		{
			_authors = new List<Names> { author1, author2 };
			_title = title;
			_materialType = materialType;
			_publishingHouse = publishingHouse;
			_additionalInfo = additionalInfo;
			_year = year;
			_volume = volume;
			_cityOfPublication = cityOfPublication;
		}

		//Public методы
		//----------------------------------------------
		/// <summary>
		/// Возвращает список авторов
		/// </summary>
		public List<Names> Authors => _authors;
		/// <summary>
		/// Возвращает название
		/// </summary>
		public string Title => _title;
		/// <summary>
		/// Возвращает жанр
		/// </summary>
		public string MaterialType => _materialType;
		/// <summary>
		/// Возвращает издательство
		/// </summary>
		public string PublishingHouse => _publishingHouse;
		/// <summary>
		/// Возвращает номер издания и информация о нем
		/// </summary>
		public string AdditionalInfo => _additionalInfo;
		/// <summary>
		/// Возвращает город публикации
		/// </summary>
		/// <returns>город публикации</returns>
		public string CityOfPublication => _cityOfPublication;
		/// <summary>
		/// Возвращает объем книги в количестве страниц
		/// </summary>
		/// <returns>объем книги в количестве страниц</returns>
		public int Volume => _volume;
		/// <summary>
		/// Возвращает год публикации
		/// </summary>
		/// <returns>год публикации</returns>
		public int Year => _year;

		/// <summary>
		/// Задать название
		/// </summary>
		/// <param name="title"></param>
		public void SetTitle(string title)
		{
			_title = title;
		}
		/// <summary>
		/// Задать жанр
		/// </summary>
		/// <param name="materialType"></param>
		public void SetMaterialType(string materialType)
		{
			_materialType = materialType;
		}
		/// <summary>
		/// Задать издательство
		/// </summary>
		/// <param name="publishingHouse"></param>
		public void SetPublishingHouse(string publishingHouse)
		{
			_publishingHouse = publishingHouse;
		}
		/// <summary>
		/// Задать номер издания и информация о нем
		/// </summary>
		/// <param name="additionalInfo"></param>
		public void SetAdditionalInfo(string additionalInfo)
		{
			_additionalInfo = additionalInfo;
		}
		/// <summary>
		/// Задать объем издания в количестве страниц
		/// </summary>
		/// <param name="volume"></param>
		public void SetVolume(int volume)
		{
			if(volume > 0)
			{
				_volume = volume;
			}
			else
			{
				throw new Exception("Wrong volume");
			}
		}
		/// <summary>
		/// Задать год издания
		/// </summary>
		/// <param name="year"></param>
		public void SetYear(int year)
		{
			if(year > 0 && year < DateTime.Now.Year)
			{
				_year = year;
			}
			else
			{
				throw new Exception("Wrong year");
			}
		}
		/// <summary>
		/// Задать город публикации
		/// </summary>
		/// <param name="city"></param>
		public void SetCityOfPublication(string city)
		{
			if (Names.IsProperNoun(city))
			{
				_cityOfPublication = city;
			}
			else
			{
				throw new Exception("Wrong city");
			}
		}
		
		/// <summary>
		/// Формирует строку типа string которая ялвяется библиографической информацией об издании, оформленной по ГОСТу 7.1 - 2003 "Библиографическая запись"
		/// </summary>
		/// <returns>Всю информацию об издании</returns>
		public string GetBibliographyInfo()
		{
			//Проверка заполнены ли все поля
			try
			{
				FillingExceptions();
			}
			catch (Exception exception)
			{
				throw exception;
			}
			//составные части результирующей строки

			//Первая часть карточки, один автор, название и тип материала
			string firstPart = _authors[0].GetSurnameWithInitials() + ' ' + _title + " : " + _materialType + " / ";
			//Все авторы издания
			string allAuthors = "";
			for (int i = 0; i < _authors.Count-1; i++)
			{
				allAuthors += _authors[i].GetInitials() + ' ' + _authors[i].GetSurname() + ", ";
			}
			allAuthors += _authors[_authors.Count - 1].GetInitials() + ' ' + _authors[_authors.Count - 1].GetSurname();
			allAuthors += ' ';
			//Информация о публикации
			string publicationInfo = ". - " + _cityOfPublication + " : " + _publishingHouse + ", " + _year + ". - " + _volume + " c.";
			//Генерация нужной строки
			//Если
			string additionalInfoTemp = "";
			if (_additionalInfo != "")
			{
				additionalInfoTemp = _additionalInfo = ". - " + _additionalInfo + ". - ";
			}
			// Формат меняется в зависимости от количества авторов
			switch (_authors.Count)
			{
				case 1:
					return firstPart + _authors[0].GetInitials() + ' ' + _authors[0].GetSurname() + additionalInfoTemp + publicationInfo;
				case 2:
					return firstPart + allAuthors + additionalInfoTemp + publicationInfo;
				case 3:
					return firstPart + allAuthors + additionalInfoTemp + publicationInfo;
				default:
					return _title + " : " + _materialType + " / " + allAuthors + additionalInfoTemp + publicationInfo;
			}
		}
	}
}
