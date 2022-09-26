using UnityEngine;
using Random = System.Random;

public class DeckContainer : MonoBehaviour
{
    [SerializeField] private GameObject[] baseDeck;
    [SerializeField] private GameObject[] myDeck;

    private void Start()
    {
        SetupDeck();
        ShuffleDeck();
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
}
