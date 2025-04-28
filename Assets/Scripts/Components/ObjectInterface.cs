using UnityEngine;

public interface IObjectComponent<T1, T2> where T1 : ObjectBase where T2 : ObjectData
{
    //ObjectBase�� �����Ǵ� ������Ʈ���� �ʼ������� �����ؾ��ϴ� ���
    #region Bind
    public void BindComponent(T1 mediator, T2 data);

    public void UnbindComponent();
    #endregion
}
