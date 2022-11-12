using UnityEngine.EventSystems;

public class DeclaredEternalWarCard : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        foreach (var enemyRect in EnemyManager.Instance.enemiesRect)
        {
            if (!Helpers.DetectRectTransform(enemyRect)) continue;
            DealDamage(enemyRect, cardScriptableObjectSo.cardEffect.baseAmount, cardScriptableObjectSo.cardCost.baseAmount, false);
        }

        for (int i = 0; i < visiblePartDeck; i++)
        {
            DeckContainer.Instance.DiscardCard(DeckContainer.Instance.playerHand[i]);
        }
    }
}
