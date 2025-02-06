using ControllerRelated;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterBase : ObjectBase
{
    protected CharacterStat CharacterStatus;

    //캐릭터 베이스 -> 오브젝트 베이스를 상속받아 애니메이션 적용 가능한 캐릭터 공통 부분을 담당한다.
    protected ControllerBase MainController;
    protected AnimatorBase MainAnimator;

    protected override void Init()
    {
        base.Init();

        MainController = GetComponent<ControllerBase>();
        MainController.SetMediator(this);

        for(int i = 0; i < transform.childCount; i++)
        {
            AnimatorBase tempAnimBase = transform.GetChild(i).GetComponent<AnimatorBase>();
            if(tempAnimBase != null)
            {
                MainAnimator = tempAnimBase;
                break;
            }
        }
        MainAnimator.SetMediator(this);

        if (ObjectStatus is CharacterStat)
            CharacterStatus = ObjectStatus as CharacterStat;
        else
            Debug.Log("Bind Error On CharacterStat");
    }
}