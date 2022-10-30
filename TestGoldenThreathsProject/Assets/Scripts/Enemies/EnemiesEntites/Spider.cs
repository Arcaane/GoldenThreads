using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Unit
{
    public bool spiderlingWasKilled;
    
    protected override void ApplyEffect()
    {
        base.ApplyEffect();
        
        if (spiderlingWasKilled)
        {
            provideEffect = 3;
            spiderlingWasKilled = false;
        }
        
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
        DoAttack((int)enemySO.actions[0].damageAmount.x);
        // Add shocked effect
    }
    
    private void Effect2()
    {
        EnemyManager.Instance.SpawnEnemies(1, enemySO.actions[1].summonEntity);
    }
    
    private void Effect3()
    {
        DoAttack((int)enemySO.actions[2].damageAmount.x);
    }
}
