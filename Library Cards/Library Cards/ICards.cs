using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Cards
{
    //TODO: Почему во множественном числе? Один экземпляр класса это одна карточка или несколько?
    //TODO: А что еще есть общего между литературными источниками? В твоём случае, как минимум авторы, название, год. Их тоже вынести в интерфейс.
    /// <summary>
    /// интерфейс библиотечных карточек
    /// </summary>
    public interface ICards
    {
        //TODO: вместо метода лучше сделать свойство без сеттера
        /// <summary>
        /// Формирует строку типа string которая ялвяется библиографической информацией об издании, оформленной по ГОСТу 7.1 - 2003 "Библиографическая запись"
        /// </summary>
        /// <returns>Всю информацию об издании</returns>
        string GetBibliographyInfo();
	}
}
