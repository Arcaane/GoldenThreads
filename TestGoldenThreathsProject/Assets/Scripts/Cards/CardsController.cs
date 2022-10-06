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
        Debug.Log($"Drag Begun");
        transform.SetParent(cardHandlerOnDraw);
        _cardDisplay.block = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(cardHandler);
        Debug.Log($"OnEndDrag");
        _cardDisplay.block = false;
    }
}
