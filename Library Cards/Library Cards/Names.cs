using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
    //TODO: неправильное название класса. Класс выражает много имен или только одно имя?
    //TODO: нет xml комментария к классу
    public class Names
	{
        //TODO: это делается с помощью #region, а не комментариями. Почитать про регионы и исправить
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
        //TODO: xml
        //TODO: string.Empty вместо ""
        //Конструктор
        Names(string surname = "", string name = "", string patronymic = "")
		{
            //TODO: присвоение полей в обход проверок в сеттерах
            _surname = surname;
			_name = name;
			_patronymic = patronymic;
		}

        //TODO: xml
        //TODO: использовать наследование конструкторов
        public Names()
		{
            //TODO: string.Empty вместо ""
            //TODO: присвоение полей в обход проверок в сеттерах
            _surname = "";
			_name = "";
			_patronymic = "";
		}

        /// <summary>
        /// Заполнены ли все поля класса
        /// true если заполнены, false если не заполнены
        /// </summary>
        /// <returns>true если заполнены, false если не заполнены</returns>
        //TODO: использовать #region
        //Public методы
        //----------------------------------------------
        public bool IsNameFilled()
		{
            //TODO: вместо кучи условий обернуть в один оператор return
            //TODO: string.Empty
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

        //TODO: зачем этот метод торчит наружу? Проверка правильности имени ответственность класса имени
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

        //TODO: переделать методы на свойства
        /// <summary>
        /// Возвращает фамилия
        /// </summary>
        /// <returns>фамилия</returns>
        public string GetSurname() => _surname;
        //TODO: переделать методы на свойства
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
        //TODO: переделать методы на свойства
        /// <summary>
        ///  Возвращает имя
        /// </summary>
        /// <returns>имя</returns>
        public string GetName() => _name;
        //TODO: переделать методы на свойства
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
        //TODO: переделать методы на свойства
        /// <summary>
        ///  Возвращает фамилию
        /// </summary>
        /// <returns>фамилия</returns>
        public string GetPatronymic() => _patronymic;
        /// <summary>
        /// Задать Отчество
        /// </summary>
        /// <param name="Patronymic"></param>
        //TODO: переделать методы на свойства
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
            //TODO: если сделать присвоение полей строго через проверки, тогда этот метод здесь не нужен.
            //TODO: Более того, разработчик не будет ожидать, что при вызове метода Get у него может вылететь исключение
            FillingExceptions(true);
			return _name[0] + ". " + _patronymic[0] + '.';
		}
		/// <summary>
		/// Возваращает строку содержащую полные ФИО в формате "Фамилия Имя Отчество"
		/// </summary>
		/// <returns>Surname + ' ' + Name + ' ' + Patronymic</returns>
		public string GetFullName()
		{
            //TODO: если сделать присвоение полей строго через проверки, тогда этот метод здесь не нужен.
            //TODO: Более того, разработчик не будет ожидать, что при вызове метода Get у него может вылететь исключение
            FillingExceptions();
			return _surname + ' ' + _name + ' ' + _patronymic;
		}
	}
}
