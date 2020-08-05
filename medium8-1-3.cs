  class Bag
  {
    public readonly int MaxWeight;
    List<Item> _items;

    public Bag(int maxWeight)
    {
      MaxWeight = maxWeight;
    }

    public void AddItem(string name, int count)
    {
      int currentWeight = _items.Sum(item => item.Count);
      Item targetItem = _items.FirstOrDefault(item => item.Name == name);

      if (targetItem == null)
        throw new InvalidOperationException();

      if (currentWeight + count > MaxWeight)
        throw new InvalidOperationException();

      targetItem.IncCount(count);
    }

    public IEnumerable<Item> GetAllItems()
    {
      return _items;
    }
  }

  class Item
  {
    public readonly string Name;
    public int Count { get; private set; }

    public Item(string name, int count)
    {
      Name = name;
      Count = count;
    }

    public void IncCount(int count)
    {
      Count += count;
    }
  }