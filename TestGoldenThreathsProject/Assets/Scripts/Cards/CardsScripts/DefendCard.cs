using UnityEngine;
using UnityEngine.EventSystems;

public class DefendCard : Card
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        
        if (Helpers.DetectRectTransform(playerRect))
        {
            GivePlayerArmor(cardScriptableObjectSo.cardEffect.baseAmount, cardScriptableObjectSo.cardCost.baseAmount);
            DeckContainer.Instance.DiscardCard(gameObject);
        }
    }
}
