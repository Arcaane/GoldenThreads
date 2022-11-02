using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Unit
{
    public bool spiderlingWasKilled;
    
    public override void ApplyEffect()
    {
        base.ApplyEffect();

        if (!spiderlingWasKilled && provideEffect == 2)
        {
            provideEffect = 0;
        }
        
        if (spiderlingWasKilled)
        {
            provideEffect = 2;
            spiderlingWasKilled = false;
        }
        
        switch (provideEffect)
        {
            case 0: Effect1(); break;
            case 1: Effect2(); break;
            case 2: Effect3(); break;
            default: Debug.Log("Y'a r frr t'as déconné"); break;
        }
        
        Debug.Log($"{gameObject.name} effect done : {provideEffect}");
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
