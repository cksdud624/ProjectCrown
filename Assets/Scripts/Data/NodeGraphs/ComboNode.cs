using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ComboNode : Node 
{
	public eAnimationType AnimationType;
	public eAnimationIndexType IndexType;
	public int AnimationIndex;
	public eInputCommand InputCommand;
	private ComboNode Mine;
    [Input] public ComboNode PreviousNode;
    [Output] public ComboNode NextNode;
	public List<ComboNode> PreviousNodes;
	public List<ComboNode> NextNodes;


	// Use this for initialization
	protected override void Init() {
		base.Init();
		Mine = this;
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "NextNode")
			return Mine;
		return null;
    }

    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        base.OnCreateConnection(from, to);
		ComboNode comboNode = from.GetOutputValue() as ComboNode;
		if (this != comboNode)
		{
			if(!comboNode.NextNodes.Contains(this))
				comboNode.NextNodes.Add(this);
			if(!PreviousNodes.Contains(comboNode))
				PreviousNodes.Add(comboNode);
		}
    }

    public override void OnRemoveConnection(NodePort port)
    {
        base.OnRemoveConnection(port);
		CustomNodeExchange.CallSwap(this);
    }


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
			else if(Swapper[1].NextNodes.Contains(Swapper[0]))
            {
                Swapper[1].NextNodes.Remove(Swapper[0]);
                Swapper[0].PreviousNodes.Remove(Swapper[1]);
            }
            Swapper.Clear();
        }
    }
}