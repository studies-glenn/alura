using Models;

namespace ByteBankAgencySystem.Models;

public class CurrentAccountList
{
    private static int _index;
    private CurrentAccount[] _items;

    public CurrentAccountList(int length= 5)
    {
        _items = new CurrentAccount[length];
        _index = 0;
    }

    public void Print()
    {
        for (int idx = 0; idx < _index; idx++)
        {
            if (_items[idx] is null) System.Console.WriteLine("Null item identified...");
            System.Console.WriteLine($"Account at postition {idx} number: {_items[idx].Number}");
        }
    }

    public void Add(CurrentAccount item)
    {
        CheckListCapacity(_items.Length + 1);
        System.Console.WriteLine($"Addint item on: {_index}");
        _items[_index] = item;
        _index++;
    }

    public void Remove(CurrentAccount item)
    {
        int itemIndex = 0;
        //! opperator '==' verifies references
        //! opperator '.Equals()' verifies values

        for (int idx = 0; idx < _index; idx++)
        {
            if(_items[idx].Number.Equals(item.Number)) itemIndex++;
            _items[idx] = _items[idx + itemIndex];
        }
        _items[_index] = null;
        _index--;
    }

    private void CheckListCapacity(int size)
    {
        int newSize = _items.Length * 2;
        if (_items.Length >= size) { return; }
        if (size < newSize) { size = newSize; }
        CurrentAccount[] newArray = new CurrentAccount[size];
        _items.CopyTo(newArray, 0);
        _items = newArray;
    }
}