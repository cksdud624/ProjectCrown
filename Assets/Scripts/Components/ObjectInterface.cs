using UnityEngine;

public interface IObjectComponent<T> where T : ObjectBase
{
    //ObjectBase와 연동되는 컴포넌트들이 필수적으로 구현해야하는 기능
    #region Bind
    public void BindComponent(T mediator);

    public void UnbindComponent();
    #endregion
}
