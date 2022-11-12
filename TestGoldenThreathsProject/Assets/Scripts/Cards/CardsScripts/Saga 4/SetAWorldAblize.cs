using UnityEngine.EventSystems;

public class SetAWorldAblize : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        foreach (var enemyRect in EnemyManager.Instance.enemiesRect)
        {
            if (!Helpers.DetectRectTransform(enemyRect)) continue;
            DealDamage(enemyRect, DeckContainer.Instance.discardPile.Count, cardScriptableObjectSo.cardCost.baseAmount, true);
        }
        
        DeckContainer.Instance.DiscardCard(this);
    }
}
