using UnityEngine;

public interface IObjectComponent<T1, T2, T3> where T1 : ObjectBase where T2 : ObjectData where T3 : ObjectChannel
{
    //ObjectBase�� �����Ǵ� ������Ʈ���� �ʼ������� �����ؾ��ϴ� ���
    #region Bind
    public void Bind(T1 mediator, T2 data, T3 channel);

    public void Unbind();
    #endregion
}