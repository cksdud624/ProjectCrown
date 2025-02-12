using ControllerRelated;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterBase : ObjectBase
{
    protected CharacterStat mCharacterStatus;

    //캐릭터 베이스 -> 오브젝트 베이스를 상속받아 애니메이션 적용 가능한 캐릭터 공통 부분을 담당한다.
    protected ControllerBase mMainController;
    protected AnimatorBase mMainAnimator;

    protected override void Init()
    {
        base.Init();

        //컨트롤러 바인딩
        mMainController = GetComponent<ControllerBase>();
        mMainController.SetMediator(this);

        //애니메이터 바인딩
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