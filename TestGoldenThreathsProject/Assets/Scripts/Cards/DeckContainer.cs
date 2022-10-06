using UnityEngine;
using Random = System.Random;

public class DeckContainer : MonoBehaviour
{
    [SerializeField] private GameObject[] baseDeck;
    [SerializeField] private GameObject[] myDeck;

    [SerializeField] private Transform playerHand;
    [SerializeField] private int cardInHandAtTheStartOfTheTurn = 5;

    private void Start()
    {
        SetupDeck();
        ShuffleDeck();
        DisplayDeck();
    }
    
    void SetupDeck()
    {
        myDeck = new GameObject[baseDeck.Length];

        if (myDeck.Length < 1) return;
        for (int i = 0; i < baseDeck.Length; i++)
        {
            myDeck[i] = baseDeck[i];
        }
    }

    void ShuffleDeck()
    {
        var rand = new Random();
        rand.ShuffleArray(myDeck);
    }
    
    private void DisplayDeck()
    {
        for (int i = 0; i < cardInHandAtTheStartOfTheTurn; i++)
        {
            Instantiate(myDeck[i], playerHand);
        }
    }
}
