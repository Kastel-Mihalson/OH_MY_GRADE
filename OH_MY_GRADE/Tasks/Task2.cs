using OH_MY_GRADE;

/// <summary>
/// Реализация колцевого односвязного списка 
/// </summary>
public class Task2
{
    public void Example()
    {
        var slList = new SinglyLinkedList<Footballer>();
        var containsItem = new Footballer { Name = "Thor", Number = 5 };
        var NotContainsItem = new Footballer { Name = "Loki", Number = 147 };

        slList.Add(new Footballer { Name = "Sam", Number = 1 });
        slList.Add(containsItem);
        slList.Add(new Footballer { Name = "Bob", Number = 2 });

        Console.WriteLine("List items:");
        foreach (var item in slList)
        {
            Console.WriteLine(item.Name);
        }

        slList.AddByIndex(new Footballer { Name = "Odin", Number = 1 }, 2);

        Console.WriteLine("\nContains:");
        Console.WriteLine($"Item {containsItem.Name} is contains? Result: {slList.Contains(containsItem)}");
        Console.WriteLine($"Item {NotContainsItem.Name} is contains? Result: {slList.Contains(NotContainsItem)}");

        foreach (var item in slList)
        {
            Console.WriteLine(item.Name);
        }

        Console.WriteLine("\nRemove:");
        Console.WriteLine($"Item {containsItem.Name} is removed? Result: {slList.Remove(containsItem)}");
        Console.WriteLine($"Item {containsItem.Name} is contains? Result: {slList.Contains(containsItem)}");
        Console.WriteLine($"Item {NotContainsItem.Name} is removed? Result: {slList.Remove(NotContainsItem)}");

        foreach (var item in slList)
        {
            Console.WriteLine(item.Name);
        }

        int index = 3;
        var itemByIndex = slList.GetByIndex(index);

        if (itemByIndex != null)
        {
            Console.WriteLine($"GetItemByIndex {index}: {itemByIndex.Name}");
        } else
        {
            Console.WriteLine($"GetItemByIndex {index}: null");
        }

        var numberList = new SinglyLinkedList<int>();
        var numberListCount = 10;
        
        for (int i = 0; i < numberListCount; i++)
        {
            numberList.Add(new Random().Next(0, numberListCount * 5));
        }

        Console.WriteLine("\nNumber list:");
        foreach (var item in numberList)
        {
            Console.Write($"{item} ");
        }

        //Console.WriteLine("\nSimple Sorted number list:");
        //numberList.SimpleSort();
        //foreach (var item in numberList)
        //{
        //    Console.Write($"{item} ");
        //}

        Console.WriteLine("\nQuick sorted number list:");
        numberList.QuickSort(0, numberList.Count - 1);
        foreach (var item in numberList)
        {
            Console.Write($"{item} ");
        }
    }
}
