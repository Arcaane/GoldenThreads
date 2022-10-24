using UnityEngine;
using UnityEngine.EventSystems;

public class StabCard : Card
{
    public override void Start()
    {
        base.Start();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        
        for (int i = 0; i < EnemyManager.Instance.enemiesRect.Count; i++)
        {
            if (Helpers.DetectRectTransform(EnemyManager.Instance.enemiesRect[i]))
            {
                DealDamage(EnemyManager.Instance.enemiesRect[i], cardScriptableObjectSo.cardEffect.baseAmount);
                DeckContainer.Instance.DiscardCard(this.gameObject);
            }
        }
    }
}
