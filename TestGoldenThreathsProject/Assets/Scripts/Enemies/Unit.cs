using UnityEngine;

[RequireComponent(typeof(BattleHUD))]
public class Unit : MonoBehaviour, IDamageable
{
    private PlayerManager player;
    
    public string unitName;
    public int currentHp;
    private int currentShield;
    public int maxHp;
    private BattleHUD myHud;

    public bool provideAttack = false;
    public bool provideShield = false;
    public bool provideExhaust = false;
    
    
    void Start()
    {
        myHud = GetComponent<BattleHUD>();
        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    public void TakeDamage(int damage)
    {
        if (currentShield > 0)
        {
            var i = damage - currentShield;
            if (i > -1)
            {
                currentShield = 0;
                currentHp -= i;
            }
            else
            {
                currentShield -= damage;
            }
        }
        else
        {
            currentHp -= damage;
        }
        
        myHud.SetHp(this);

        if (currentHp < 1)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
    public void DoAttack(int i)
    {
        player.TakeDamage(i);
    }

    public void DoShield(int i)
    {
        currentShield += i;
    }

    public void DoExhaust()
    {
        // Function dans playerManager qui permet de l'exhaust
    }
}
