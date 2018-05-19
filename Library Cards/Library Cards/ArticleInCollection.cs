using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
    /// <summary>
    /// Статья в сборнике
    /// </summary>
    public class ArticleInCollection : ICard
	{
		#region Private переменные и методы
		/// <summary>
		/// Первый автор сборника
		/// </summary>
		private FullName _firstAuthor;
		/// <summary>
		/// Авторы сборника
		/// </summary>
		private List<FullName> _authors;
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
			if (FirstAuthor == null)
			{
				throw new Exception("No authors");
			}
			else if (Title == "")
			{
				throw new Exception("No title");
			}
			else if (MaterialType == "")
			{
				throw new Exception("No material type");
			}
			else if (FirstPage == -1)
			{
				throw new Exception("No first page");
			}
			else if (LastPage == -1)
			{
				throw new Exception("No last page");
			}
			else if (Date == new DateTime(1,1,1))
			{
				throw new Exception("No date");
			}
			else if (CityOfPublication == "")
			{
				throw new Exception("No city");
			}
		}
		#endregion

		/// <summary>
		/// Конструктор без доп. параметров
		/// </summary>
		public ArticleInCollection(FullName firstAuthor)
		{
			AddAuthor(firstAuthor);
			Title = "";
			MaterialType = "";
			FirstPage = -1;
			LastPage = -1;
			Date = new DateTime(1, 1, 1);
			CityOfPublication = "";
		}
		/// <summary>
		/// Конструктор с заданием всех параметров
		/// </summary>
		/// <param name="authors"></param>
		/// <param name="date"></param>
		/// <param name="title"></param>
		/// <param name="materialType"></param>
		/// <param name="firstPage"></param>
		/// <param name="lastPage"></param>
		/// <param name="cityOfPublication"></param>
		public ArticleInCollection(List<FullName> authors, DateTime date, string title = "", string materialType = "", int firstPage = -1, int lastPage = -1, string cityOfPublication = "")
		{
			SetAuthors(authors);
			Title = title;
			MaterialType = materialType;
			FirstPage = firstPage;
			LastPage = lastPage;
			Date = date;
			CityOfPublication = cityOfPublication;
		}

		#region Public методы
		/// <summary>
		/// Присоединить к списку имеющихся авторов еще один список
		/// </summary>
		/// <param name="authors"></param>
		public void AddAuthors(List<FullName> authors)
		{
			if (authors != null)
			{
				if (_authors != null)
				{
					_authors.AddRange(authors);
				}
				else
				{
					_authors = authors;
					_firstAuthor = authors[0];
				}
			}
		}
		/// <summary>
		/// Задать новый списов авторов
		/// </summary>
		/// <param name="authors"></param>
		public void SetAuthors(List<FullName> authors)
		{
			if (_authors != null)
			{
				RemoveAllAuthors();
			}
			if (authors != null)
			{
				AddAuthors(authors);
			}
		}
		/// <summary>
		/// Добавить одного автора
		/// </summary>
		/// <param name="author"></param>
		public void AddAuthor(FullName author)
		{
			if (author != null)
			{
				_authors.Add(author);
				if (_authors.Count == 1)
				{
					_firstAuthor = author;
				}
			}
		}
		/// <summary>
		/// Очистить список авторов
		/// </summary>
		public void RemoveAllAuthors()
		{
			if (FirstAuthor != null)
			{
				_firstAuthor = null;
				_authors.Clear();
			}
		}
		/// <summary>
		/// Удалить указанного автора из списка
		/// </summary>
		/// <param name="author"></param>
		public void RemoveAuthor(FullName author)
		{
			if (author != null)
			{
				_authors.Remove(author);
				if (_authors.Count == 0)
				{
					_firstAuthor = null;
				}
			}
		}

		#region Get Set свойства
		/// <summary>
		/// Возвращает и задает имя автора диссертиции
		/// </summary>
		public FullName FirstAuthor
		{
			get => _firstAuthor;
		}
		/// <summary>
		/// Возвращает и задает Название
		/// </summary>
		public string Title
		{
			get => _title;
			set => _title = value;
		}
		/// <summary>
		/// Возвращает и задает Тип материала
		/// </summary>
		public string MaterialType
		{
			get => _materialType;
			set => _materialType = value;
		}
		/// <summary>
		/// Возвращает и задает Номер первой страницы
		/// </summary>
		public int FirstPage
		{
			get => _firstPage;
			set
			{
				if (value > 0)
				{
					_firstPage = value;
				}
			}
		}
		/// <summary>
		/// Возвращает и задает Номер последней страницы
		/// </summary>
		public int LastPage
		{
			get => _lastPage;
			set
			{
				if (value > 0)
				{
					_lastPage = value;
				}
			}
		}
		/// <summary>
		/// Возвращает и задает Дату публикации
		/// </summary>
		/// <returns>дата публикации</returns>
		public DateTime Date
		{
			get => _date;
			set
			{
				if (value > new DateTime(1, 1, 1) && value <= DateTime.Now)
				{
					_date = value;
				}
				else
				{
					throw new Exception("Wrong date");
				}
			}
		}
		/// <summary>
		/// Возвращает и задает Город, в котором был представлен сборник
		/// </summary>
		/// <returns>город, в котором был представлен сборник</returns>
		public string CityOfPublication
		{
			get => _cityOfPublication;
			set
			{
				if (FullName.IsProperNoun(value))
				{
					_cityOfPublication = value;
				}
				else
				{
					throw new Exception("Wrong city");
				}
			}
		}
		#endregion

		/// <summary>
		/// Формирует строку типа string которая ялвяется библиографической информацией об издании, оформленной по ГОСТу 7.1 - 2003 "Библиографическая запись"
		/// </summary>
		/// <returns>Всю информацию об издании</returns>
		public string BibliographyInfo
		{
			get
			{
				//Проверка заполнены ли все поля
				FillingExceptions();

				//составные части результирующей строки
				//Все авторы издания
				string allAuthors = "";
				allAuthors += FirstAuthor.Initials + ' ' + FirstAuthor.Surname + ", ";
				for (int i = 1; i < _authors.Count - 1; i++)
				{
					allAuthors += _authors[i].Initials + ' ' + _authors[i].Surname + ", ";
				}
				allAuthors += _authors[_authors.Count - 1].Initials + ' ' + _authors[_authors.Count - 1].Surname;
				allAuthors += ' ';
				//Первая часть карточки, один автор, название и тип материала
				string firstPart = FirstAuthor.SurnameWithInitials + ' ' + Title + " / " + allAuthors + " // ";

				//Информация о публикации
				string publicationInfo = MaterialType + ", " + Date.ToLongDateString() + ", г. " + CityOfPublication + ". - " + CityOfPublication + ", " + Date.Year + ". - C. " + FirstPage + '-' + LastPage + '.';
				//Генерация нужной строки

				return firstPart + publicationInfo;
			}
		}
		#endregion
	}
}