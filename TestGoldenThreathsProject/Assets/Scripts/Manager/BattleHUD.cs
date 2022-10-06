using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI hpText;
    [SerializeField] private Slider hpSlider;

    public void SetHUD(Unit unit)
    {
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
}
