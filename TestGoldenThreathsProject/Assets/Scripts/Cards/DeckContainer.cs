using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class DeckContainer : MonoBehaviour
{
    [SerializeField] private GameObject[] baseDeck;
    
    [SerializeField] private List<GameObject> drawPile;
    [SerializeField] private List<GameObject> discardPile;
    [SerializeField] private List<GameObject> playerHand;
    [SerializeField] private RectTransform[] cardsSpawnPoints;
    
    [SerializeField] private int cardInHandAtTheStartOfTheTurn = 5;

    public static DeckContainer Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    public void StartTurn()
    {
        SetupDeck();
        ShuffleDeck();
        DrawCard(cardInHandAtTheStartOfTheTurn);
    }
    
    void SetupDeck()
    {
        drawPile = new List<GameObject>();

        if (drawPile.Count > 1) return;
        for (int i = 0; i < baseDeck.Length; i++)
        {
            drawPile.Add(baseDeck[i]);
        }
    }

    void ShuffleDeck()
    {
        var rand = new Random();
        rand.ShuffleList(drawPile);
    }
    
    public void DrawCard(int numberOfCardsToDraw)
    {
        if (numberOfCardsToDraw > drawPile.Count)
        {
            Debug.Log(discardPile.Count);
            
            for (int i = 0; i < discardPile.Count; i++)
            {
                discardPile.RemoveAt(i);
                drawPile.Add(discardPile[i]);
            }
        }
        
        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            playerHand.Add(drawPile[i]);
            drawPile.Remove(drawPile[i]);
        }
        
        for (int i = 0; i < numberOfCardsToDraw; i++)
        {
            GameObject CardGO = Instantiate(playerHand[i], cardsSpawnPoints[i].position, Quaternion.identity, cardsSpawnPoints[playerHand.Count]);
            CardGO.SetActive(true);
        }
    }

    public void DiscardCard(GameObject card)
    {
        discardPile.Add(playerHand.Find( card=> this));
        playerHand.RemoveAt(playerHand.FindIndex(card => this));
        card.transform.SetParent(transform.root);
        card.SetActive(false);
        ReplaceCards();
    }

    private void ReplaceCards()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            Debug.Log("Done " + playerHand[i].name);
        }
    }
}