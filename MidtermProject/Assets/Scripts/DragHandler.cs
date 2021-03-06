﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//this script was taken from my Woebegone Woods project

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject item; //item being dragged
    public GameObject dialogueUI;

    public GameManager gm;

    Vector2 startPosition;
    public Transform startParent;
    public static bool begindragging = false;


    private void Start()
    {
        startPosition = transform.position;
        startParent = transform.parent;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        //startPosition = transform.position;
        //startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        begindragging = true;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData) //dragging item follows mouse
    {
        //icons follow the mouse position in real time
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePos;

    }


    public void OnEndDrag(PointerEventData eventData) //sets char blocks back to starting position if not on a slot
    {
        item = null;

        if (transform.parent == startParent || transform.parent == transform.root)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
        }

        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void Reset()
    {
        if (gm.CurrentMixIngredients.Count == 0)
        {
            return;
        }
        transform.position = startPosition;
        transform.SetParent(startParent);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
