using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class CardScriptableObject : ScriptableObject
{
    [Header("Base Informations")]
    public new string cardName;
    public CardType cardType; // Attack, skill ou passif?
    public CardOrigin cardClass; // Quelle famille de carte (pour les regles)
    public CardTargetType cardTargetType; // Sur soit ou ennemy ?
    
    [Space(10)]
    [Header("Upgradable Informations")]
    public CardDescription cardDescription;
    public CardAmount cardCost;
    public CardAmount cardEffect;
    public CardAmount buffAmount;
    public bool isUpgraded;
    
    [Space(5)]
    [Header("Graphs")]
    public Sprite cardSplash;
    //public Sprite cardIcon;
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

public enum CardTargetType
{
    self, enemy
}

public enum CardOrigin
{
    Neutral,
    DayCycle
}

public enum CardType
{
    Attack,
    Skill,
    Power
}
