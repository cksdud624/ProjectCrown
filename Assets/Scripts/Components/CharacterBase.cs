using UnityEngine;

public class CharacterBase : ObjectBase
{
    //애니메이션을 가질 수 있는 캐릭터 클래스
    AnimatorBase mAnimatorBase;

    #region Bind
    public override void BindComponent()
    {
        base.BindComponent();
        mAnimatorBase = GetComponent<AnimatorBase>();
        mAnimatorBase.BindComponent(this);
    }

    public override void UnbindComponent()
    {
        base.UnbindComponent();
        mAnimatorBase.UnbindComponent();
        mAnimatorBase = null;
    }
    #endregion
}
