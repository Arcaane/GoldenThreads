using UnityEngine.EventSystems;

public class DefendCard : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        if (Helpers.DetectRectTransform(playerRect))
        {
            GivePlayerArmor(cardScriptableObjectSo.cardEffect.baseAmount, cardScriptableObjectSo.cardCost.baseAmount);
            DeckContainer.Instance.DiscardCard(this);
        }
    }
}
