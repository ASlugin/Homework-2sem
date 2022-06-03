try
{
    string inputExpression = File.ReadAllText(@"..\..\..\Input.txt");
    var parseTree = new Tree(inputExpression);
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
