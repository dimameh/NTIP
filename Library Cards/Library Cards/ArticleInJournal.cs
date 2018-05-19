using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
    /// <summary>
    /// Статья в журнале
    /// </summary>
    public class ArticleInJournal : ICard
	{
		#region Private переменные и методы
		/// <summary>
		/// Первый автор статьи
		/// </summary>
		private FullName _firstAuthor;
		/// <summary>
		/// Автор(ры) статьи
		/// </summary>
		private List<FullName> _authors;
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
			if (_firstAuthor == null)
			{
				throw new Exception("No authors");
			}
			else if (_firstAuthor == null)
			if (Title == "")
			{
				throw new Exception("No title");
			}
			else if (MaterialType == "")
			{
				throw new Exception("No material type");
			}
			else if (JournalNumber == -1)
			{
				throw new Exception("No journal number");
			}
			else if (Year == -1)
			{
				throw new Exception("No year");
			}
			else if (FirstPage == -1)
			{
				throw new Exception("No first page");
			}
			else if (LastPage == -1)
			{
				throw new Exception("No last page");
			}
		}
		#endregion

		/// <summary>
		/// Конструктор без доп. параметров
		/// </summary>
		/// <param name="author"></param>
		public ArticleInJournal(FullName author)
		{
			AddAuthor(author);
			Title = "";
			MaterialType = "";
			JournalNumber = -1;
			FirstPage = -1;
			LastPage = -1;
			Year = -1;
		}
		/// <summary>
		/// Конструктор с доп. параметрами
		/// </summary>
		/// <param name="authors"></param>
		/// <param name="title"></param>
		/// <param name="materialType"></param>
		/// <param name="journalNumber"></param>
		/// <param name="firstPage"></param>
		/// <param name="lastPage"></param>
		/// <param name="year"></param>
		public ArticleInJournal(List<FullName> authors, string title = "", string materialType = "", int journalNumber = -1, int firstPage = -1, int lastPage = -1, int year = -1)
		{
			SetAuthors(authors);
			Title = title;
			MaterialType = materialType;
			JournalNumber = journalNumber;
			FirstPage = firstPage;
			LastPage = lastPage;
			Year = year;
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
			if(_authors != null)
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
			if (_firstAuthor != null)
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
		/// Возвращает и задает номер журнала
		/// </summary>
		public int JournalNumber
		{
			get => _journalNumber;
			set
			{
				if(value >=0)
				{
					_journalNumber = value;
				}
			}
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
		/// Возвращает и задает год издания
		/// </summary>
		public int Year
		{
			get => _year;
			set
			{
				if (value > 0 && value <= DateTime.Now.Year)
				{
					_year = value;
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
				allAuthors += _firstAuthor.Initials + ' ' + _firstAuthor.Surname + ", ";
				for (int i = 1; i < _authors.Count - 1; i++)
				{
					allAuthors += _authors[i].Initials + ' ' + _authors[i].Surname + ", ";
				}
				allAuthors += _authors[_authors.Count - 1].Initials + ' ' + _authors[_authors.Count - 1].Surname;
				allAuthors += ' ';
				//Первая часть карточки, один автор, название и тип материала
				string firstPart = _firstAuthor.SurnameWithInitials + ' ' + Title + " / " + allAuthors + " // ";

				//Информация о публикации
				string publicationInfo = MaterialType + ". - " + Year + ". - №" + JournalNumber + ". - C. " + FirstPage + ' ' + LastPage + '.';
				//Генерация нужной строки

				return firstPart + publicationInfo;
			}
		}
		#endregion
	}
}