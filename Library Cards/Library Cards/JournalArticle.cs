using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibraryCards
{
	/// <summary>
	///     Статья в журнале
	/// </summary>
	[DataContract]
	public class JournalArticle : ICard
	{
		#region Private переменные и методы

		/// <summary>
		///     Первый автор статьи
		/// </summary>
		private FullName _firstAuthor;

		/// <summary>
		///     Автор(ры) статьи
		/// </summary>
		private List<FullName> _authors;

		/// <summary>
		///     Название статьи
		/// </summary>
		private string _title;

		/// <summary>
		///     Название периодического издания
		/// </summary>
		private string _materialType;

		/// <summary>
		///     Номер выпуска
		/// </summary>
		private int _journalNumber;

		/// <summary>
		///     Начальная страница статьи
		/// </summary>
		private int _firstPage;

		/// <summary>
		///     Последняя страница статьи
		/// </summary>
		private int _lastPage;

		/// <summary>
		///     Год выпуска
		/// </summary>
		private int _year;

		/// <summary>
		///     Формирует ошибку если одно из полей не заполнено
		/// </summary>
		private void FillingExceptions()
		{
			if (FirstAuthor == null)
				throw new Exception("No authors");
			if (FirstAuthor == null)
				if (Title == "")
					throw new Exception("No title");
				else if (MaterialType == "")
					throw new Exception("No material type");
				else if (JournalNumber == -1)
					throw new Exception("No journal number");
				else if (Year == -1)
					throw new Exception("No year");
				else if (FirstPage == -1)
					throw new Exception("No first page");
				else if (LastPage == -1) throw new Exception("No last page");
		}

		/// <summary>
		/// Формирует ошибку если поле начинается или заканчивается пробелом либо путое или null
		/// </summary>
		/// <param name="value"></param>
		private void StringExceptions(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (value[0] == ' ' || value[value.Length-1] == ' ')
				{
					throw new Exception("Title can't start or end with a space");
				}
			}
			else
			{
				throw new Exception("Title can't be null or empty");
			}
		}

		#endregion

		#region Конструктор

		/// <summary>
		///     Конструктор с доп. параметрами
		/// </summary>
		/// <param name="authors"></param>
		/// <param name="title"></param>
		/// <param name="materialType"></param>
		/// <param name="journalNumber"></param>
		/// <param name="firstPage"></param>
		/// <param name="lastPage"></param>
		/// <param name="year"></param>
		public JournalArticle(List<FullName> authors, string title, string materialType, int journalNumber, int firstPage,
			int lastPage, int year)
		{
			SetAuthors(authors);
			Title = title;
			MaterialType = materialType;
			JournalNumber = journalNumber;
			FirstPage = firstPage;
			LastPage = lastPage;
			Year = year;
		}

		#endregion

		#region Public методы

		/// <summary>
		///     Присоединить к списку имеющихся авторов еще один список
		/// </summary>
		/// <param name="authors"></param>
		public void AddAuthors(List<FullName> authors)
		{
			if (authors != null || authors.Count == 0)
			{
				if (_authors != null)
				{
					_authors.AddRange(authors);
				}
				else
				{
					_authors = new List<FullName>(authors);
					_firstAuthor = authors[0];
				}
			}
			else
			{
				throw new Exception("Adding authors is null or empty");
			}
		}

		/// <summary>
		///     Задать новый списов авторов
		/// </summary>
		/// <param name="authors"></param>
		public void SetAuthors(List<FullName> authors)
		{
			if (authors == null || authors.Count == 0)
			{
				throw new Exception(" list is null or empty");
			}
			if (_authors != null) RemoveAllAuthors();
			if (authors != null) AddAuthors(authors);
		}

		/// <summary>
		///     Добавить одного автора
		/// </summary>
		/// <param name="author"></param>
		public void AddAuthor(FullName author)
		{
			if (author != null)
			{
				if (_authors != null)
				{
					_authors.Add(author);
				}
				else
				{
					_authors = new List<FullName>();
					_authors.Add(author);
					_firstAuthor = author;
				}
			}
			else
			{
				throw new Exception("Adding author is null");
			}
		}

		/// <summary>
		///     Очистить список авторов
		/// </summary>
		public void RemoveAllAuthors()
		{
			if (FirstAuthor != null)
			{
				_authors.Clear();
				_firstAuthor = null;
			}
		}

		/// <summary>
		///     Удалить указанного автора из списка
		/// </summary>
		/// <param name="author"></param>
		public void RemoveAuthor(FullName author)
		{
			if (author != null)
			{
				_authors.Remove(author);
				if (_authors.Count == 0) _firstAuthor = null;
			}
			else
			{
				throw new Exception("Removing author is null");
			}
		}

		#region Get Set свойства
		[DataMember]
		public List<FullName> Authors
		{
			get
			{
				List<FullName> authorsCopy = new List<FullName>(_authors);
				return authorsCopy;
			}
			set
			{
				SetAuthors(value);
			}
		}

		/// <summary>
		///     Возвращает имя автора статьи
		/// </summary>
		public FullName FirstAuthor
		{
			get => new FullName(_firstAuthor);
		}

		/// <summary>
		///     Возвращает и задает Название
		/// </summary>
		[DataMember]
		public string Title
		{
			get => _title;
			set
			{
				StringExceptions(value);
				_title = value;
			}
		}

		/// <summary>
		///     Возвращает и задает Тип материала
		/// </summary>
		[DataMember]
		public string MaterialType
		{
			get => _materialType;
			set
			{
				StringExceptions(value);
				_materialType = value;
			}
		}

		/// <summary>
		///     Возвращает и задает номер журнала
		/// </summary>
		[DataMember]
		public int JournalNumber
		{
			get => _journalNumber;
			set
			{
				if (value >= 0) _journalNumber = value;
				else
				{
					throw new Exception("JournalNumber can't be lower than 0");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает Номер первой страницы
		/// </summary>
		[DataMember]
		public int FirstPage
		{
			get => _firstPage;
			set
			{
				if (value > 0)
				{
					_firstPage = value;
				}
				else
				{
					throw new Exception("FirstPage can't be less or equal 0");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает Номер последней страницы
		/// </summary>
		[DataMember]
		public int LastPage
		{
			get => _lastPage;
			set
			{
				if (value >= FirstPage) _lastPage = value;
				else
				{
					throw new Exception("LastPage can't be less than FirstPage");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает год издания
		/// </summary>
		[DataMember]
		public int Year
		{
			get => _year;
			set
			{
				if (value > 0 && value <= DateTime.Now.Year) _year = value;
				else
				{
					throw new Exception("Year can't be lower than 0 and bigger than today\'s");
				}
			}
		}

		#endregion

		/// <summary>
		///     Формирует строку типа string которая ялвяется библиографической информацией об издании, оформленной по ГОСТу 7.1 -
		///     2003 "Библиографическая запись"
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
				var allAuthors = "";
				allAuthors += FirstAuthor.GetInitials() + ' ' + FirstAuthor.Surname + ", ";
				for (var i = 1; i < _authors.Count - 1; i++) allAuthors += _authors[i].GetInitials() + ' ' + _authors[i].Surname + ", ";
				allAuthors += _authors[_authors.Count - 1].GetInitials() + ' ' + _authors[_authors.Count - 1].Surname;
				allAuthors += ' ';
				//Первая часть карточки, один автор, название и тип материала
				FullName tempQualifier = FirstAuthor;
				var firstPart = tempQualifier.Surname + ", " + tempQualifier.Name[0] + ". " + tempQualifier.Patronymic[0] + '.' + ' ' + Title + " / " + allAuthors + " // ";

				//Информация о публикации
				var publicationInfo = MaterialType + ". - " + Year + ". - №" + JournalNumber + ". - C. " + FirstPage + ' ' +
				                      LastPage + '.';
				//Генерация нужной строки

				return firstPart + publicationInfo;
			}
		}

		#endregion
	}
}