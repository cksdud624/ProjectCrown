using ControllerRelated;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterBase : ObjectBase
{
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
        for(int i = 0; i < transform.childCount; i++)
        {
            AnimatorBase tempAnimationBase = transform.GetChild(i).GetComponent<AnimatorBase>();
            if(tempAnimationBase != null)
            {
                mMainAnimator = tempAnimationBase;
                break;
            }
        }
        mMainAnimator.SetMediator(this);

        if (mObjectStatus is CharacterStat)
            mCharacterStatus = mObjectStatus as CharacterStat;
        else
            Debug.Log("Cast Error On CharacterStat");
    }

    public override void SetMove(Vector2 move)
    {
        base.SetMove(move);
        mMainAnimator.SetModelRotation(move);
    }
}