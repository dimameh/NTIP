using System;
using System.Runtime.Serialization;

namespace LibraryCards
{
	/// <summary>
	///     Карточка диссертации
	/// </summary>
	[DataContract]
	public class DissertationCard : ICard
	{
		#region Private переменные и методы

		/// <summary>
		///     Имя автора диссертации
		/// </summary>
		private FullName _firstAuthor;

		/// <summary>
		///     Название диссертации
		/// </summary>
		private string _title;

		/// <summary>
		///     Страница с информацией на которую ссылается автор
		/// </summary>
		private int _page;

		/// <summary>
		///     Научная степень автора диссертации
		/// </summary>
		private string _scienceDegree;

		/// <summary>
		///     Год публикации
		/// </summary>
		private int _year;

		/// <summary>
		///     Город публикации
		/// </summary>
		private string _cityOfPublication;

		/// <summary>
		///     Номер специализации в формате 00.00.00
		/// </summary>
		private string _specializationNumber;

		/// <summary>
		///     Проверка строки является ли она номером специализации
		/// </summary>
		/// <param name="CheckingString"></param>
		/// <returns>true если строка является номером специализации, false если не является</returns>
		private bool IsSpecializationNumber(string value)
		{
			//Строка всегда должна быть 8 символов в длина
			if (value.Length != 8) return false;
			for (var i = 0; i < 8; i++)
				//Третий и пятый символы строки это точки-разделители
				if (i == 2 || i == 5)
				{
					if ((i == 2 || i == 5) && value[i] != '.') return false;
				}
				//остальные символы строки должны быть цифрами от 0 до 9
				else if (!(value[i] >= '0' && value[i] <= '9'))
				{
					return false;
				}

			return true;
		}

		/// <summary>
		///     Формирует ошибку если одно из полей не заполнено
		/// </summary>
		private void FillingExceptions()
		{
			if (FirstAuthor == null)
				throw new Exception("No authors");
			if (Title == "")
				throw new Exception("No title");
			if (Page == 1)
				throw new Exception("No page");
			if (AuthorStatus == "")
				throw new Exception("No author status");
			if (Year == -1)
				throw new Exception("No year");
			if (CityOfPublication == "")
				throw new Exception("No city of publication");
			if (SpecializationNumber == "") throw new Exception("No specialization number");
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
		///     Конструктор с доп. параметрами
		/// </summary>
		/// <param name="author"></param>
		/// <param name="title"></param>
		/// <param name="page"></param>
		/// <param name="authorStatus"></param>
		/// <param name="year"></param>
		/// <param name="cityOfPublication"></param>
		/// <param name="specializationNumber"></param>
		public DissertationCard(FullName author, string title, int page, string authorStatus, int year, string cityOfPublication,
			string specializationNumber)
		{
			_firstAuthor = author;
			Title = title;
			Page = page;
			AuthorStatus = authorStatus;
			Year = year;
			CityOfPublication = cityOfPublication;
			SpecializationNumber = specializationNumber;
		}

		#endregion

		#region Public методы

		/// <summary>
		///     Задать автора
		/// </summary>
		/// <param name="authors"></param>
		public void SetAuthor(FullName author)
		{
			if (author != null) _firstAuthor = author;
		}

		/// <summary>
		///     Удалить автора
		/// </summary>
		public void RemoveAuthor()
		{
			_firstAuthor = null;
		}

		#region Get Set свойства

		/// <summary>
		///     Возвращает и задает имя первого автора издания
		/// </summary>
		[DataMember]
		public FullName FirstAuthor
		{
			get => _firstAuthor;
			set
			{
				if (value != null)
				{
					_firstAuthor = value;
				}
				else
				{
					throw new Exception("Author can't be null");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает название диссертации
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
		///     Возвращает и задает страницу диссертации
		/// </summary>
		[DataMember]
		public int Page
		{
			get => _page;
			set
			{
				if (value > 0)
				{
					_page = value;
				}
				else
				{
					throw new Exception("FirstPage can't be less or equal 0");
				}
			}
		}

		/// <summary>
		///     Возвращает и задает научную степень автора диссертации
		/// </summary>
		[DataMember]
		public string AuthorStatus
		{
			get => _scienceDegree;
			set
			{
				StringExceptions(value);
				_scienceDegree = value;
			}
		}

		/// <summary>
		///     Возвращает и задает год публикации диссертации
		/// </summary>
		/// <returns>год публикации диссертации</returns>
		[DataMember]
		public int Year
		{
			get => _year;
			set
			{
				//проверка года на корректность ввода. Год публикации не может быть нулевым и не может быть больше чем сегодняшний день
				if (value > 0 && value < DateTime.Now.Year)
					_year = value;
				else
					throw new Exception("Wrong year: " + value + " It must be higher than 0 and lower that today's date (" +
					                    DateTime.Now.Year + ')');
			}
		}

		/// <summary>
		///     Возвращает и задает город, в котором была представлена диссертация
		/// </summary>
		/// <returns>город, в котором был представлен сборник</returns>
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

		/// <summary>
		///     Возвращает и задает номер специализации в виде строки string "00.00.00"
		/// </summary>
		/// <returns>номер специализации в виде строки string "00.00.00"</returns>
		[DataMember]
		public string SpecializationNumber
		{
			get => _specializationNumber;
			set
			{
				if (IsSpecializationNumber(value))
					_specializationNumber = value;
				else
					throw new Exception("Wrong specialization number: " + value + "\n It must be like 12.00.05");
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
				//Составные части результирующей строки
				//Первая часть карточки, один автор, название и тип материала
				FullName tempQualifier = FirstAuthor;
				var firstPart = tempQualifier.Surname + ", " + tempQualifier.Name[0] + ". " + tempQualifier.Patronymic[0] + '.' + ' ' + Title + " : дис. ..." + AuthorStatus + " : " +
				                SpecializationNumber + " / " + FirstAuthor.GetFullName() + ". - ";
				//Информация о публикации
				var publicationInfo = CityOfPublication + ", " + Year + ". - " + Page + " c.";

				//Генерация нужной строки
				return firstPart + publicationInfo;
			}
		}

		#endregion
	}
}