using Models;

namespace ByteBankAgencySystem.Models;

public class ObjectList
{
    private static int _next;
    private object[] _items;

	public int Length {
		get 
		{
			return _next;
		}
	}

    public ObjectList(int length= 5)
    {
        _items = new object[length];
        _next = 0;
    }

	private void CheckListCapacity(int size)
    {
        if (_items.Length <= _next)
        {
            int newSize = _items.Length * 2;
            if (_items.Length >= size) { return; }
            if (size < newSize) { size = newSize; }
            object[] newArray = new object[size];
            _items.CopyTo(newArray, 0);
            _items = newArray;
        }
    }

	public object GetByIndex(int idx)
	{
		if(idx < 0 || idx >= _next) 
		{
			throw new ArgumentOutOfRangeException();
		}
		return _items[idx];
	}


	// ! Indexer :: Lets us to return values from the class like it was a Array, 
	// ! but the instance is of type ObjectList
	public object this[int idx]
	{
		get
		{
			return GetByIndex(idx);
		}
	}

    public void Add(object item)
    {
        CheckListCapacity(_items.Length + 1);
        System.Console.WriteLine($"Addint item on: {_next}");
        _items[_next] = item;
        _next++;
    }

	public void AddRangeParams(params object[] list)
	{
		foreach (object item in list)
		{
			Add(item);
		}
	}
	public void AddRange(object[] list)
	{
		foreach (object item in list)
		{
			Add(item);
		}
	}

    public void Remove(object item)
    {
        int itemIndex = 0;
        //! opperator '==' verifies references
        //! opperator '.Equals()' verifies values

        for (int idx = 0; idx < _next-1; idx++)
        {
            if(_items[idx].Equals(item)) itemIndex++;
            _items[idx] = _items[idx + itemIndex];
        }
        _next--;
        _items[_next] = null;
    }

    public void Print()
    {
        System.Console.WriteLine($"List length: {_items.Length}");
        for (int idx = 0; idx < _items.Length; idx++)
        {
            if (_items[idx] is null)
            {
                System.Console.WriteLine("Null item identified...");
                continue;
            }
        }
    }
}