Console.WriteLine("Welcome to the Pawn Shop!\n\n");
Console.Write("What is your name: ");
string name = Console.ReadLine();
bool browsing = false;
bool shopping = true;

if (string.IsNullOrWhiteSpace(name))
{
    Console.WriteLine("Name cannot be empty. Please restart the application and enter a valid name.");
    return;
}

Customer customer = new Customer(name, 1000);

Dictionary<string, int> itemsForSale = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
{
    { "Gold Ring", 300 },
    { "Gaming PC", 1200 },
    { "Guitar", 250 },
    { "TV", 125 },
    { "New Phone", 800 }
};

Console.WriteLine($"Customer ID: {customer.GetId()}\n");
Console.WriteLine($"Initial Balance: {customer.GetMoney()}\n");

while (shopping)
{
    Console.WriteLine("Would you like to (1) Browse items, (2) Selling or (3) Exit?");
    string choice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        continue;
    }

    if (choice == "1")
    {
        browsing = true;

        while (browsing)
        {
            Console.WriteLine("\nItems for Sale:");
            foreach (var item in itemsForSale)
            {
                Console.WriteLine($"{item.Key}: ${item.Value}");
            }

            Console.Write("\nEnter the name of the item you wish to purchase (or type 'exit' to stop browsing): ");
            string selectedItem = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(selectedItem))
            {
                Console.WriteLine("Invalid item name.");
                continue;
            }

            if (selectedItem.ToLower() == "exit")
            {
                browsing = false;
                continue;
            }

            if (itemsForSale.ContainsKey(selectedItem))
            {
                int itemPrice = itemsForSale[selectedItem];
                customer.SpendMoney(itemPrice);
                customer.BuyItem(selectedItem, itemPrice);
                Console.WriteLine($"You purchased {selectedItem} for ${itemPrice}.\n");
                itemsForSale.Remove(selectedItem);
            }
            else
            {
                Console.WriteLine("Item not found. Please select a valid item.");
            }
        }
    }
    else if (choice == "2")
    {
        foreach (var item in customer.GetItemsOwned())
        {
            Console.WriteLine($"You own a: '{item.Key}' and it sells for ${item.Value}");
        }

        Console.Write("Enter the name of the item you wish to sell or type in exit: ");
        string itemToSell = Console.ReadLine();



        if (string.IsNullOrWhiteSpace(itemToSell))
        {
            Console.WriteLine("Invalid item name.");
            continue;
        }

        if (itemToSell.ToLower() == "exit")
        {
            continue;
        }

        if (customer.GetItemsOwned().ContainsKey(itemToSell))
        {
            customer.SellItem(itemToSell);
        }
        else
        {
            Console.WriteLine("You do not own that item.");
        }

    }
    else if (choice == "3")
    {
        shopping = false;
    }

    else
    {
        Console.WriteLine("Invalid choice. Please select 1, 2, or 3.");
    }
}



Console.WriteLine("Thank you for shopping with Pawn Shop!");
