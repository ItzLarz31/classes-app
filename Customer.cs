class Customer
{
    private static int Id = 0;
    private string _name { get; set; }
    private int _id { get; set; }
    private int _money { get; set; }
    private Dictionary<string, int> _itemsOwned { get; set; } = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
    {
        {"old phone", 100},
        {"watch", 200}
    };



    public Customer(string name, int money)
    {
        Id++;
        _name = name;
        _id = Id;
        _money = money;
    }

    public string GetName()
    {
        return _name;
    }


    public int GetId()
    {
        return _id;
    }

    public int GetMoney()
    {
        return _money;
    }

    public void AddMoney(int amount)
    {
        try
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }

            _money += amount;
            Console.WriteLine($"Added ${amount} to account.\n");
            Console.WriteLine($"New balance: ${_money}\n");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }
    }

    public void SpendMoney(int amount)
    {

        try
        {
            if (amount < 0)
            {
                throw new ArgumentException("Amount cannot be negative.");
            }

            if (amount > _money)
            {
                throw new ArgumentException("Insufficient funds.");
            }

            _money -= amount;
            Console.WriteLine($"Transaction of {amount} successful.\n");
            Console.WriteLine($"Remaining balance: ${_money}\n");

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }


    }

    public Dictionary<string, int> GetItemsOwned()
    {
        return _itemsOwned;
    }

    public void BuyItem(string itemName, int itemValue)
    {
        _itemsOwned[itemName] = itemValue;
    }

    public void SellItem(string itemName)
    {
        if (_itemsOwned.ContainsKey(itemName))
        {
            AddMoney(_itemsOwned[itemName]);
            Console.WriteLine($"Sold your: '{itemName}' and earned ${_itemsOwned[itemName]}");
            _itemsOwned.Remove(itemName);
        }
        else
        {
            Console.WriteLine("Item not found in inventory.");
        }
    }

}