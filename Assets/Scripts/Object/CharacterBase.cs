using UnityEngine;
using System.Collections.Generic;

public class CharacterBase : ObjectBase
{
    [SerializeField]
    protected ComboRoute mComboRoute;

    protected CharacterStat mCharacterStatus;

    //ĳ���� ���̽� -> ������Ʈ ���̽��� ��ӹ޾� �ִϸ��̼� ���� ������ ĳ���� ���� �κ��� ����Ѵ�.
    protected ControllerBase mMainController;
    protected AnimatorBase mMainAnimator;

    protected override void Init()
    {
        base.Init();

        //��Ʈ�ѷ� ���ε�
        mMainController = GetComponent<ControllerBase>();
        mMainController.SetMediator(this);

        //�ִϸ����� ���ε�
        for (int i = 0; i < transform.childCount; i++)
        {
            AnimatorBase tempAnimationBase = transform.GetChild(i).GetComponent<AnimatorBase>();
            if (tempAnimationBase != null)
            {
                mMainAnimator = tempAnimationBase;
                mMainAnimator.SetMediator(this);
                if (mComboRoute != null)
                    mMainAnimator.SetComboRoute(mComboRoute);
                break;
            }
        }

        if (mObjectStatus is CharacterStat)
            mCharacterStatus = mObjectStatus as CharacterStat;
        else
            Debug.Log("Cast Error On CharacterStat");
    }

    public override void SetClick(int click)
    {
        base.SetClick(click);
        mMainAnimator.SetInput(click);
    }

    public override void SetMove(Vector2 move)
    {
        base.SetMove(move);
        mMainAnimator.SetModelRotation(move);
    }

    public void RestrictMove(bool isRestrict)
    {
        mMainRigidbody.RestrictMove(isRestrict);
    }
}