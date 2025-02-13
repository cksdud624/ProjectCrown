using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ComboRoute", menuName = "Scriptable Object/ComboRoute")]
public class ComboRouteList : ScriptableObject
{
    [SerializeField]
    private List<ComboNode> comboNodes;
    public List<ComboNode> ComboNodes { get { return comboNodes; } }
}

public class ComboNode
{
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