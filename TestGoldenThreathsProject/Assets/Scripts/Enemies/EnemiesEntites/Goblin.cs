using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Goblin : Unit
{
    [SerializeField] private int provideEffect;
    
    public int ChooseEffect()
    {
        int tempEffect;
        tempEffect = Random.Range(0, enemySO.actions.Length + 1);
        return tempEffect;
    }
    
    public void ApplyEffet()
    {
        switch (provideEffect)
        {
            case 1: Effect1(); break;
            case 2: Effect2(); break;
            case 3: Effect3(); break;
            default: Debug.Log("Y'a r frr t'as déconné"); break;
        }
    }

    private void Effect1()
    {
        
    }
    
    private void Effect2()
    {
        
    }
    
    private void Effect3()
    {
        
    }
}
