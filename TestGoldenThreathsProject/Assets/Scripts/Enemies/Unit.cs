using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Unit : MonoBehaviour, IDamageable
{
    private PlayerManager player;
    protected EnemyScriptableCreator enemySO;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Slider hpSlider;
    
    [SerializeField] protected string unitName;
    [SerializeField] protected int currentHp;
    [SerializeField] protected int currentShield;
    [SerializeField] protected int maxHp;
    
    public virtual void Start()
    {
        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        
        unitName = enemySO.enemyName;
        maxHp = (int)Random.Range(enemySO.HealthRange.x, enemySO.HealthRange.y + 1);
        currentHp = maxHp;
        SetHUD(this);
    }

    #region UI
    
    private void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        hpText.text = $"{unit.currentHp} / {unit.maxHp}";
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;
    }
    
    private void SetHp(Unit unit)
    {
        hpSlider.value = unit.currentHp;
        hpText.text = $"{unit.currentHp} / {unit.maxHp}";
    }
    #endregion
    
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
        
        SetHp(this);

        if (currentHp < 1)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    
    private void DoAttack(int i)
    {
        player.TakeDamage(i);
    }

    private void DoShield(int i)
    {
        currentShield += i;
    }

    private void DoExhaust()
    {
        // Function dans playerManager qui permet de l'exhaust
    }
}
