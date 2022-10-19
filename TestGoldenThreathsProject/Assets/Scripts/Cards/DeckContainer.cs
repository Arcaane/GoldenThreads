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

    public void StartTurn()
    {
        SetupDeck();
        ShuffleDeck();
        SetPlayerTurnCards();
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
    
    private void SetPlayerTurnCards()
    {
        if (cardInHandAtTheStartOfTheTurn >= drawPile.Count)
        {
            for (int i = 0; i < cardInHandAtTheStartOfTheTurn; i++)
            {
                playerHand.Add(drawPile[i]);
                drawPile.Remove(drawPile[i]);
            }
        }
        else
        {
            foreach (var discardedCard in discardPile)
            {
                drawPile.Add(discardedCard);
                discardPile.Remove(discardedCard);
            }
            
            for (int i = 0; i < cardInHandAtTheStartOfTheTurn; i++)
            {
                playerHand.Add(drawPile[i]);
                drawPile.Remove(drawPile[i]);
            }
        }
        
        for (int i = 0; i < cardInHandAtTheStartOfTheTurn; i++)
        {
            Instantiate(playerHand[i], cardsSpawnPoints[i].position, Quaternion.identity, cardsSpawnPoints[i]);
        }
    }

    private void DiscardCard(GameObject card)
    {
        discardPile.Add(card);
        playerHand.Remove(card);
    }
}
