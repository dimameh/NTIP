using System;

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
		public FullName(string surname, string name, string patronymic)
		{
			Surname = surname;
			Name = name;
			Patronymic = patronymic;
		}

		#endregion

		#region Public методы

		/// <summary>
		///     Проверка имен собственных на корректность ввода
		/// </summary>
		/// <param noun="noun"></param>
		/// <returns>true если введено корректно, false если некорректно</returns>
		public static bool IsProperNoun(string noun)
		{
			//Не может быть пустой строкой
			if (string.IsNullOrWhiteSpace(noun)) return false;
			//Не может начинаться и заканчиваться тире
			if (noun[0] == '-' || noun[noun.Length - 1] == '-') return false;
			//Может содержать только буквы латинского алфавита и тире, которые не могут идти по два подряд
			for (var i = 0; i < noun.Length; i++)
				if (!(noun[i] >= 'А' && noun[i] <= 'Я' || noun[i] >= 'а' && noun[i] <= 'я' || noun[i] == '-' && noun[i + 1] != '-'))
					return false;
			//Должно начинаться с большой буквы
			if (noun[0] >= 'а' && noun[0] <= 'я') return false;
			//Не может быть двух заглавных букв подряд
			for (var i = 0; i < noun.Length; i++)
				if (noun[i] >= 'А' && noun[i] <= 'Я' && noun[i + 1] >= 'А' && noun[i + 1] <= 'Я')
					return false;
			return true;
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
					throw new Exception("Incorrect name: " + _name);
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
					throw new Exception("Incorrect patronymic: " + _patronymic);
			}
		}

		/// <summary>
		///     Возвращает строку в формате "Фамилия, И. О."
		/// </summary>
		/// <returns>Surname + ", " + Name[0] + ". " + Patronymic[0] + '.'</returns>
		public string SurnameWithInitials => Surname + ", " + Name[0] + ". " + Patronymic[0] + '.';

		/// <summary>
		///     Возвращает инициалы в формате "И. О."
		/// </summary>
		/// <returns>Name[0] + ". " + Patronymic[0] + '.'</returns>
		public string Initials => Name[0] + ". " + Patronymic[0] + '.';

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