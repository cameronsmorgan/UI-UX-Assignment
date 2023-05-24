
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Spawn : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public string itemName;
    public int itemPrice;
    private Image image;
    private  Slotscript _slotscript;


    
   private Transform _originalParent;
    private Vector3 _originalPosition;
   
    private void Awake()
    {
        image = GetComponent<Image>();
      _slotscript= GetComponent<Slotscript>();
        
    }

    public void OnBeginDrag(PointerEventData PointerEventData)
    {
        _originalParent = transform.parent;
        _originalPosition = transform.localPosition;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData pointerEventData)
    {
        Debug.Log($"{gameObject.name} -- OnEndDrag");

        var chestGraphicRaycaster = SceneResources.Instance.ChestCanvasRaycaster;
        List<RaycastResult> hits = new List<RaycastResult>();
        chestGraphicRaycaster.Raycast(pointerEventData, hits);

        

        foreach (var hit in hits) 
        {
            var _name = hit.gameObject.name;
            Debug.Log($"Chest Canvas: { _name}");

            var gameObject = hit.gameObject;
            var slotScript = gameObject.GetComponent<Slotscript>();

            if ( slotScript != null )
            {
               slotScript.AddItemToSlot(itemName, image.sprite, itemPrice);
                transform.SetParent(gameObject.transform);
                transform.localPosition = Vector3.zero;
                
                _slotscript.IsEmpty();
                return;
                
                

                
                
            }
        }
    }
    

    public void ResetPosition()
    {
        // Reset the position of the object to its original slot in the backpack
        transform.SetParent(_originalParent);
        transform.localPosition = _originalPosition;
    }
}



//add bollean to drag script.- checks when item is being dragged
//fetch object that needs to be placed on slot. check if boolean is true. if true that will be dragged hecne be placed.
//fetch data
