using ControllerRelated;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterBase : ObjectBase
{
    protected CharacterStat CharacterStatus;

    //ĳ���� ���̽� -> ������Ʈ ���̽��� ��ӹ޾� �ִϸ��̼� ���� ������ ĳ���� ���� �κ��� ����Ѵ�.
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