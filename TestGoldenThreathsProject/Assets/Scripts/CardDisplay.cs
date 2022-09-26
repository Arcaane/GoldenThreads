using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private Cards cardSO;

    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardTypeText;
    [SerializeField] private TextMeshProUGUI cardClassText;
    [SerializeField] private TextMeshProUGUI cardDescriptionText;
    [SerializeField] private TextMeshProUGUI cardCost;
    
    [SerializeField] private Image cardSplashSprite;

    void Start()
    {
        Print();
    }
    
    void Print()
    {
        cardNameText.text = cardSO.cardName;
        cardTypeText.text = $"{cardSO.cardType}";
        cardClassText.text = $"{cardSO.cardClass}";

        if (cardSO.isUpgraded)
        {
            cardCost.text = cardSO.cardCost.upgradedAmount.ToString();
            cardDescriptionText.text = cardSO.cardDescription.upgradedAmount;
        }
        else
        {
            cardCost.text = cardSO.cardCost.baseAmount.ToString();
            cardDescriptionText.text = cardSO.cardDescription.baseAmount;
        }

        if (cardSO.cardSplash != null)
        {
            cardSplashSprite.sprite = cardSO.cardSplash;
        }
    }
}
