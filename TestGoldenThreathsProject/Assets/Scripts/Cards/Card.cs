using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Variables
    
    protected PlayerManager player;
    [SerializeField] protected CardScriptableObject cardScriptableObjectSo;
    protected RectTransform playerRect;
    #endregion

    #region ProgVariables
    
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardTypeText;
    [SerializeField] private TextMeshProUGUI cardClassText;
    [SerializeField] private TextMeshProUGUI cardDescriptionText;
    [SerializeField] private TextMeshProUGUI cardCost;
    [SerializeField] private Image cardSplashSprite;

    [Space(5)] private Vector3 firstPos;
    private float moveSpeed = 3f;
    private Transform cardHandler;
    private Transform cardHandlerOnDraw;
    public RectTransform rectToMove;
    private Coroutine openRoutine;
    private Coroutine closeRoutine;
    public Vector3 upPos;
    public Vector3 normalPos;
    private float speedUI = 0.10f;
    private bool block;
    private bool isUp;

    public int handIndex;

    #endregion

    public virtual void Start()
    {
        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); // Attention Couteux
        playerRect = player.rectToAimPlayer;
        
        var parent = transform.parent;
        cardHandler = parent;

        Print();
        rectToMove = GetComponent<RectTransform>();
        SetPoses();
    }
    
    public virtual void Update()
    {
        if (block) return;

        DetectCard();
    }

    private void DetectCard()
    {
        if (Helpers.DetectRectTransform(rectToMove))
        {
            if (!isUp)
            {
                Open();
            }
        }
        else
        {
            if (isUp)
            {
                Close();
            }
        }
    }

    #region UI
    void Print()
    {
        cardNameText.text = cardScriptableObjectSo.cardName;
        cardTypeText.text = $"{cardScriptableObjectSo.cardType}";

        if (cardScriptableObjectSo.isUpgraded)
        {
            cardCost.text = cardScriptableObjectSo.cardCost.upgradedAmount.ToString();
            cardDescriptionText.text = cardScriptableObjectSo.cardDescription.upgradedAmount;
        }
        else
        {
            cardCost.text = cardScriptableObjectSo.cardCost.baseAmount.ToString();
            cardDescriptionText.text = cardScriptableObjectSo.cardDescription.baseAmount;
        }

        if (cardScriptableObjectSo.cardSplash != null)
        {
            cardSplashSprite.sprite = cardScriptableObjectSo.cardSplash;
        }
    }
    
    private void Open()
    {
        isUp = true;

        if (closeRoutine != null)
        {
            StopCoroutine(closeRoutine);
        }

        openRoutine = StartCoroutine(moveTo(upPos));
    }

    private void Close()
    {
        isUp = false;

        if (openRoutine != null)
        {
            StopCoroutine(openRoutine);
        }

        closeRoutine = StartCoroutine(moveTo(normalPos));
    }

    public IEnumerator moveTo(Vector3 pos)
    {
        while (rectToMove.position != pos)
        {
            rectToMove.position = Vector3.Lerp(rectToMove.position, pos, speedUI);
            yield return null;
        }

        yield return 0;
    }

    public void SetPoses()
    {
        normalPos = rectToMove.position;
        upPos = new Vector3(normalPos.x, normalPos.y + 100f, normalPos.z);
        DetectCard();
    }

    #endregion

    #region Drag&DropFunctions

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        if (openRoutine != null)
        {
            StopCoroutine(openRoutine);
        }
        else if (closeRoutine != null)
        {
            StopCoroutine(closeRoutine);
        }

        block = true;
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        block = false;
        transform.SetParent(cardHandler);
    }

    #endregion
    
    #region CardsEffectsFunctions
    public void GivePlayerArmor(int armorAmount, int cardCost)
    {
        player.GetArmor(armorAmount, cardCost);
    }

    public void DealDamage(RectTransform enemy, int damage, bool allEnemies = false)
    {
        if (allEnemies)
        {
            
        }
        else
        {
            IDamageable damageable = enemy.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
            enemy.GetComponent<Unit>().SetHp(enemy.GetComponent<Unit>());
        }
    }
    #endregion
}