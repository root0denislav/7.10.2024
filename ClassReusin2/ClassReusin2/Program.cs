using System.Collections.Generic;

class StackOfStrings
{
    private List<string> data = new List<string>();

    public void Push(string item)
    {
        data.Add(item);
    }

    public string Pop()
    {
        if (data.Count == 0) return null;

        string item = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        return item;
    }

    public string Peek()
    {
        if (data.Count == 0) return null;

        return data[data.Count - 1];
    }

    public bool IsEmpty()
    {
        return data.Count == 0;
    }
}
