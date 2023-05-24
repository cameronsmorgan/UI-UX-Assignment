using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using UnityEditor;
//using System.Diagnostics;

public class ChestScript : MonoBehaviour, IDropHandler
    //SetParent functi
{
    private bool isEmpty = true;
    private Image itemImage;

    public bool IsEmpty()
    {
        return isEmpty && transform.childCount == 0;
    }

    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedObject = Drag.draggedObject;

        if (draggedObject != null)
        {

            // Check if the dropped object is coming from the backpack
            BackPackManager backPackManager = draggedObject.GetComponentInParent<BackPackManager>();
            if (backPackManager != null)
            {

                // Check if the chest slot is available
                Slotscript chestSlot = GetComponentInChildren<Slotscript>();
                
                if (chestSlot != null && chestSlot.IsEmpty())
                    
                {
                    // Store the object in the chest slot
                    draggedObject.transform.SetParent(transform, false);
                    draggedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    draggedObject.GetComponent<Drag>().SetDraggable(false); // Disable dragging
                    Drag.draggedObject = null;
                    
                    isEmpty = false;

                    // Update the item image in the slot
                    Image draggedImage = draggedObject.GetComponent<Image>();
                    itemImage.sprite = draggedImage.sprite;
                    itemImage.color = draggedImage.color;
                    itemImage.enabled = true;

                    // Update the backpack manager to remove the item from the backpack
                    backPackManager.RemoveItem(draggedObject);
                }
            }
        }
    }

   
    }














