using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
	/// <summary>
	/// Диссертация
	/// </summary>
	public class Dissertation : ICards
	{
		/// <summary>
		/// Имя автора диссертации
		/// </summary>
		private Names _author;
		/// <summary>
		/// Название диссертации
		/// </summary>
		private string _title;
		/// <summary>
		/// Страница с информацией на которую ссылается автор
		/// </summary>
		private int _page;
		/// <summary>
		/// Научная степень автора диссертации
		/// </summary>
		private string _authorStatus;
		/// <summary>
		/// Год публикации
		/// </summary>
		private int _year;
		/// <summary>
		/// город публикации
		/// </summary>
		private string _cityOfPublication;
		/// <summary>
		/// Номер специализации в формате 00.00.00
		/// </summary>
		private string _specializationNumber;
		/// <summary>
		/// Проверка строки является ли она номером специализации
		/// </summary>
		/// <param name="CheckingString"></param>
		/// <returns>true если строка является номером специализации, false если не является</returns>
		private bool IsSpecializationNumber(string value)
		{
			//Строка всегда должна быть 8 символов в длина
			if (value.Length != 8)
			{
				return false;
			}
			for (int i = 0; i < 8; i++)
			{
				//Третий и пятый символы строки это точки-разделители
				if ((i == 2 || i == 5) && value[i] != '.')
				{
					return false;
				}
				//остальные символы строки должны быть цифрами от 0 до 9
				else if (!(value[i] >= '0' && value[i] <= '9'))
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// Формирует ошибку если одно из полей не заполнено
		/// </summary>
		private void FillingExceptions()
		{
			if (!_author.IsNameFilled())
			{
				throw new Exception("No author");
			}
			else if (_title == "")
			{
				throw new Exception("No title");
			}
			else if (_page == 1)
			{
				throw new Exception("No page");
			}
			else if (_authorStatus == "")
			{
				throw new Exception("No author status");
			}
			else if (_year == -1)
			{
				throw new Exception("No year");
			}
			else if (_cityOfPublication == "")
			{
				throw new Exception("No city of publication");
			}
			else if (_authorStatus == "")
			{
				throw new Exception("No specialization number");
			}
		}

		//Конструкторы
		public Dissertation()
		{
			_title = "";
			_page = -1;
			_authorStatus = "";
			_year = -1;
			_cityOfPublication = "";
			_specializationNumber = "00.00.00";
		}
		public Dissertation(Names author, string title = "", int page = -1, string authorStatus = "", int year = -1, string cityOfPublication = "", string specializationNumber = "00.00.00")
		{
			_author = author;
			_title = title;
			_page = page;
			_authorStatus = authorStatus;
			_year = year;
			_cityOfPublication = cityOfPublication;
			_specializationNumber = specializationNumber;
		}
		
		//Public методы
		//----------------------------------------------
		/// <summary>
		/// Возвращает имя автора диссертиции
		/// </summary>
		public Names Author => _author;
		/// <summary>
		/// Возвращает название диссертации
		/// </summary>
		public string Title => _title;
		/// <summary>
		/// Возвращает страницу на которую ссылается автор
		/// </summary>
		public int Page => _page;
		/// <summary>
		/// Возвращает научную степень автора диссертации
		/// </summary>
		public string AuthorStatus => _authorStatus;
		/// <summary>
		/// Возвращает год публикации диссертации
		/// </summary>
		/// <returns>год публикации диссертации</returns>
		public int Year => _year;
		/// <summary>
		/// Возвращает город, в котором была представлена диссертация
		/// </summary>
		/// <returns>город, в котором была представлена диссертация</returns>
		public string CityOfPublication => _cityOfPublication;
		/// <summary>
		/// Возвращает номер специализации в виде строки string "00.00.00"
		/// </summary>
		/// <returns>номер специализации в виде строки string "00.00.00"</returns>
		public string SpecializationNumber => _specializationNumber;

		/// <summary>
		/// Задать автора
		/// </summary>
		/// <param name="author"></param>
		public void SetAuthor(Names author)
		{
			_author = author;
		}
		/// <summary>
		/// Задать название
		/// </summary>
		/// <param name="title"></param>
		public void SetTitle(string title)
		{
			_title = title;
		}
		/// <summary>
		/// Задать страницу
		/// </summary>
		/// <param name="page"></param>
		public void SetPage(int page)
		{
			_page = page;
		}
		/// <summary>
		/// Задать научную степень автора
		/// </summary>
		/// <param name="authorStatus"></param>
		public void SetAuthorStatus(string authorStatus)
		{
			_authorStatus = authorStatus;
		}
		/// <summary>
		/// Задать номер специализации
		/// </summary>
		/// <param name="SpecializationNumber"></param>
		public void SetSpecializationNumber(string value)
		{
			if(IsSpecializationNumber(value))
			{
				_specializationNumber = value;
			}
			else
			{
				throw new Exception("Wrong specialization number: " + value + "\n It must be like <12.00.05>");
			}
		}
		/// <summary>
		/// Задать год публикации диссертации
		/// </summary>
		/// <param name="year"></param>
		public void SetYear(int year)
		{
			//проверка года на корректность ввода. Год публикации не может быть нулевым и не может быть больше чем сегодняшний день
			if (year > 0 && year < DateTime.Now.Year)
			{
				_year = year;
			}
			else
			{
				throw new Exception("Wrong year: " + year + " It must be higher than 0 and lower that today's date (" + DateTime.Now.Year + ')');
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
				throw new Exception("Wrong city: " + city);
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
			//Составные части результирующей строки
			//Первая часть карточки, один автор, название и тип материала
			string firstPart = _author.GetSurnameWithInitials() + ' ' + _title + " : дис. ..." + _authorStatus + " : " + _specializationNumber + " / " + _author.GetFullName() + ". - ";
			//Информация о публикации
			string publicationInfo = _cityOfPublication + ", " + _year + ". - " + _page + " c.";
			
			//Генерация нужной строки
			return firstPart + publicationInfo;
		}
	}
}
