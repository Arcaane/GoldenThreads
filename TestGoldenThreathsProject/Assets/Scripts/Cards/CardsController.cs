using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CardsController : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private Vector3 firstPos;
    private float moveSpeed = 3f;
    private Transform cardHandler;
    private Transform cardHandlerOnDraw;
    public CardDisplay _cardDisplay;
    private RectTransform myrect;

    private void Start()
    {
        myrect = GetComponent<RectTransform>();
        _cardDisplay = GetComponent<CardDisplay>();
        
        var parent = transform.parent;
        cardHandler = parent;
        cardHandlerOnDraw = parent.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (_cardDisplay.openRoutine != null)
        {
            StopCoroutine(_cardDisplay.openRoutine);
        }
        else if(_cardDisplay.closeRoutine != null)
        {
            StopCoroutine(_cardDisplay.closeRoutine);
        }
        _cardDisplay.block = true;
        
        Debug.Log($"Drag Begun");
        transform.SetParent(cardHandlerOnDraw);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        _cardDisplay.block = false;
        transform.SetParent(cardHandler);
        Debug.Log($"OnEndDrag");
    }
}
