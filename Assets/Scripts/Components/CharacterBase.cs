using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class CharacterBase : ObjectBase
{
    //애니메이션을 가질 수 있는 캐릭터 클래스
    protected AnimatorBase mAnimatorBase;
    CharacterData mCharacterData;
    CharacterChannel mCharacterChannel;

    #region Instantiate
    protected override void InstantiateChannel()
    {
        mCharacterChannel = ScriptableObject.CreateInstance<CharacterChannel>();
        mObjectChannel = mCharacterChannel as ObjectChannel;
    }
    #endregion

    #region Bind
    public override void Bind(ObjectData data)
    {
        base.Bind(data);
        mCharacterData = data as CharacterData;

        mAnimatorBase = GetComponent<AnimatorBase>();
        mAnimatorBase.Bind(this, mCharacterData, mCharacterChannel);
    }

    public override void Unbind()
    {
        base.Unbind();
        mCharacterData = null;
        mCharacterChannel = null;

        mAnimatorBase.Unbind();
        mAnimatorBase = null;
    }
    #endregion
}
