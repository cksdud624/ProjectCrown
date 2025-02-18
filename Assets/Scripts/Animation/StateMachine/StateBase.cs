using UnityEngine;

public class StateBase : StateMachineBehaviour
{
    protected ComboNode mBindNode = null;
    bool mIsTransition = false;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(mIsTransition && stateInfo.normalizedTime >= 1f)
        {
            animator.GetComponent<AnimatorBase>().EndStateAuto(mBindNode);
        }
    }

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        mBindNode = animator.GetComponent<AnimatorBase>().CurrentNode;
        mIsTransition = true;
    }
}
