using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Unit : MonoBehaviour, IDamageable
{
    private PlayerManager player;
    [SerializeField] protected EnemyScriptableCreator enemySO;
    
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Slider hpSlider;
    [SerializeField] protected Image intentIcon; 
    
    [SerializeField] protected string unitName;
    [SerializeField] public int currentHp;
    [SerializeField] protected int currentShield;
    [SerializeField] protected int currentStrength;
    [SerializeField] protected int maxHp;
    
    [SerializeField] public int provideEffect;
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
        //intentIcon.gameObject.SetActive(false);
        nameText.text = unit.unitName;
        hpText.text = $"{unit.currentHp} / {unit.maxHp}";
        hpSlider.maxValue = unit.maxHp;
        hpSlider.value = unit.currentHp;
    }
    
    public void SetHp(Unit unit)
    {
        hpSlider.value = unit.currentHp;
        hpText.text = $"{unit.currentHp} / {unit.maxHp}";
    }
    #endregion

    #region Functions Region

    public void ChooseEffect()
    {
        if(currentStrength > 0) currentStrength -= 1;
        
        provideEffect = Random.Range(0, enemySO.actions.Length);
        
        intentIcon.sprite = enemySO.actions[provideEffect].intentIcon;
        intentIcon.gameObject.SetActive(true);
        
        Debug.Log($"{gameObject.name} effect provided : {provideEffect}");
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
        
        SetHp(gameObject.GetComponent<Unit>());

        if (currentHp < 1)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
        EnemyManager.Instance.enemiesRect.Remove(this.GetComponent<RectTransform>());
        EnemyManager.Instance.enemiesOnBoard--;
    }
    
    protected void DoAttack(int i)
    {
        player.TakeDamage(i);
        Debug.Log($"Player took {i} damages");
    }

    protected void DoShield(int i)
    {
        currentShield += i;
        Debug.Log($"{enemySO.enemyName} gain {i} shield");
    }

    protected void DoStrength(int i)
    {
        currentStrength += i;
        Debug.Log($"{enemySO.enemyName} gain {i} strength");

    }
    
    protected void DoExhaust()
    {
        // Function dans playerManager qui permet de l'exhaust
    }

    public virtual void ApplyEffect() { }
    
    #endregion
}
