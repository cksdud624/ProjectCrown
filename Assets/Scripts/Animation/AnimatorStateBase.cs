using UnityEngine;

public class AnimatorStateBase : StateMachineBehaviour
{
    AnimatorBridge bridge;

    [DisplayName("Object State")]
    public eObjectState mState = eObjectState.Normal;
    bool isOver = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //State에 들어오면 즉시 호출
        base.OnStateEnter(animator, stateInfo, layerIndex);
        if (mState != eObjectState.Action)
            return;

        if(bridge == null)
            bridge = animator.GetComponent<AnimatorBridge>();

        bridge.Enter(this, mState);
        isOver = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (mState != eObjectState.Action)
            return;
        if (isOver)
            return;

        if(stateInfo.normalizedTime > 1f)
        {
            bridge.AutoEnd(this, mState);
            isOver = true;
        }
    }
}
