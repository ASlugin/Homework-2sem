using System;

namespace UniqueList
{
    class Program
    {
        private static void Main(string[] args)
        {
            List list = new List();
            list.Add(11, list.Size);
            list.Add(22, list.Size);
            list.Add(33, list.Size);

            list.ChangeValueOfElement(12, 0);
            list.ChangeValueOfElement(23, 1);
            list.ChangeValueOfElement(34, list.Size - 1);

            for (int i = 0; i < list.Size; i++)
            {
                Console.WriteLine(list.GetValue(i));
            }

            list.Delete(1);
            list.Delete(0);
            list.Delete(list.Size - 1);
        }
    }
}