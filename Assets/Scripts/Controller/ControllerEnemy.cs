using Unity.Behavior;
using UnityEngine;
using System.Collections.Generic;

public class ControllerEnemy : ControllerBase
{
    protected BehaviorGraphAgent mAgent;
    [SerializeField]
    protected GameObject mWayPointList;
    protected List<GameObject> mWayPoints = new List<GameObject>();

    protected void Start()
    {
        Init();
    }

    protected void Init()
    {
        mAgent = GetComponent<BehaviorGraphAgent>();
        for(int i = 0; i < mWayPointList.transform.childCount; i++)
        {
            mWayPoints.Add(mWayPointList.transform.GetChild(i).gameObject);
        }
        mAgent.SetVariableValue("WayPoints", mWayPoints);
    }
}
