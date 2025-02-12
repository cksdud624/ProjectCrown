using UnityEngine;

public class PlayerBase : CharacterBase
{
    protected PlayerStat mPlayerStat;

    protected override void Init()
    {
        base.Init();

        if(mCharacterStatus is PlayerStat)
            mPlayerStat = (PlayerStat)mCharacterStatus;
        else
            Debug.Log("Cast Error On PlayerStat");
    }
}