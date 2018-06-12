using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LibraryCards
{
	/// <summary>
	///     Карточка сборника
	/// </summary>
	[DataContract]
	public class CollectionCard : ICard
	{
		#region Private переменные и методы

		/// <summary>
		///     Первый автор сборника
		/// </summary>
		private FullName _firstAuthor;

		/// <summary>
		///     Авторы сборника
		/// </summary>
		private List<FullName> _authors;

		/// <summary>
		///     Название/тема сборника
		/// </summary>
		private string _title;

		/// <summary>
		///     Информация о тематике сборника и о том откуда взяты материалы для него
		/// </summary>
		private string _materialType;

		/// <summary>
		///     Первая ссылаемая страница
		/// </summary>
		private int _firstPage;

		/// <summary>
		///     Последняя ссылаемая страница
		/// </summary>
		private int _lastPage;

		/// <summary>
		///     Дата публикации
		/// </summary>
		private DateTime _date;

		/// <summary>
		///     Город публикации
		/// </summary>
		private string _cityOfPublication;

		/// <summary>
		///     Формирует ошибку если одно из полей не заполнено
		/// </summary>
		private void FillingExceptions()
		{
			if (FirstAuthor == null)
				throw new Exception("No authors");
			if (Title == "")
				throw new Exception("No title");
			if (MaterialType == "")
				throw new Exception("No material type");
			if (FirstPage == -1)
				throw new Exception("No first page");
			if (LastPage == -1)
				throw new Exception("No last page");
			if (Date == new DateTime(1, 1, 1))
				throw new Exception("No date");
			if (CityOfPublication == "") throw new Exception("No city");
		}

		/// <summary>
		/// Формирует ошибку если поле начинается или заканчивается пробелом либо пустое или null
		/// </summary>
		/// <param name="value"></param>
		private void StringExceptions(string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (value[0] == ' ' || value[value.Length - 1] == ' ')
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
		///     Конструктор с заданием всех параметров
		/// </summary>
		/// <param name="authors"></param>
		/// <param name="date"></param>
		/// <param name="title"></param>
		/// <param name="materialType"></param>
		/// <param name="firstPage"></param>
		/// <param name="lastPage"></param>
		/// <param name="cityOfPublication"></param>
		public CollectionCard(List<FullName> authors, DateTime date, string title, string materialType, int firstPage,
			int lastPage, string cityOfPublication)
		{
			SetAuthors(authors);
			Title = title;
			MaterialType = materialType;
			FirstPage = firstPage;
			LastPage = lastPage;
			Date = date;
			CityOfPublication = cityOfPublication;
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
		/// <summary>
		/// Авторы издания
		/// </summary>
		[DataMember]
		public List<FullName> Authors
		{
			get
			{
				List<FullName> authorsCopy = new List<FullName>(_authors);
				return authorsCopy;
			}
			set => SetAuthors(value);
		}

		/// <summary>
		///     Возвращает и задает имя первого автора издания
		/// </summary>
		public FullName FirstAuthor => _firstAuthor;

		/// <summary>
		///     Возвращает и задает название
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
		///     Возвращает и задает тип материала
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
		///     Возвращает и задает номер первой страницы
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
		///     Возвращает и задает номер последней страницы
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
					throw new Exception("LastPage can't be less than FirstPage or less or equal 0");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает дату публикации
		/// </summary>
		[DataMember]
		public DateTime Date
		{
			get => _date;
			set
			{
				if (value > new DateTime(1, 1, 1) && value <= DateTime.Now)
					_date = value;
				else
					throw new Exception("Wrong date");
			}
		}

		/// <summary>
		///     Возвращает и задает город, в котором был представлен сборник
		/// </summary>
		[DataMember]
		public string CityOfPublication
		{
			get => _cityOfPublication;
			set
			{
				bool isCompoundWord = false;
				for (int i = 0; i < value.Length; i++)
				{
					if (value[i] == ' ')
					{
						isCompoundWord = true;
						break;
					}
				}
				if (!isCompoundWord)
				{
					if (FullName.IsProperNoun(value))
						_cityOfPublication = value;
					else
						throw new Exception("City must be proper noun");
				}
				else
				{
					for (int i = 0; i < value.Length-1; i++)
					{
						if (value[i] == ' ' && value[i + 1] == ' ')
						{
							throw new Exception("Too many spaces in the city name");
						}
					}
					if (value[0] == ' ' || value[value.Length - 1] == ' ')
					{
						throw new Exception("City can't begin or end by space symbol");
					}

					string[] city = value.Split(' ');

					for (int i = 0; i < city.Length; i++)
					{
						if (!FullName.IsProperNoun(city[i]))
						{
							throw new Exception("City must be proper noun");
						}
					}

					_cityOfPublication = value;
				}
			}
		}

		#endregion

		/// <summary>
		///     Формирует строку типа string которая является библиографической информацией об издании, оформленной по ГОСТу 7.1 -
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
				var firstPart = FirstAuthor.GetSurnameWithInitials() + ' ' + Title + " / " + allAuthors + " // ";

				//Информация о публикации
				var publicationInfo = MaterialType + ", " + Date.ToLongDateString() + ", г. " + CityOfPublication + ". - " +
				                      CityOfPublication + ", " + Date.Year + ". - C. " + FirstPage + '-' + LastPage + '.';
				//Генерация нужной строки

				return firstPart + publicationInfo;
			}
		}

		#endregion
	}
}