using System;
using System.Collections.Generic;

namespace LibraryCards
{
	/// <summary>
	///     Статья в книгу
	/// </summary>
	[Serializable]
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
		///     Задать новый списов авторов
		/// </summary>
		/// <param name="authors"></param>
		public void SetAuthors(List<FullName> authors)
		{
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
				_authors.Add(author);
				if (_authors.Count == 1) _firstAuthor = author;
			}
		}

		/// <summary>
		///     Очистить список авторов
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
			set => _title = value;
		}

		/// <summary>
		///     Возвращает и задает Тип материала
		/// </summary>
		public string MaterialType
		{
			get => _materialType;
			set => _materialType = value;
		}

		/// <summary>
		///     Возвращает и задает Город публикации
		/// </summary>
		public string PublishingHouse
		{
			get => _publishingHouse;
			set => _publishingHouse = value;
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
			}
		}

		/// <summary>
		///     Возвращает и задает Город публикации
		/// </summary>
		public string CityOfPublication
		{
			get => _cityOfPublication;
			set
			{
				if (FullName.IsProperNoun(value))
					_cityOfPublication = value;
				else
					throw new Exception("Wrong city");
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
				//Генерация нужной строки
				//Если
				var additionalInfoTemp = "";
				if (AdditionalInfo != "") additionalInfoTemp = ". - " + AdditionalInfo + ". - ";
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