using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OptionManager : MonoBehaviour
{
    private static OptionManager mInstance;

    private OptionData mOptionData;
    public OptionData OptionData => mOptionData;

    public static OptionManager Instance
    {
        get 
        {
            if (mInstance == null)
            {
                Debug.Log("OptionManager Instance is Null : Check GameManager");
                return null;
            }
            return mInstance;
        } 
    }

    public void Init(OptionData optionData)
    {
        if(mInstance != null)
        {
            Debug.Log("Already Init Option Manager");
            return;
        }
        mInstance = this;

        mOptionData = optionData;
    }
}
