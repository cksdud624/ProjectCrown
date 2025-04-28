using System.Collections.Generic;
using UnityEngine;

public static class Util
{
}

public enum eCameraState
{
    Playable
}

public enum eOptionFloat
{
    Sensitivity
}

public enum eAnimationType
{
    Idle, Run, Attack
}

public enum eAnimationIndexType
{
    Single, Several
}

public enum eInputCommand
{
    FirstPress, FirstRelease, SecondPress, SecondRelease
}

public class CustomNodeExchange
{
    static List<ComboNode> Swapper = new List<ComboNode>();
    public static void CallSwap(ComboNode node)
    {
        Swapper.Add(node);
        if (Swapper.Count >= 2)
        {
            if (Swapper[0].NextNodes.Contains(Swapper[1]))
            {
                Swapper[0].NextNodes.Remove(Swapper[1]);
                Swapper[1].PreviousNodes.Remove(Swapper[0]);
            }
            else if (Swapper[1].NextNodes.Contains(Swapper[0]))
            {
                Swapper[1].NextNodes.Remove(Swapper[0]);
                Swapper[0].PreviousNodes.Remove(Swapper[1]);
            }
            Swapper.Clear();
        }
    }
}