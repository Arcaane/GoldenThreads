using UnityEngine;
using Random = UnityEngine.Random;

public class Goblin : Unit
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
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
       int tempDamage = (int)Random.Range(enemySO.actions[0].damageAmount.x, enemySO.actions[0].damageAmount.y + 1);
       if(currentStrength > 0) tempDamage += currentStrength;

       DoAttack(tempDamage);
    }
    
    private void Effect2()
    {
        DoAttack((int)enemySO.actions[1].damageAmount.x);
        DoStrength(enemySO.actions[1].buffAmount);
    }
    
    private void Effect3()
    {
        DoShield(enemySO.actions[2].armorAmount);
    }
}
