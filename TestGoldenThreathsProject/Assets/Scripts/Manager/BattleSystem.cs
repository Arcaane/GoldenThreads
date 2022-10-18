using System;
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

    private void Update()
    {
        switch (state)
        {
            case BattleStates.START:
                break;
            case BattleStates.PLAYERTURN:
                break;
            case BattleStates.ENEMYTURN:
                break;
            case BattleStates.WON:
                break;
            case BattleStates.LOST:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}
