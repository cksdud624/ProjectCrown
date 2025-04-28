using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Scriptable Object/Character Data")]
public class CharacterData : ObjectData
{
    [DisplayName("Combo")]
    public ComboNodeGraph ComboNodeGraph;
}
