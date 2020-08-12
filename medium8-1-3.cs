  class Bag
  {
    public readonly int MaxWeight;
    private readonly List<BagItem> _items;

    public Bag(int maxWeight)
    {
      MaxWeight = maxWeight;
      _items = new List<BagItem>();
    }

    public void AddItem(string name, int count)
    {
      int currentWeight = _items.Sum(item => item.Count);
      BagItem targetItem = _items.FirstOrDefault(item => item.Name == name);

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
    public int Count { get; protected set; }

    public Item(string name, int count)
    {
      Name = name;
      Count = count;
    }
  }

  class BagItem : Item
  {
    public BagItem(string name, int count) : base(name, count)
    {
    }

    public void IncCount(int count)
    {
      Count += count;
    }
  }