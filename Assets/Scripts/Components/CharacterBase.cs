using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CharacterBase : ObjectBase
{
    //애니메이션을 가질 수 있는 캐릭터 클래스
    protected AnimatorBase mAnimatorBase;
    CharacterData mCharacterData;

    #region Bind
    public override void BindComponent(ObjectData data)
    {
        base.BindComponent(data);
        mAnimatorBase = GetComponent<AnimatorBase>();
        mCharacterData = data as CharacterData;
        mAnimatorBase.BindComponent(this, mCharacterData);
    }

    public override void UnbindComponent()
    {
        base.UnbindComponent();
        mAnimatorBase.UnbindComponent();
        mAnimatorBase = null;
    }
    #endregion

    #region Receive

    //Animation
    public override void SetDirection(Vector2 direction)
    {
        base.SetDirection(direction);
        mAnimatorBase.SetModelDirection(direction);
        if (direction != Vector2.zero)
            mAnimatorBase.PlayMoveAnimation(eAnimationType.Run, eAnimationIndexType.Single);
        else
            mAnimatorBase.PlayMoveAnimation(eAnimationType.Idle, eAnimationIndexType.Single);
    }

    public override void ProcessInputCommand(eInputCommand inputCommand)
    {
        base.ProcessInputCommand(inputCommand);
        mAnimatorBase.PlayAnimation(inputCommand);
    }
    #endregion
}
