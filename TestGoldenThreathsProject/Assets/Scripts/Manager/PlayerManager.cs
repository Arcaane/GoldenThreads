using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private int healthMax = 100;
    [SerializeField] private int health;
    [SerializeField] private int manaMax;
    [HideInInspector] public bool isDead = false;
    private int mana;
    
    public RectTransform rectToAimPlayer;
    public int currentArmor;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        mana = manaMax;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        var armorVar = currentArmor;
        
        if (currentArmor > 0)
        {
            damage -= armorVar;
            if (damage > -1)
            {
                currentArmor = 0;
                health -= (damage - currentArmor);
            }
            else
            {
                currentArmor -= damage;
            }
        }
        else
        {
            health -= damage;
        }

        UpdateUI();
        
        if (health < 1)
        {
            PlayerDeath();
        }
    }

    public void GetArmor(int armor, int cardCostAmount)
    {
        currentArmor += armor;
        mana -= cardCostAmount;
        UpdateUI();
        Debug.Log($"Le joueur à reçu + {armor} d'armure");
    }

    public void PlayerDeath()
    {
        Debug.Log($"Le joueur est crevé");
        isDead = true;
    }

    public void PlayerWin()
    {
        Debug.Log($"Le joueur à gagné, bravo champion");
    }

    public void UpdateUI()
    {
        UIManager.Instance.SetPlayerHealth(health, healthMax, currentArmor);
        UIManager.Instance.SetPlayerMana(mana, manaMax);
    }
}
