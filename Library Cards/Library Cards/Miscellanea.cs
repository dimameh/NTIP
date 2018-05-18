using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
    //TODO: не стандартное слово для сборника.
    //TODO: Это не сборник, а СТАТЬЯ в сборнике. Разве нет?
    /// <summary>
    /// Сборник
    /// </summary>
    public class Miscellanea : ICards
	{
		//Private переменные и методы
		//----------------------------------------------
		/// <summary>
		/// Авторы сборника
		/// </summary>
		private List<Names> _authors;
		/// <summary>
		/// Название/тема сборника
		/// </summary>
		private string _title = "";
		/// <summary>
		/// Информация о тематике сборника и о том откуда взяты материалы для него
		/// </summary>
		private string _materialType = "";
		/// <summary>
		/// Первая ссылаемая страница
		/// </summary>
		private int _firstPage = -1;
		/// <summary>
		/// Последняя ссылаемая страница
		/// </summary>
		private int _lastPage = -1;
		/// <summary>
		/// Дата публикации
		/// </summary>
		private DateTime _date = new DateTime(1,1,1);
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
			else if (_firstPage == -1)
			{
				throw new Exception("No first page");
			}
			else if (_lastPage == -1)
			{
				throw new Exception("No last page");
			}
			else if (_date == new DateTime(1,1,1))
			{
				throw new Exception("No date");
			}
			else if (_cityOfPublication == "")
			{
				throw new Exception("No city");
			}
		}

		//Конструкторы
		public Miscellanea()
		{
			_title = "";
			_materialType = "";
			_firstPage = -1;
			_lastPage = -1;
			_date = new DateTime(1, 1, 1);
			_cityOfPublication = "";
		}

        //TODO: А у статьи в сборнике может быть только два автора? Или всё-таки от 1 до n?
        public Miscellanea(Names author1, Names author2, DateTime date, string title = "", string materialType = "", int firstPage = -1, int lastPage = -1, string cityOfPublication = "")
		{
			_authors = new List<Names> { author1, author2 };
			_title = title;
			_materialType = materialType;
			_firstPage = firstPage;
			_lastPage = lastPage;
			_date = date;
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
		/// Возвращает тематику сборника
		/// </summary>
		public string MaterialType => _materialType;
		/// <summary>
		/// Возвращает номер первой страницы
		/// </summary>
		public int FirstPage => _firstPage;
		/// <summary>
		/// Возвращает номер последней страницы
		/// </summary>
		public int LastPage => _lastPage;
		/// <summary>
		/// Возвращает дату публикации
		/// </summary>
		/// <returns>дата публикации</returns>
		public DateTime Date => _date;
		/// <summary>
		/// Возвращает город, в котором был представлен сборник
		/// </summary>
		/// <returns>город, в котором был представлен сборник</returns>
		public string CityOfPublication => _cityOfPublication;

		/// <summary>
		/// Задать название
		/// </summary>
		/// <param name="title"></param>
		public void SetTitle(string title)
		{
			_title = title;
		}
		/// <summary>
		/// Задать тему
		/// </summary>
		/// <param name="materialType"></param>
		public void SetMaterialType(string materialType)
		{
			_materialType = materialType;
		}
		/// <summary>
		/// Задать первую страницу
		/// </summary>
		/// <param name="page"></param>
		public void SetFirstPage(int page)
		{
			if (page > 0)
			{
				_firstPage = page;
			}
		}
		/// <summary>
		/// Задать последнюю страницу
		/// </summary>
		/// <param name="page"></param>
		public void SetLastPage(int page)
		{
			if (page > 0)
			{
				_lastPage = page;
			}
		}
		/// <summary>
		/// Задать дату публикации
		/// </summary>
		/// <param name="date"></param>
		public void SetDate(DateTime date)
		{
			if (date > new DateTime(0,0,0) && date <= DateTime.Now)
			{
				_date = date;
			}
			else
			{
				throw new Exception("Wrong date");
			}
		}
		/// <summary>
		/// Задать город, в котором была представлена диссертация
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
            //TODO: зачем try catch, если ты все равно прокидываешь пойманное исключение выше?
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

			//Все авторы издания
			string allAuthors = "";
			for (int i = 0; i < _authors.Count - 1; i++)
			{
				allAuthors += _authors[i].GetInitials() + ' ' + _authors[i].GetSurname() + ", ";
			}
			allAuthors += _authors[_authors.Count - 1].GetInitials() + ' ' + _authors[_authors.Count - 1].GetSurname();
			allAuthors += ' ';
			//Первая часть карточки, один автор, название и тип материала
			string firstPart = _authors[0].GetSurnameWithInitials() + ' ' + _title + " / " + allAuthors + " // ";

			//Информация о публикации
			string publicationInfo = _materialType + ", " + _date.ToLongDateString() + ", г. " + _cityOfPublication + ". - " + _cityOfPublication + ", " + _date.Year + ". - C. " + _firstPage + '-' +  _lastPage + '.';
			//Генерация нужной строки

			return firstPart + publicationInfo;
		}
	}
}
