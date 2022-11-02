using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class DeckContainer : MonoBehaviour
{
    [SerializeField] private Card[] baseDeck;
    
    [SerializeField] private List<Card> drawPile;
    [SerializeField] private TextMeshProUGUI deckSizeText;
    
    [SerializeField] private List<Card> discardPile;

    [SerializeField] private List<Card> playerHand;
    
    public Transform[] cardSlots;
    public bool[] availableCardSlots;
    
    [SerializeField] private int cardInHandAtTheStartOfTheTurn = 5;

    public static DeckContainer Instance;

    public Transform cardHandler;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    public void StartDuel()
    {
        SetupDeck();
        ShuffleDeck();
        DrawCard(cardInHandAtTheStartOfTheTurn);
    }
    
    void SetupDeck()
    {
        drawPile = new List<Card>();

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
        if (drawPile.Count >= numberOfCardsToDraw)
        {
            for (int i = 0; i < numberOfCardsToDraw; i++)
            {
                int aimedIndex = playerHand.Count;
                if (availableCardSlots[aimedIndex] == true)
                {
                    Card newCardDrawed = Instantiate(drawPile[i]);
                    
                    var cardTransform = newCardDrawed.transform;
                    
                    newCardDrawed.gameObject.SetActive(true);
                    newCardDrawed.handIndex = aimedIndex;
                    cardTransform.position = cardSlots[aimedIndex].position;
                    cardTransform.SetParent(cardHandler);
                    
                    playerHand.Add(newCardDrawed);
                    drawPile.Remove(drawPile[i]);
                    availableCardSlots[aimedIndex] = false;
                }
                else
                {
                    Debug.Log("Slot invalide ou inexistant");
                }
            }
        }
        else
        {
            ReplaceCardInDrawPile();
            DrawCard(numberOfCardsToDraw);
        }
    }

    public void DiscardCard(Card card)
    {
        discardPile.Add(card);
        playerHand.Remove(card);
        card.gameObject.SetActive(false);
        availableCardSlots[card.handIndex] = true;
        ReplaceCards(card.handIndex);
        
        CardsCountHud();
    }

    private void ReplaceCardInDrawPile()
    {
        foreach (Card card in discardPile)
        {
            drawPile.Add(card);
        }
        discardPile.Clear();

        CardsCountHud();
    }
    
    private void ReplaceCards(int lastIndexGone)
    {
        for (int i = lastIndexGone; i < playerHand.Count; i++)
        {
            playerHand[i].transform.position = cardSlots[i].position;
            playerHand[i].SetPoses();
            
            playerHand[i].handIndex --;
            availableCardSlots[i + 1] = true;
            availableCardSlots[i] = false;
        }
    }

    private void CardsCountHud()
    {
        deckSizeText.text = drawPile.Count.ToString();
        //discardPileSizeText.text = discardPile.Count.ToString();
    }

    public void StartTurn()
    {
        if (playerHand.Count < cardInHandAtTheStartOfTheTurn)
        {
            DrawCard(cardInHandAtTheStartOfTheTurn - playerHand.Count);
        }
    }
}