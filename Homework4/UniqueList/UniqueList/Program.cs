namespace UniqueList;

class Program
{
    private static void Main(string[] args)
    {
        UniqueList list = new UniqueList();
        PrintCommandsForUniqueList();

        while (true)
        {
            int command = -2;
            try
            {
                command = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
            }
            
            switch (command)
            {
                case -1:
                {
                    return;
                }
                case 0:
                {
                    try
                    {
                        Console.Write("Enter a new value: ");
                        int newValue = Convert.ToInt32(Console.ReadLine());
                        Console.Write($"Enter a postion within [0, {list.Size}]: ");
                        int position = Convert.ToInt32(Console.ReadLine());
                        list.Add(newValue, position);
                    }
                    catch (AttemptToAddExistingValueException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (ArgumentOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrectly entered data");
                    }
                    break;
                }
                case 1:
                {
                    try
                    {
                        Console.Write("Enter value: ");
                        int value = Convert.ToInt32(Console.ReadLine());
                        int position = list.GetPositionOfElementByValue(value);
                        Console.WriteLine(position < 0 ? "Element with given position doesn't exist in list" : position);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrectly entered data");
                    }
                    break;
                }
                case 2:
                {
                    try
                    {
                        Console.Write($"Enter a postion within [0, {list.Size - 1}]: ");
                        int position = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(list.GetValue(position));
                    }
                    catch (ArgumentOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrectly entered data");
                    }
                    break;
                }
                case 3:
                {
                    try
                    {
                        Console.Write("Enter a new value: ");
                        int newValue = Convert.ToInt32(Console.ReadLine());
                        Console.Write($"Enter a postion within [0, {list.Size - 1}]: ");
                        int position = Convert.ToInt32(Console.ReadLine());
                        list.ChangeValueOfElement(newValue, position);
                    }
                    catch (AttemptToAddExistingValueException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (ArgumentOutOfRangeException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrectly entered data");
                    }
                    break;
                }
                case 4:
                {
                    try
                    {
                        Console.Write($"Enter a postion within [0, {list.Size - 1}]: ");
                        int position = Convert.ToInt32(Console.ReadLine());
                        list.Delete(position);
                    }
                    catch (AttemptToDeleteNonexistentElement exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Incorrectly entered data");
                    }
                    break;
                }
                case 5:
                {
                    Console.Write("Elements of list: ");
                    list.Print();
                    break;
                }
                case 6:
                {
                    PrintCommandsForUniqueList();
                    break;
                }
                default:
                {
                    Console.WriteLine("Incorrect command!");
                    break;
                }
            }

        }
        
    }

    private static void PrintCommandsForUniqueList()
    {
        Console.WriteLine("Commands for unique list:");
        Console.WriteLine("-1 - exit");
        Console.WriteLine("0 - add a new element");
        Console.WriteLine("1 - get position of element by value");
        Console.WriteLine("2 - get value of element by position");
        Console.WriteLine("3 - change value of element by position");
        Console.WriteLine("4 - delete element by position");
        Console.WriteLine("5 - print all elements of list");
        Console.WriteLine("6 - print command for unique list");
    }
}
