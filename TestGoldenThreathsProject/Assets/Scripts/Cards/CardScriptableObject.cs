using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardScriptableObject : ScriptableObject
{
    [Header("Base Informations")]
    public new string cardName;
    public CardType cardType; // Attack, skill ou passif?
    //public CardTargetType cardTargetType; // Sur soit ou ennemy ?
    
    [Space(10)]
    [Header("Upgradable Informations")]
    public CardDescription cardDescription;
    public CardAmount cardCost;
    public CardAmount cardEffect;
    public bool isUpgraded;
    
    [Space(5)]
    [Header("Graphs")]
    public Sprite cardSplash;
}

[System.Serializable]
public struct CardAmount
{
    public int baseAmount;
    public int upgradedAmount;
}
[System.Serializable]
public struct CardDescription
{
    public string baseAmount;
    public string upgradedAmount;
}

public enum CardType
{
    None = 0,
    Moon,
    Sun,
    Berserk,
    Enlight,
    Shocked,
    SoulSplit
}
