using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slotscript : MonoBehaviour, IDropHandler

{
    private bool isEmpty = true;
    private Image itemImage;

    public TextMeshProUGUI _itemCountText;

    public TextMeshProUGUI _backpackamountText;
   
    private void Awake()
    {
        itemImage = GetComponent<Image>();
      
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }

    public void SetIsEmpty(bool isEmpty)
    {
        this.isEmpty = isEmpty;
    }


    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = Drag.draggedObject;

        if (draggedObject != null)
        {
            Drag draggedScript = draggedObject.GetComponent<Drag>();

            if (!draggedScript.IsDraggable())
                return;

            Slotscript draggedSlotScript = draggedObject.GetComponent<Slotscript>();

            if (draggedSlotScript != null && draggedSlotScript.IsEmpty())
            {
                // Dragging from chest to backpack
                if (transform.childCount == 0)
                {
                    draggedObject.transform.SetParent(transform);
                    draggedObject.transform.localPosition = Vector3.zero;
                    draggedScript.SetDraggable(true);
                    draggedSlotScript.SetIsEmpty(false);
                    isEmpty = false;
                    itemImage.sprite = draggedObject.GetComponent<Image>().sprite;
                    itemImage.enabled = true;
                }
            }
            else
            {
                // Dragging within backpack or chest
                draggedObject.transform.SetParent(transform);
                draggedObject.transform.localPosition = Vector3.zero;
                draggedScript.SetDraggable(true);
                Drag.draggedObject = null;
            }
        }




    }

    public void AddItemToSlot(string itemName, Sprite sprite, int amount)
    {
        itemImage.sprite = sprite;

        _itemCountText.text = _backpackamountText.text.ToString();
        
    }

}


