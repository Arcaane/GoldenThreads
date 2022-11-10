using UnityEngine.EventSystems;

public class SoulSeeringCard : Card

{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        //PlayerBuff(cardScriptableObjectSo.cardType, cardScriptableObjectSo.cardEffect.baseAmount);
        DeckContainer.Instance.DiscardCard(this);
    }
}
