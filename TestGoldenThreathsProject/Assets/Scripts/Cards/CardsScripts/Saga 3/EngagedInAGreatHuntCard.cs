using UnityEngine;
using UnityEngine.EventSystems;

public class EngagedInAGreatHuntCard : Card
{
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        if (!canPlayCard) return;
        
        var enemyRect = EnemyManager.Instance.enemiesRect;
        for (int i = 0; i < enemyRect.Count; i++)
        {
            int eMaxHealth = 0;
            RectTransform rectToDamage = null;
            if (!Helpers.DetectRectTransform(enemyRect[i])) continue;
            if (enemyRect[i].GetComponent<Unit>().currentHp > eMaxHealth)
            {
                rectToDamage = enemyRect[i];
            }

            if (i == enemyRect.Count)
            {
                if (rectToDamage)
                {
                    DealDamage(rectToDamage, cardScriptableObjectSo.cardEffect.baseAmount, cardScriptableObjectSo.cardCost.baseAmount);
                    DeckContainer.Instance.DiscardCard(this);
                }
            }
        }
    }
}
