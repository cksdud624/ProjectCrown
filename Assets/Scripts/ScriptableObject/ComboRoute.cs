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

//현재 노드로 진입하기 위한 커맨드 : 1번 인덱스의 콤보액션에 들어갈때 LeftClick이면 왼쪽 버튼을 클릭해야 1번 인덱스에 진입
public enum ComboInput
{
    None, Auto, LeftClick, LeftCancel, RightClick, RightCancel
}