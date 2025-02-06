using UnityEngine;

public class AnimatorBase : MonoBehaviour, IObjectComponent
{
    //�ִϸ����� ���̽� -> �ִϸ��̼� ����κ��� ����Ѵ�.
    protected CharacterBase character;
    protected Animator animator;

    protected float MoveLerp = 0f;

    protected void Update()
    {
        SetVelocityParameter();
    }

    protected void SetVelocityParameter()
    {
        if (character.IsMoving())
        {
            MoveLerp = Mathf.Lerp(MoveLerp, 1, Time.deltaTime * 15);
            if (MoveLerp > 0.99f)
                MoveLerp = 1;
        }
        else
        {
            MoveLerp = Mathf.Lerp(MoveLerp, 0, Time.deltaTime * 15);
            if (MoveLerp < 0.01f)
                MoveLerp = 0;
        }

        animator.SetFloat("Velocity", MoveLerp);
    }


    public void SetMediator(ObjectBase objectBase)
    {
        Init();

        if (objectBase is CharacterBase)
            character = (CharacterBase)objectBase;
        else
            Debug.Log("Cast Error on AnimatorBase");
    }

    protected void Init()
    {
        animator = GetComponent<Animator>();
    }
}
