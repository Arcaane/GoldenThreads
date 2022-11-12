using UnityEngine.EventSystems;
public class BlessedByTheSun : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        PlayerBuff(cardScriptableObjectSo.cardType, cardScriptableObjectSo.cardEffect.baseAmount, cardScriptableObjectSo.cardCost.baseAmount);
        DeckContainer.Instance.DiscardCard(this);
    }
}
