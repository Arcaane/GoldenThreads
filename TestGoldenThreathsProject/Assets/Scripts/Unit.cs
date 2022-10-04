using UnityEngine;

[RequireComponent(typeof(BattleHUD))]
public class Unit : MonoBehaviour, IDamageable
{
    public string unitName;
    public int currentHp;
    public int maxHp;
    private BattleHUD myHud;
    
    void Start()
    {
        myHud = GetComponent<BattleHUD>();
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
        myHud.SetHp(this);

        if (currentHp < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
