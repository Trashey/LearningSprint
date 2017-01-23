using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler {
    //static is good in this case, because we want the user to only drag 1 at a time
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
   //Record what parent it is
    Transform startParent;
    Transform canvas;

    public void OnBeginDrag(PointerEventData eventData)
    {
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //pass the item through what is being dragged
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        canvas = GameObject.FindGameObjectWithTag("UI Canvas").transform;
        transform.SetParent(canvas);
       // transform.parent = canvas;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;  
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(transform.parent + " == " + canvas);
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        //If the item has been dropped in a new slot, we want it to stay there
        //   transform.position = transform.parent.position;
        if (transform.parent == canvas)
        {
            transform.position = startPosition;
            transform.SetParent(startParent);
            //transform.parent = startParent;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
