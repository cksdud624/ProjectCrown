using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ComboNode : Node 
{
    [Input] public ComboNode PreviousNode;
    [Output] public ComboNode NextNode;
	public List<ComboNode> PreviousNodes;
	public List<ComboNode> NextNodes;

    //실제 콤보 노드 정보
    public eAnimationIndexType IndexType;
    public eAnimationType AnimationType;
    public int AnimationIndex;

	public List<float> CancelMins;
	public List<float> CancelMaxs;

    public eInputCommand InputCommand;


    // Use this for initialization
    protected override void Init() {
		base.Init();
	}

	// Return the correct value of an output port when requested
	public override object GetValue(NodePort port)
	{
		if (port.fieldName == "NextNode")
		{
			return this;
		}
		return null;
    }

    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        base.OnCreateConnection(from, to);
		ComboNode comboNode = from.GetOutputValue() as ComboNode;
		if (this != comboNode)
		{
			if(comboNode.NextNodes == null)
				comboNode.NextNodes = new List<ComboNode>();
			if(comboNode.PreviousNodes == null)
				comboNode.PreviousNodes = new List<ComboNode>();
			if(PreviousNodes == null)
				PreviousNodes = new List<ComboNode>();
			if(NextNodes == null)
				NextNodes = new List<ComboNode>();

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