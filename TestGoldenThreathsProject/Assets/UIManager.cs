using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    
    #region PlayerUI
    [Header("Player UI")]
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private TextMeshProUGUI playerArmorText;
    [SerializeField] private Slider playerHealthSlider;
    [SerializeField] private GameObject armorSection;
    [SerializeField] private TextMeshProUGUI playerManaText;
    #endregion
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }


    public void SetPlayerHealth(int currentHealth, int maxHealth, int currentArmor)
    {
        playerHealthText.text = $"{currentHealth} / {maxHealth}";
        playerHealthSlider.maxValue = maxHealth;
        playerHealthSlider.value = currentHealth;

        if (currentArmor > 0)
        {
            armorSection.SetActive(true);
            playerArmorText.text = currentArmor.ToString();
        }
        else
        {
            armorSection.SetActive(false);
        }
    }


    public void SetPlayerMana(int currentMana, int maxMana)
    {
        playerManaText.text = $"{currentMana} / {maxMana}";
    }
}
