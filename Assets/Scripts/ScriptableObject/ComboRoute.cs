using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ComboRoute", menuName = "Scriptable Object/ComboRoute")]
public class ComboRouteList : ScriptableObject
{
    [SerializeField]
    private List<ComboRouteNode> comboRoute;
    public List<ComboRouteNode> ComboRoute { get { return comboRoute; } }
}

[CreateAssetMenu(fileName = "ComboRouteNode", menuName = "Scriptable Object/ComboRouteNode")]
public class ComboRouteNode : ScriptableObject
{
    [SerializeField]
    private List<ComboAction> comboActions;
    public List<ComboAction> ComboActions { get { return comboActions; } }

    [SerializeField]
    private List<ComboInput> comboInputs;
    public List<ComboInput> ComboInputs { get {  return comboInputs; } }
}


public enum ComboAction
{
    Attack1, Attack2, Attack3
}

//���� ���� �����ϱ� ���� Ŀ�ǵ� : 1�� �ε����� �޺��׼ǿ� ���� LeftClick�̸� ���� ��ư�� Ŭ���ؾ� 1�� �ε����� ����
public enum ComboInput
{
    None, Auto, LeftClick, LeftCancel, RightClick, RightCancel
}