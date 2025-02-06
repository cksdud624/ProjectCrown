using UnityEngine;

[CreateAssetMenu(fileName = "CharacterStat", menuName = "Scriptable Object/ObjectStat")]
public class ObjectStat : ScriptableObject
{
    [SerializeField]
    private int hp;
    public int Hp { get { return hp; } }

    [SerializeField]
    private int defense;
    public int Defense { get { return defense; } }

    [SerializeField]
    private float moveSpeed;
    public float MoveSpeed { get { return moveSpeed; } }
}
