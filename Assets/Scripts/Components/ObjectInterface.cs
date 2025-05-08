using UnityEngine;

public interface IObjectComponent<T1, T2, T3> where T1 : ObjectBase where T2 : ObjectData where T3 : ObjectChannel
{
    //ObjectBase와 연동되는 컴포넌트들이 필수적으로 구현해야하는 기능
    #region Bind
    public void Bind(T1 mediator, T2 data, T3 channel);

    public void Unbind();
    #endregion
}