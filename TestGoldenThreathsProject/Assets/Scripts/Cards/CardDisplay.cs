using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private CardScriptableObject cardScriptableObjectSo;

    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI cardTypeText;
    [SerializeField] private TextMeshProUGUI cardClassText;
    [SerializeField] private TextMeshProUGUI cardDescriptionText;
    [SerializeField] private TextMeshProUGUI cardCost;
    [SerializeField] private Image cardSplashSprite;

    void Start()
    {
        Print();
        rectToMove = GetComponent<RectTransform>();
        Invoke(nameof(SetPoses), 0.5f);
    }
    
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
    
    [Space(30)]
    public RectTransform rectToMove;
    public Coroutine openRoutine;
    public Coroutine closeRoutine;
    public Vector3 upPos;
    public Vector3 normalPos;
    public float speedUI = 2f;
    public bool block;
    public bool isUp;

    private void Update()
    {
        if(block) return;

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
    
    void Open()
    {
        isUp = true;

        if (closeRoutine != null)
        {
            StopCoroutine(closeRoutine);
        }
        openRoutine = StartCoroutine(moveTo(upPos));
    }

    void Close()
    {
        isUp = false;

        if (openRoutine != null)
        {
            StopCoroutine(openRoutine);
        }
        closeRoutine = StartCoroutine(moveTo(normalPos));
    }

    IEnumerator moveTo(Vector3 pos)
    {
        while (rectToMove.position != pos)
        {
            rectToMove.position = Vector3.Lerp(rectToMove.position, pos, speedUI);
            yield return null;
        }

        yield return 0;
    }

    void SetPoses()
    {
        normalPos = rectToMove.position;
        upPos = new Vector3(normalPos.x, normalPos.y + 100f, normalPos.z);
        Debug.Log($"{normalPos}  /  {upPos}");
    }
}
