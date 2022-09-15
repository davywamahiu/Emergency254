﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Emergency254.ExtensionMethods
{
    public static class EnumerableExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return collection == null ? new ObservableCollection<T>() : new ObservableCollection<T>(collection);
        }

        public static void AddRange<T>(this IList<T> list, IEnumerable<T> collection)
        {
            foreach (var item in collection)
                list.Add(item);
        }
    }
}
