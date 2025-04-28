using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

[CreateAssetMenu(fileName = "ComboNodeGraph", menuName = "NodeGraph/ComboNodeGraph")]
public class ComboNodeGraph : NodeGraph 
{ 
	public List<ComboNode> GetComboNodes()
	{
		List<ComboNode> comboNodes = new List<ComboNode>();
		foreach (Node node in nodes)
		{
			comboNodes.Add(node as ComboNode);
		}
		return comboNodes;
	}
}