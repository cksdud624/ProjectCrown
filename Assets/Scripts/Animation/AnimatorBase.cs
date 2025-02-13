using UnityEngine;

public class AnimatorBase : MonoBehaviour, IObjectComponent
{
    //애니메이터 베이스 -> 애니메이션 공통부분을 담당한다.
    protected CharacterBase mCharacter;
    protected Animator mAnimator;

    protected Vector2 mModelDirection = Vector2.zero;
    protected float mMoveLerp = 0f;


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

    protected void Update()
    {
        SetVelocityParameter();
        RotateModel();
    }

    protected void RotateModel()
    {
        if(mModelDirection != Vector2.zero)
        {
            Vector3 forwardDirection = mCharacter.GetCameraDirection();
            forwardDirection.y = 0;
            Vector3 rightDirection = Vector3.Cross(Vector3.up, forwardDirection);
            Vector3 moveDirection = forwardDirection * mModelDirection.y + rightDirection * mModelDirection.x;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), Time.deltaTime * 12);
        }
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
    #region Receive
    public void SetModelRotation(Vector2 rotation)
    {
        mModelDirection = rotation;
    }

    public void SetInput(int input)
    {
        Debug.Log(input);
    }
    #endregion
}
