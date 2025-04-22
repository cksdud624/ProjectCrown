using UnityEngine;

public class AnimatorBase : MonoBehaviour, IObjectComponent<CharacterBase>
{
    protected CharacterBase mMediator;

    #region Bind
    public void BindComponent(CharacterBase mediator)
    {
        mMediator = mediator;
    }

    public void UnbindComponent()
    {
        mMediator = null;
    }
    #endregion
}
