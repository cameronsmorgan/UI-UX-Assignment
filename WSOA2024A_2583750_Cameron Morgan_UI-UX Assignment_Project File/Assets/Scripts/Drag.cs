using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    Transform parentAfterDrag;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform initialParent;
    private Vector3 initialPosition;

    public UnityEvent<PointerEventData> BeginDrag;
    public UnityEvent<PointerEventData> EndDrag;

    private bool isDraggable = true;

    
    public static GameObject draggedObject;


    public bool IsDraggable()
    {
        return isDraggable;
    }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        if (!isDraggable)
            return;

       
        initialParent = transform.parent;
        initialPosition = transform.position;

        draggedObject = gameObject; 
        BeginDrag?.Invoke(eventData);

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (!isDraggable)
            return;

       
        rectTransform.position = eventData.position;

        transform.position = Input.mousePosition;
 
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        if (!isDraggable)
            return;

       
        canvasGroup.blocksRaycasts = true;
        EndDrag?.Invoke(eventData);
       
        if (eventData.pointerEnter == null || !eventData.pointerEnter.CompareTag("ChestSlot"))
        {
            transform.SetParent(initialParent);
            rectTransform.position = initialPosition;
            draggedObject = null; 
            return;

            
    
        }

        transform.SetParent(parentAfterDrag);
    }

   
    public void SetDraggable(bool draggable)
    {
        isDraggable = draggable;
    }
}







