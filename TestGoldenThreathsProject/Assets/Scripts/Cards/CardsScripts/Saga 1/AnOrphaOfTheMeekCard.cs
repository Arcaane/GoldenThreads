using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class AnOrphaOfTheMeekCard : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        foreach (var enemyRect in EnemyManager.Instance.enemiesRect)
        {
            if (!Helpers.DetectRectTransform(enemyRect)) continue;
            
            // Damages Dealt
            DealDamage(enemyRect, cardScriptableObjectSo.cardEffect.baseAmount, cardScriptableObjectSo.cardCost.baseAmount);
            
            // Discard Cards = cardEffect.baseAmount
            for (int i = 0; i < cardScriptableObjectSo.cardEffect.baseAmount; i++)
            {
                DeckContainer.Instance.DiscardCard(DeckContainer.Instance.playerHand[handIndex + i]);
            }
        }
    }
}
