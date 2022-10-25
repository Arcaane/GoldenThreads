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

    public Transform cardHandler;
    public int cardWhoMoved;

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
            GameObject CardGO = Instantiate(drawPile[i], cardsSpawnPoints[i].position, Quaternion.identity, cardHandler);
            
            drawPile.Remove(drawPile[i]);
            playerHand.Add(CardGO);
            
            CardGO.SetActive(true);
        }
    }

    public void DiscardCard(GameObject card)
    {
        bool contains = playerHand.Contains(card);
        discardPile.Add(playerHand.Find( a=> contains));
        playerHand.RemoveAt(playerHand.FindIndex(a => contains));
        
        card.transform.SetParent(transform.root);
        card.SetActive(false);
        
        ReplaceCards();
    }

    private void ReplaceCards()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            Card cardToMove = playerHand[i].GetComponent<Card>();
            cardToMove.normalPos += new Vector3(-200, 0);
            cardToMove.upPos += new Vector3(-200, 0);
        }
    }
}