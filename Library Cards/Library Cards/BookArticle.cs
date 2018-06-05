using System;
using System.Collections.Generic;

namespace LibraryCards
{
	/// <summary>
	///     Статья в книгу
	/// </summary>
	public class BookArticle : ICard
	{
		#region Private переменные и методы

		/// <summary>
		///     Первый автор статьи
		/// </summary>
		private FullName _firstAuthor;

		/// <summary>
		///     Авторы
		/// </summary>
		private List<FullName> _authors;

		/// <summary>
		///     Название книги
		/// </summary>
		private string _title;

		/// <summary>
		///     Жанр
		/// </summary>
		private string _materialType;

		/// <summary>
		///     Издательство
		/// </summary>
		private string _publishingHouse;

		/// <summary>
		///     Номер издания и информация о нем
		/// </summary>
		private string _additionalInfo;

		/// <summary>
		///     Год издания
		/// </summary>
		private int _year;

		/// <summary>
		///     Объем в количестве страниц
		/// </summary>
		private int _volume;

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
			if (_title == "")
				throw new Exception("No title");
			if (_materialType == "")
				throw new Exception("No material type");
			if (_publishingHouse == "")
				throw new Exception("No publishing house");
			if (_year == -1)
				throw new Exception("No year");
			if (_volume == -1)
				throw new Exception("No volume");
			if (_cityOfPublication == "") throw new Exception("No city of publicaion");
		}

		/// <summary>
		/// Формирует ошибку если поле начинается или заканчивается пробелом либо путое или null
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
		///     Конструктор с доп. параметрами
		/// </summary>
		/// <param name="authors"></param>
		/// <param name="title"></param>
		/// <param name="materialType"></param>
		/// <param name="publishingHouse"></param>
		/// <param name="year"></param>
		/// <param name="volume"></param>
		/// <param name="cityOfPublication"></param>
		/// <param name="additionalInfo"></param>
		public BookArticle(List<FullName> authors, string title, string materialType, string publishingHouse, int year,
			int volume, string cityOfPublication, string additionalInfo = "")
		{
			SetAuthors(authors);
			Title = title;
			MaterialType = materialType;
			PublishingHouse = publishingHouse;
			AdditionalInfo = additionalInfo;
			Year = year;
			Volume = volume;
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

		public List<FullName> Authors
		{
			get
			{
				List<FullName> authorsCopy = new List<FullName>(_authors);
				return authorsCopy;
			}
		}

		/// <summary>
		///     Возвращает и задает имя автора диссертиции
		/// </summary>
		public FullName FirstAuthor => _firstAuthor;

		/// <summary>
		///     Возвращает и задает Название
		/// </summary>
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
		///     Возвращает и задает Город публикации
		/// </summary>
		public string PublishingHouse
		{
			get => _publishingHouse;
			set
			{
				StringExceptions(value);
				_publishingHouse = value;
			}
		}

		/// <summary>
		///     Возвращает и задает Номер издательства и информацию о нем
		/// </summary>
		public string AdditionalInfo
		{
			get => _additionalInfo;
			set => _additionalInfo = value;
		}

		/// <summary>
		///     Возвращает и задает Объем в количестве страниц
		/// </summary>
		public int Volume
		{
			get => _volume;
			set
			{
				if (value > 0)
					_volume = value;
				else
					throw new Exception("Wrong volume");
			}
		}

		/// <summary>
		///     Возвращает и задает год издания
		/// </summary>
		public int Year
		{
			get => _year;
			set
			{
				if (value > 0 && value <= DateTime.Now.Year) _year = value;
				else
				{
					throw new Exception("Wrong Year value. The year must be greater than 0 and less than today's");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает Город, в котором был представлен сборник
		/// </summary>
		/// <returns>город, в котором был представлен сборник</returns>
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
					for (int i = 0; i < value.Length - 1; i++)
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

				//Первая часть карточки, один автор, название и тип материала
				var firstPart = _firstAuthor.GetSurnameWithInitials() + ' ' + Title + " : " + MaterialType + " / ";
				//Все авторы издания
				var allAuthors = "";
				allAuthors += FirstAuthor.GetInitials() + ' ' + FirstAuthor.Surname + ", ";
				for (var i = 1; i < _authors.Count - 1; i++) allAuthors += _authors[i].GetInitials() + ' ' + _authors[i].Surname + ", ";
				allAuthors += _authors[_authors.Count - 1].GetInitials() + ' ' + _authors[_authors.Count - 1].Surname;
				allAuthors += ' ';
				//Информация о публикации
				var publicationInfo = ". - " + CityOfPublication + " : " + PublishingHouse + ", " + Year + ". - " + Volume + " c.";
				//Данное поле необязательное
				var additionalInfoTemp = "";
				if (AdditionalInfo != String.Empty && AdditionalInfo[0] != ' ' && AdditionalInfo[AdditionalInfo.Length - 1] != ' ' )
				{
					additionalInfoTemp = ". - " + AdditionalInfo;
				}
				// Формат меняется в зависимости от количества авторов
				switch (_authors.Count)
				{
					case 1:
						return firstPart + FirstAuthor.GetInitials() + ' ' + FirstAuthor.Surname + additionalInfoTemp + publicationInfo;
					case 2:
						return firstPart + allAuthors + additionalInfoTemp + publicationInfo;
					case 3:
						return firstPart + allAuthors + additionalInfoTemp + publicationInfo;
					default:
						return Title + " : " + MaterialType + " / " + allAuthors + additionalInfoTemp + publicationInfo;
				}
			}
		}

		#endregion
	}
}