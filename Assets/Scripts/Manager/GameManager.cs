using System.ComponentModel;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    OptionManager mOptionManager;

    [DisplayName("Option Data")]
    [SerializeField]
    private OptionData mOptionData;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        mOptionManager = gameObject.AddComponent<OptionManager>();
        mOptionManager.Init(mOptionData);
    }
}
