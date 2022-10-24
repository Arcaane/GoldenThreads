using UnityEngine;
using Random = UnityEngine.Random;

public class Goblin : Unit
{
    [SerializeField] private int provideEffect;
    
    public int ChooseEffect()
    {
        var tempEffect = Random.Range(0, enemySO.actions.Length + 1);
        if(currentStrength > 0) currentStrength -= 1;

        return tempEffect;
    }
    
    public void ApplyEffect()
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
