using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ComboRoute", menuName = "Scriptable Object/ComboRoute")]
public class ComboRoute : ScriptableObject
{
    [SerializeField]
    private List<ComboNode> comboNodes;
    public List<ComboNode> ComboNodes { get { return comboNodes; } }
}