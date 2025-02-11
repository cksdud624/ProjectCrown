using UnityEngine;

public class AnimatorBase : MonoBehaviour, IObjectComponent
{
    //애니메이터 베이스 -> 애니메이션 공통부분을 담당한다.
    protected CharacterBase mCharacter;
    protected Animator mAnimator;

    protected float mMoveLerp = 0f;

    protected void Update()
    {
        SetVelocityParameter();
    }

    protected void SetVelocityParameter()
    {
        if (mCharacter.IsMoving())
        {
            mMoveLerp = Mathf.Lerp(mMoveLerp, 1, Time.deltaTime * 15);
            if (mMoveLerp > 0.99f)
                mMoveLerp = 1;
        }
        else
        {
            mMoveLerp = Mathf.Lerp(mMoveLerp, 0, Time.deltaTime * 15);
            if (mMoveLerp < 0.01f)
                mMoveLerp = 0;
        }

        mAnimator.SetFloat("Velocity", mMoveLerp);
    }


    public void SetMediator(ObjectBase objectBase)
    {
        Init();

        if (objectBase is CharacterBase)
            mCharacter = (CharacterBase)objectBase;
        else
            Debug.Log("Cast Error on AnimatorBase");
    }

    protected void Init()
    {
        mAnimator = GetComponent<Animator>();
    }
}
