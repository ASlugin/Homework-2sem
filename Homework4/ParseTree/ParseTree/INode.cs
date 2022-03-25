namespace ParseTree
{
    interface INode
    {
        /// <summary>
        /// Prints an expression that is contained in a subtree of the node
        /// </summary>
        void Print();

        /// <summary>
        /// Calculates expression that is contained in a subtree of the node
        /// </summary>
        /// <returns>Result of calculating</returns>
        double Calculate();
    }
}
