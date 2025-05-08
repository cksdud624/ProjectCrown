using System;
using UnityEngine;

public class AnimatorBridge : MonoBehaviour
{
    public event Action<AnimatorStateBase, eObjectState> EnterState;
    public event Action<AnimatorStateBase, eObjectState> EndAuto;

    public void Enter(AnimatorStateBase animatorState, eObjectState state)
    {
        EnterState.Invoke(animatorState, state);
    }

    public void AutoEnd(AnimatorStateBase animatorState, eObjectState state)
    {
        EndAuto.Invoke(animatorState, state);
    }
}
