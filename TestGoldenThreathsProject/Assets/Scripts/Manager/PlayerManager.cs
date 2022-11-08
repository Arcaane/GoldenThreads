using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField] private int healthMax = 100;
    [SerializeField] private int health;
    [SerializeField] private int manaMax;
    [HideInInspector] public bool isDead = false;
    public int currentMana;
    
    public RectTransform rectToAimPlayer;
    public int currentArmor;
    
    // Status variables
    private bool isBlessedActive;
    private bool isSunTurn;
    public int sunBlessStack;
    public int moonBlessStack;
    public int berserkBlessStack;
    public int enlightedBlessStack;
    public int shockedBlessStack;

    // Start is called before the first frame update
    void Start()
    {
        isBlessedActive = false;
        health = healthMax;
        StartTurn();
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
        
        if (health < 1)
        {
            PlayerDeath();
        }
        
        UIManager.Instance.SetPlayerHealth(health, healthMax, currentArmor);
    }

    public void GetArmor(int armor)
    {
        currentArmor += armor;
        
        UpdateUI();
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
        UIManager.Instance.SetPlayerMana(currentMana, manaMax);
    }

    public void ManaCost(int manaCost)
    {
        currentMana -= manaCost;
        UIManager.Instance.SetPlayerMana(currentMana, manaMax);
    }

    public void StartTurn()
    {
        currentMana = manaMax;
        currentArmor = 0;
        UpdateUI();

        if (!isBlessedActive) return;
        
    }

    public void AddAstralBuff(bool isSun, int addAmount)
    {
        if (isSun) sunBlessStack += addAmount;
        else moonBlessStack += addAmount;
        
        if(isBlessedActive) return;
        
        isBlessedActive = true;
        isSunTurn = isSun;
    }
}
