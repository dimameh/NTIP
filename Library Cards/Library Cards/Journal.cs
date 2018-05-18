using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
    //TODO: аналогично Names и Miscellanea
    /// <summary>
    /// Журнал
    /// </summary>
    public class Journal : ICards
	{
		//Private переменные и методы
		//----------------------------------------------
		/// <summary>
		/// Автор(ры) статьи
		/// </summary>
		private List<Names> _authors;
		/// <summary>
		/// Название статьи
		/// </summary>
		private string _title;
		/// <summary>
		/// Название периодического издания
		/// </summary>
		private string _materialType;
		/// <summary>
		/// Номер выпуска
		/// </summary>
		private int _journalNumber;
		/// <summary>
		/// Начальная страница статьи
		/// </summary>
		private int _firstPage;
		/// <summary>
		/// Последняя страница статьи
		/// </summary>
		private int _lastPage;
		/// <summary>
		/// Год выпуска
		/// </summary>
		private int _year;
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
			else if (_journalNumber == -1)
			{
				throw new Exception("No journal number");
			}
			else if (_year == -1)
			{
				throw new Exception("No year");
			}
			else if (_firstPage == -1)
			{
				throw new Exception("No first page");
			}
			else if (_lastPage == -1)
			{
				throw new Exception("No last page");
			}
		}
		
		//Конструкторы
		public Journal()
		{
			_title = "";
			_materialType = "";
			_journalNumber = -1;
			_firstPage = -1;
			_lastPage = -1;
			_year = -1;
		}

        //TODO: А у журнальной статьи может быть только два автора? Или всё-таки от 1 до n?
		public Journal(Names author1, Names author2, string title = "", string materialType = "", int journalNumber = -1, int firstPage = -1, int lastPage = -1, int year = -1)
		{

			_authors = new List<Names> { author1, author2 };
			_title = title;
			_materialType = materialType;
			_journalNumber = journalNumber;
			_firstPage = firstPage;
			_lastPage = lastPage;
			_year = year;
		}

		//Public методы
		//----------------------------------------------
		/// <summary>
		/// Возвращает список авторов
		/// </summary>
		public List<Names> Authors => _authors;
		/// <summary>
		/// Возвращает название статьи
		/// </summary>
		public string Title => _title;
		/// <summary>
		/// Возвращает название периодического издания
		/// </summary>
		public string MaterialType => _materialType;
		/// <summary>
		/// Возвращает начальную страницу статьи
		/// </summary>
		public int FirstPage => _firstPage;
		/// <summary>
		/// Возвращает конечную страницу статьи
		/// </summary>
		public int LastPage => _lastPage;
		/// <summary>
		/// Возвращает год публикации статьи
		/// </summary>
		public int Year => _year;
		/// <summary>
		/// Задать название статьи
		/// </summary>
		/// <param name="title"></param>
		public void SetTitle(string title)
		{
			_title = title;
		}
		/// <summary>
		/// Задать название периодического издания
		/// </summary>
		/// <param name="materialType"></param>
		public void SetMaterialType(string materialType)
		{
			_materialType = materialType;
		}
		/// <summary>
		/// Задать началььную страницу статьи
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
		/// Задать конечную страницу статьи
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
		/// Задать год публикации статьи
		/// </summary>
		/// <param name="year"></param>
		public void SetYear(int year)
		{
			if (year > 0 && year <= DateTime.Now.Year)
			{
				_year = year;
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
			string publicationInfo = _materialType + ". - " + _year + ". - №" + _journalNumber + ". - C. " + _firstPage + ' ' + _lastPage + '.';
			//Генерация нужной строки

			return firstPart + publicationInfo;
		}
	}
}
