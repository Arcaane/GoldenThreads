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
    public SagaClass cardSaga;
    
    [Space(5)]
    [Header("Graphs")]
    public Sprite cardSplash;
}

[System.Serializable]
public struct CardAmount
{
    public int baseAmount;
    public int sagaAmount;
}
[System.Serializable]
public struct CardDescription
{
    public string baseDescription;
    public string sagaDescription;
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

public enum SagaClass
{
    None = 0,
    Saga1 = 1,
    Saga2 = 2,
    Saga3 = 3,
    Saga4 = 4,
    Saga5 = 5,
}
