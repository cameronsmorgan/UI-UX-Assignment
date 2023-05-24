using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopFilterDropDown : MonoBehaviour

{
    public enum SortType
    {
        None,
        PriceLowToHigh,
        PriceHighToLow
    }

    public TMP_Dropdown filterDropdown;
    public List<ShopSpaceScript> shopItems = new List<ShopSpaceScript>();

    private void Start()
    {
        filterDropdown.onValueChanged.AddListener(OnFilterChanged);
    }

    private void OnFilterChanged(int index)
    {
        SortType sortType = (SortType)index;

        switch (sortType)
        {
            case SortType.PriceLowToHigh:
                SortItemsByPrice(true);
                break;
            case SortType.PriceHighToLow:
                SortItemsByPrice(false);
                break;
            default:
                // No sorting
                break;
        }
    }

    public void AddShopItem(ShopSpaceScript shopItem)
    {
        shopItems.Add(shopItem);
    }

    private void SortItemsByPrice(bool ascending)
    {
        // Sort the list based on item price
        shopItems.Sort((a, b) =>
        {
            if (ascending)
                return a.GetItemPrice().CompareTo(b.GetItemPrice());
            else
                return b.GetItemPrice().CompareTo(a.GetItemPrice());
        });

        // Reorder the shop items based on the sorted list
        for (int i = 0; i < shopItems.Count; i++)
        {
            shopItems[i].transform.SetSiblingIndex(i);
        }
    }
}

