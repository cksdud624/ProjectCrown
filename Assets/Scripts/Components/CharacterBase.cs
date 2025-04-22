using UnityEngine;

public class CharacterBase : ObjectBase
{
    //�ִϸ��̼��� ���� �� �ִ� ĳ���� Ŭ����
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
