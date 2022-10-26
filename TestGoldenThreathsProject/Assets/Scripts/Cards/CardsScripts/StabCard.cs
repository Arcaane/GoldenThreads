using UnityEngine.EventSystems;

public class StabCard : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        foreach (var enemyRect in EnemyManager.Instance.enemiesRect)
        {
            if (!Helpers.DetectRectTransform(enemyRect)) continue;
            DealDamage(enemyRect, cardScriptableObjectSo.cardEffect.baseAmount);
            DeckContainer.Instance.DiscardCard(this);
        }
    }
}
