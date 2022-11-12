using UnityEngine.EventSystems;

public class OfferedHisFavorsToDemonsCard : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        int tempsEffects = 0;

        if (player.sunBlessStack > 0)
            tempsEffects++;
        
        if (player.moonBlessStack > 0)
            tempsEffects++;
        
        if (player.berserkBlessStack > 0)
            tempsEffects++;
        
        if (player.enlightedBlessStack > 0)
            tempsEffects++;
        
        if (player.shockedBlessStack > 0)
            tempsEffects++;
        
        GivePlayerArmor(cardScriptableObjectSo.cardEffect.baseAmount * tempsEffects, cardScriptableObjectSo.cardCost.baseAmount);
        DeckContainer.Instance.DiscardCard(this);
    }
}
