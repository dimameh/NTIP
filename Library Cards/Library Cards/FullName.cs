using System;
using Newtonsoft.Json;

namespace LibraryCards
{
	/// <summary>
	///     ФИО
	/// </summary>
	public class FullName
	{
		#region Private переменные и методы

		/// <summary>
		///     Фамилия
		/// </summary>
		private string _surname;

		/// Имя
		/// </summary>
		private string _name;

		/// <summary>
		///     Отчество
		/// </summary>
		private string _patronymic;

		/// <summary>
		///     Конструктор
		/// </summary>
		/// <param name="surname"></param>
		/// <param name="name"></param>
		/// <param name="patronymic"></param>
		[JsonConstructor]
		public FullName(string surname, string name, string patronymic)
		{
			Surname = surname;
			Name = name;
			Patronymic = patronymic;
		}

		/// <summary>
		///     Конструктор копирования
		/// </summary>
		public FullName(FullName fullName)
		{
			Surname = fullName.Surname;
			Name = fullName.Name;
			Patronymic = fullName.Patronymic;
		}

		/// <summary>
		/// Получить язык строки
		/// "eng" если на английском, "rus" если на русском
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private static string GetLanguage(string text)
		{
			bool rus = false, eng = false;

			text = text.ToLower();

			byte[] Ch = System.Text.Encoding.Default.GetBytes(text);
			foreach (byte ch in Ch)
			{
				if ((ch >= 97) && (ch <= 122)) eng = true;
				if ((ch >= 224) && (ch <= 255)) rus = true;
			}

			if (eng & !rus) return "eng";
			if (rus & !eng) return "rus";
			return "uni"; // универсальный состав (например если будет только 12345)
		}

		#endregion

		#region Public методы

		public override string ToString()
		{
			return GetFullName();
		}

		/// <summary>
		///     Проверка имен собственных на корректность ввода
		/// </summary>
		/// <param noun="noun"></param>
		/// <returns>true если введено корректно, false если некорректно</returns>
		public static bool IsProperNoun(string noun)
		{
			//Проверка строки на русском
			if (GetLanguage(noun) == "rus")
			{
				//Не может быть пустой строкой
				if (string.IsNullOrWhiteSpace(noun))
				{
					return false;
				}
				//Не может начинаться и заканчиваться тире
				if (noun[0] == '-' || noun[noun.Length - 1] == '-')
				{
					return false;
				}
				//Может содержать только буквы латинского алфавита и тире, которые не могут идти по два подряд
				for (var i = 0; i < noun.Length - 1; i++)
					if (!(noun[i] >= 'А' && noun[i] <= 'Я' || noun[i] >= 'а' && noun[i] <= 'я' ||
					      noun[i] == '-' && noun[i + 1] != '-'))
					{
						return false;
					}
				//Должно начинаться с большой буквы
				if (noun[0] >= 'а' && noun[0] <= 'я')
				{
					return false;
				}
				//Не может быть двух заглавных букв подряд
				for (var i = 0; i < noun.Length - 1; i++)
					if (noun[i] >= 'А' && noun[i] <= 'Я' && noun[i + 1] >= 'А' && noun[i + 1] <= 'Я')
					{
						return false;
					}
				for (var i = 1; i < noun.Length; i++)
					if (noun[i] >= 'А' && noun[i] <= 'Я')
					{
						return false;
					}
				return true;
			}
			//Проверка строки на английском
			if (GetLanguage(noun) == "eng")
			{
				//Не может быть пустой строкой
				if (string.IsNullOrWhiteSpace(noun))
				{
					return false;
				}
				//Не может начинаться и заканчиваться тире
				if (noun[0] == '-' || noun[noun.Length - 1] == '-')
				{
					return false;
				}
				//Может содержать только буквы латинского алфавита и тире, которые не могут идти по два подряд
				for (var i = 0; i < noun.Length - 1; i++)
					if (!(noun[i] >= 'A' && noun[i] <= 'Z' || noun[i] >= 'a' && noun[i] <= 'z' ||
					      noun[i] == '-' && noun[i + 1] != '-'))
					{
						return false;
					}
				//Должно начинаться с большой буквы
				if (noun[0] >= 'a' && noun[0] <= 'z')
				{
					return false;
				}
				//Не может быть двух заглавных букв подряд
				for (var i = 0; i < noun.Length - 1; i++)
					if (noun[i] >= 'A' && noun[i] <= 'Z' && noun[i + 1] >= 'A' && noun[i + 1] <= 'Z')
					{
						return false;
					}
				return true;
			}
			for (var i = 1; i < noun.Length; i++)
				if (noun[i] >= 'A' && noun[i] <= 'Z')
				{
					return false;
				}
			return false;
		}

		#region Get Set свойства

		/// <summary>
		///     Возвращает и задает Имя
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				if (IsProperNoun(value))
					_name = value;
				else
					throw new Exception("Incorrect name: " + value);
			}
		}

		/// <summary>
		///     Возвращает и задает Фамилию
		/// </summary>
		public string Surname
		{
			get => _surname;
			set
			{
				if (IsProperNoun(value))
					_surname = value;
				else
					throw new Exception("Incorrect surname: " + value);
			}
		}

		/// <summary>
		///     Возвращает и задает Отчество
		/// </summary>
		public string Patronymic
		{
			get => _patronymic;
			set
			{
				if (IsProperNoun(value))
					_patronymic = value;
				else
					throw new Exception("Incorrect patronymic: " + value);
			}
		}

		/// <summary>
		///     Возвращает строку в формате "Фамилия, И. О."
		/// </summary>
		/// <returns>Surname + ", " + Name[0] + ". " + Patronymic[0] + '.'</returns>
		public string GetSurnameWithInitials() => Surname + ", " + Name[0] + ". " + Patronymic[0] + '.';

		/// <summary>
		///     Возвращает инициалы в формате "И. О."
		/// </summary>
		/// <returns>Name[0] + ". " + Patronymic[0] + '.'</returns>
		public string GetInitials() => Name[0] + ". " + Patronymic[0] + '.';

		#endregion

		/// <summary>
		///     Возваращает строку содержащую полные ФИО в формате "Фамилия Имя Отчество"
		/// </summary>
		/// <returns>Surname + ' ' + Name + ' ' + Patronymic</returns>
		public string GetFullName()
		{
			return Surname + ' ' + Name + ' ' + Patronymic;
		}

		#endregion
	}
}