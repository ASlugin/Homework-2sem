namespace ParseTree
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                string inputExpression = File.ReadAllText(@"..\..\..\Input.txt");
                Tree parseTree = new Tree(inputExpression);
                parseTree.Print();
                Console.WriteLine(parseTree.Calculate()); 
            }
            catch (FileNotFoundException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (DivideByZeroException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
            

        }
    }
}