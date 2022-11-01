using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderling : Unit
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        switch (provideEffect)
        {
            case 1: Effect1(); break;
            default: Debug.Log("Y'a r frr t'as déconné"); break;
        }
    }

    private void Effect1()
    {
        DoAttack((int)enemySO.actions[0].damageAmount.x);
    }
}
