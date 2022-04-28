namespace Queue;

class Program
{
    private static void Main(string[] args)
    {
        QueuePriority<int> queue = new QueuePriority<int>();

        Console.WriteLine("Commands for queue with priorities for integer elements:");
        Console.WriteLine("0 - exit");
        Console.WriteLine("1 - add a element to queue");
        Console.WriteLine("2 - take and delete a element from queue");
        Console.WriteLine("3 - check whether queue is empty");

        while (true)
        {
            Console.Write("Enter a number of command: ");
            if (!int.TryParse(Console.ReadLine(), out int command))
            {
                Console.WriteLine("Invallid command");
                command = -1;
            }
            switch (command)
            {
                case 0:
                    return;
                case 1:
                    Console.Write("Enter value of new element: ");
                    if (!int.TryParse(Console.ReadLine(), out int value))
                    {
                        Console.WriteLine("Invalid value");
                        break;
                    }
                    Console.Write("Enter priority of new element: ");
                    if (!int.TryParse(Console.ReadLine(), out int priority))
                    {
                        Console.WriteLine("Invalid priority");
                        break;
                    }
                    queue.Enqueue(value, priority);
                    Console.WriteLine("Added");
                    break;
                case 2:
                    if (queue.Empty)
                    {
                        Console.WriteLine("Queue is empty!");
                        break;
                    }
                    int result = queue.Dequeue();
                    Console.WriteLine($"Element from queueu: {result}");
                    break;
                case 3:
                    Console.WriteLine(queue.Empty ? "Queue is empty" : "Queue is not empty");
                    break;
                default:
                    break;
            }

        }
    }
}