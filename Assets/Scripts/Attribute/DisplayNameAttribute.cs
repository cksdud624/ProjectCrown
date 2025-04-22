using UnityEngine;

public class DisplayNameAttribute : PropertyAttribute
{
    public string DisplayName;

    public DisplayNameAttribute(string name)
    {
        DisplayName = name;
    }
}
