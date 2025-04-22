using UnityEngine;

public interface IObjectComponent<T> where T : ObjectBase
{
    //ObjectBase�� �����Ǵ� ������Ʈ���� �ʼ������� �����ؾ��ϴ� ���
    #region Bind
    public void BindComponent(T mediator);

    public void UnbindComponent();
    #endregion
}
