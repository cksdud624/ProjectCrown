using UnityEngine;

[CreateAssetMenu(fileName = "ComboNode", menuName = "Scriptable Object/ComboNode")]
public class ComboNode : ScriptableObject
{
    [SerializeField]
    private ComboNode previousNode;
    public ComboNode PreviousNode { get { return previousNode; } }

    [SerializeField]
    private EClick entryInput;
    public EClick EntryInput { get { return entryInput; } }

    [SerializeField]
    private int actionIndex;
    public int ActionIndex { get { return actionIndex; } }

    //ĵ�� ���� �ð� �ּ� ~ �ִ�
    [SerializeField]
    private float cancelMin = 0;
    public float CancelMin { get { return cancelMin; } }

    [SerializeField]
    private float cancelMax = 1;
    public float CancelMax { get { return cancelMax; } }
}