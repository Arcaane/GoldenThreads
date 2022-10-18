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
    //[SerializeField] private EnemyManager enemyManager;
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
    private RectTransform rectToMove;
    private Coroutine openRoutine;
    private Coroutine closeRoutine;
    private Vector3 upPos;
    private Vector3 normalPos;
    private float speedUI = 0.10f;
    private bool block;
    private bool isUp;

    #endregion

    public virtual void Start()
    {
        player = GameObject.Find("PlayerManager").GetComponent<PlayerManager>(); // Attention Couteux
        playerRect = player.rectToAimPlayer;
        
        var parent = transform.parent;
        cardHandler = parent;
        cardHandlerOnDraw = parent.parent;

        Print();
        rectToMove = GetComponent<RectTransform>();
        Invoke(nameof(SetPoses), 0.5f);
    }
    
    public virtual void Update()
    {
        if (block) return;

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
        cardClassText.text = $"{cardScriptableObjectSo.cardClass}";

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

    private IEnumerator moveTo(Vector3 pos)
    {
        while (rectToMove.position != pos)
        {
            rectToMove.position = Vector3.Lerp(rectToMove.position, pos, speedUI);
            yield return null;
        }

        yield return 0;
    }

    private void SetPoses()
    {
        normalPos = rectToMove.position;
        upPos = new Vector3(normalPos.x, normalPos.y + 100f, normalPos.z);
        Debug.Log($"{normalPos}  /  {upPos}");
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

        Debug.Log($"Drag Begun");
        transform.SetParent(cardHandlerOnDraw);
    }

    public virtual void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        block = false;
        transform.SetParent(cardHandler);
        Debug.Log($"OnEndDrag");
    }

    #endregion
    
    #region CardsEffectsFunctions
    public void GivePlayerArmor(int armorAmount)
    {
        player.currentArmor += armorAmount;
    }

    public void DealDamage(GameObject enemy, int damage, bool allEnemies = false)
    {
        if (allEnemies)
        {
            
        }
        else
        {
            IDamageable damageable = GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        }
    }
    #endregion
    
}