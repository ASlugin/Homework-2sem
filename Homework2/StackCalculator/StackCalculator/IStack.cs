namespace Stack
{
    public interface IStack
    {
        /// <summary>
        /// Сhecks if stack is empty
        /// </summary>
        /// <returns>True is stack is empty, else returns false</returns>
        bool IsEmpty();

        /// <summary>
        /// Adds element to stack
        /// </summary>
        /// <param name="value">Value of element to add to stack</param>
        void Push(double value);

        /// <summary>
        /// Returns last element from stack and deletes it
        /// </summary>
        /// <returns>Element or null if stack is empty</returns>
        double? Pop();
    }
}
