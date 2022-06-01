/// <summary>
/// Class for list, which contains only unique values
/// </summary>
public class UniqueList : List
{
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
}
