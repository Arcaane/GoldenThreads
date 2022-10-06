using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStates { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleSystem : MonoBehaviour
{
    public BattleStates state;
    
    void Start()
    {
        state = BattleStates.START;
        SetupBattle();
    }

    private void SetupBattle()
    {
        
    }
}
