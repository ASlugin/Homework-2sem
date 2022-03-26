namespace UniqueList
{
    public class UniqueList : List
    {
        private bool Exist(int value)
        {
            ListElement? current = head;
            for (int i = 0; i < Size; i++)
            {
                if (current?.value == value)
                {
                    return true;
                }
                current = current?.next;
            }
            return false;
        }

        /// <summary>
        /// Adds a new element to given position of the list if given value doesn't already exist in list
        /// </summary>
        /// <param name="value">Value of new element</param>
        /// <param name="position">Position for new element</param>
        /// <exception cref="Exception"></exception>
        public override void Add(int value, int position)
        {
            if (Exist(value))
            {
                throw new AttemptToAddExistingValueException("The given value already exist in the list");
            }
            base.Add(value, position);
        }

        /// <summary>
        /// Changes value of the element at the given position if given value doesn't already exist in list
        /// </summary>
        /// <param name="newValue">New value for the element</param>
        /// <param name="position">Position for the element to be changed</param>
        /// <exception cref="Exception"></exception>
        public override void ChangeValueOfElement(int newValue, int position)
        {
            if (Exist(newValue))
            {
                throw new AttemptToAddExistingValueException("The given value already exist in the list");
            }
            base.ChangeValueOfElement(newValue, position);
        }

        /// <summary>
        /// Returns position of element with given value
        /// </summary>
        /// <param name="value">Value to search for element with this value</param>
        /// <returns>Position of element or -1 if given value doesn't exist in list</returns>
        public int GetPositionOfElementByValue(int value)
        {
            ListElement? current = head;
            for (int i = 0; i < Size; i++)
            {
                if (current?.value == value)
                {
                    return i;
                }
                current = current?.next;
            }
            return -1;
        }
    }
}
