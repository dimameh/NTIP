using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Json;
using LibraryCards;

namespace CardListApp
{
	internal class Serialization
	{
		private static readonly IEnumerable<Type> TypeList = new List<Type>
		{
			typeof(List<FullName>),
			typeof(FullName),
			typeof(BookArticle),
			typeof(CollectionArticle),
			typeof(Dissertation),
			typeof(JournalArticle)
		};

		private static readonly DataContractJsonSerializer Serializer =
			new DataContractJsonSerializer(typeof(BindingList<ICard>), TypeList);

		public static void Save(string filename, BindingList<ICard> savingList)
		{
			Serializer.WriteObject(new FileStream(filename, FileMode.Create), savingList);
		}

		public static BindingList<ICard> Read(string filename)
		{
			return (BindingList<ICard>) Serializer.ReadObject(new FileStream(filename, FileMode.Open));
		}
	}
}