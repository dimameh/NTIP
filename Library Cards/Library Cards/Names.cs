using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
	public class Names
	{
		//Private переменные и методы
		//----------------------------------------------
		/// <summary>
		/// Фамилия
		/// </summary>
		private string _surname;
		/// Имя
		/// </summary>
		private string _name;
		/// <summary>
		/// Отчество
		/// </summary>
		private string _patronymic;
		/// <summary>
		/// Выбрасывает исключения если одно из полей класса не заполнено
		/// Если передать true, то заполненность фамилии не будет проверяться
		/// </summary>
		private void FillingExceptions(bool isInitials = false)
		{
			if (isInitials == false && _surname == "")
			{
				throw new Exception("No surname: ");
			}
			else if (_name == "")
			{
				throw new Exception("No name");
			}
			else if (_patronymic == "")
			{
				throw new Exception("No patronymic");
			}
		}
		//Конструктор
		Names(string surname = "", string name = "", string patronymic = "")
		{
			_surname = surname;
			_name = name;
			_patronymic = patronymic;
		}

		public Names()
		{
			_surname = "";
			_name = "";
			_patronymic = "";
		}

		/// <summary>
		/// Заполнены ли все поля класса
		/// true если заполнены, false если не заполнены
		/// </summary>
		/// <returns>true если заполнены, false если не заполнены</returns>
		//Public методы
		//----------------------------------------------
		public bool IsNameFilled()
		{
			if (_surname == "")
			{
				return false;
			}
			else if (_name == "")
			{
				return false;
			}
			else if (_patronymic == "")
			{
				return false;
			}
			return true;
		}
		/// <summary>
		/// Проверка имен собственных на корректность ввода
		/// </summary>
		/// <param noun="noun"></param>
		/// <returns>true если введено корректно, false если некорректно</returns>
		public static bool IsProperNoun(string noun)
		{
			//Не может быть пустой строкой
			if (string.IsNullOrWhiteSpace(noun))
			{
				return false;
			}
			//Не может начинаться и заканчиваться тире
			if (noun[0] == '-' || noun[noun.Length-1] == '-')
			{
				return false;
			}
			//Может содержать только буквы латинского алфавита и тире, которые не могут идти по два подряд
			for (int i = 0; i < noun.Length; i++)
			{
				if (!((noun[i] >= 'А' && noun[i] <= 'Я') || (noun[i] >= 'а' && noun[i] <= 'я') || ((noun[i] == '-') && (noun[i + 1] != '-'))))
				{
					return false;
				}
			}
			//Должно начинаться с большой буквы
			if (noun[0] >= 'а' && noun[0] <= 'я')
			{
				return false;
			}
			//Не может быть двух заглавных букв подряд
			for (int i = 0; i < noun.Length; i++)
			{
				if ((noun[i] >= 'А' && noun[i] <= 'Я') && (noun[i + 1] >= 'А' && noun[i + 1] <= 'Я'))
				{
					return false;
				}
			}
			return true;
		}
		/// <summary>
		/// Возвращает фамилия
		/// </summary>
		/// <returns>фамилия</returns>
		public string GetSurname() => _surname;
		/// <summary>
		/// Задать Имя
		/// </summary>
		/// <param name="Surname"></param>
		public void SetSurname(string value)
		{
			if (IsProperNoun(value))
			{
				_surname = value;
			}
			else
			{
				throw new Exception("Incorrect surname: " + _surname);
			}
		}
		/// <summary>
		///  Возвращает имя
		/// </summary>
		/// <returns>имя</returns>
		public string GetName() => _name;
		/// <summary>
		/// Задать Имя
		/// </summary>
		/// <param name="Name"></param>
		public void SetName(string value)
		{
			if (IsProperNoun(value))
			{
				_name = value;
			}
			else
			{
				throw new Exception("Incorrect name: " + _name);
			}
		}
		/// <summary>
		///  Возвращает фамилию
		/// </summary>
		/// <returns>фамилия</returns>
		public string GetPatronymic() => _patronymic;
		/// <summary>
		/// Задать Отчество
		/// </summary>
		/// <param name="Patronymic"></param>
		public void SetPatronymic(string value)
		{
			if (IsProperNoun(value))
			{
				_patronymic = value;
			}
			else
			{
				throw new Exception("Incorrect patronymic: " + _patronymic);
			}
		}
		/// <summary>
		/// Возвращает строку в формате "Фамилия, И. О."
		/// </summary>
		/// <returns>Surname + ", " + Name[0] + ". " + Patronymic[0] + '.'</returns>
		public string GetSurnameWithInitials()
		{
			FillingExceptions();
			return _surname + ", " + _name[0] + ". " + _patronymic[0] + '.';
		}
		/// <summary>
		/// Возвращает инициалы в формате "И. О."
		/// </summary>
		/// <returns>Name[0] + ". " + Patronymic[0] + '.'</returns>
		public string GetInitials()
		{
			FillingExceptions(true);
			return _name[0] + ". " + _patronymic[0] + '.';
		}
		/// <summary>
		/// Возваращает строку содержащую полные ФИО в формате "Фамилия Имя Отчество"
		/// </summary>
		/// <returns>Surname + ' ' + Name + ' ' + Patronymic</returns>
		public string GetFullName()
		{
			FillingExceptions();
			return _surname + ' ' + _name + ' ' + _patronymic;
		}
	}
}
