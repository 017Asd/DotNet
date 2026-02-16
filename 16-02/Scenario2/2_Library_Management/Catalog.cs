using System;
using System.Collections.Generic;
using System.Linq;

public class Catalog<T> where T : Book
{
    private List<T> _items = new List<T>();
    private HashSet<string> _isbnSet = new HashSet<string>();
    private SortedDictionary<string, List<T>> _genreIndex =
        new SortedDictionary<string, List<T>>();

    
    public bool AddItem(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        if (string.IsNullOrWhiteSpace(item.ISBN))
            throw new ArgumentException("ISBN cannot be empty.");

        
        if (!_isbnSet.Add(item.ISBN))
            return false;

        _items.Add(item);

        if (!_genreIndex.ContainsKey(item.Genre))
            _genreIndex[item.Genre] = new List<T>();

        _genreIndex[item.Genre].Add(item);

        return true;
    }

   
    public List<T> this[string genre]
    {
        get
        {
            if (_genreIndex.ContainsKey(genre))
                return _genreIndex[genre];

            return new List<T>();
        }
    }

    
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        return _items.Where(predicate);
    }
}
