using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private int healthMax = 100;
    [SerializeField] private int health;
    [SerializeField] private int manaMax;
    [SerializeField] private int mana;

    public RectTransform rectToAimPlayer;
    public int currentArmor;

    // Start is called before the first frame update
    void Start()
    {
        health = healthMax;
        mana = manaMax;
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

        if (health > 1)
        {
            PlayerDeath();
        }
    }

    public void GetArmor(int armor, int cardCostAmount)
    {
        currentArmor += armor;
        Debug.Log($"Le joueur à reçu + {armor} d'armure");
    }
        
    private void PlayerDeath()
    {
        Debug.Log($"Le joueur est crevé");
    }

    public void UpdateUI()
    {
        UIManager.Instance.SetPlayerHealth(health, healthMax, currentArmor);
    }
}
