using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Emergency254.Views.Emergency_Contacts
{
    public interface SaveContacts<T>
    {
		Task<IEnumerable<T>> GetItems();

		/// <summary>
		/// Adds an item.
		/// </summary>
		Task<IEnumerable<T>> GetItem(string id);
		/// <returns>A bool representing whether or not the operation succeeded.</returns>
		/// <param name="item">An item.</param>
		Task<bool> AddItem(T item);
	}
}
