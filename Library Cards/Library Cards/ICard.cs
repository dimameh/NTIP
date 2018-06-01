using System;
using System.Runtime.Serialization;

namespace LibraryCards
{
	/// <summary>
	///     интерфейс библиотечных карточек
	/// </summary>
	public interface ICard
	{
		/// <summary>
		///     Название источника
		/// </summary>
		string Title { get; set; }

		/// <summary>
		///     Один из авторов источника
		/// </summary>
		FullName FirstAuthor { get; }

		/// <summary>
		///     Формирует строку типа string которая ялвяется библиографической информацией об издании, оформленной по ГОСТу 7.1 -
		///     2003 "Библиографическая запись"
		/// </summary>
		/// <returns>Всю информацию об издании</returns>
		string BibliographyInfo { get; }
	}



}