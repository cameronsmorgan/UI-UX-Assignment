using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ShopSpaceScript : MonoBehaviour
{

    private Player _player;
    private BackPackManager _backPackManager3;

    public Image _item;
    public TextMeshProUGUI _itemName;
    public TextMeshProUGUI _itemPrice;
    public TextMeshProUGUI _itemAmount;

    public GameObject _itemToBuy;
    public int _ItemAmount;
    public TextMeshProUGUI _buyPriceText;


    public TextMeshProUGUI _backpackItemCountText;
    public TextMeshProUGUI _chestItemCountText;

    //public TextMeshProUGUI _timer;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _backPackManager3 = FindObjectOfType<BackPackManager>();

        _itemName.text = _itemToBuy.GetComponent<Spawn>().itemName;
        _item.sprite = _itemToBuy.GetComponent<Image>().sprite;
        _buyPriceText.text = _itemToBuy.GetComponent<Spawn>().itemPrice + "Dollars";

        // Add the following line to add the shop item to the shop filter dropdown
        ShopFilterDropDown shopFilterDropdown = FindObjectOfType<ShopFilterDropDown>();
        if (shopFilterDropdown != null)
        {
            shopFilterDropdown.AddShopItem(this);
        }


    }


    private void Update()
    {
        _itemAmount.text = "Amount:" + _ItemAmount.ToString();
    }

    public void Buy()
    {
        for(int i = 0; i < _backPackManager3._spaces.Length;i++)
        {
            if (_backPackManager3._filled[i] ==true && _backPackManager3._spaces[i].transform.GetComponent<SpaceScript>().amount < 100 && _player.Dollars >= _itemToBuy.GetComponentInChildren<Spawn>().itemPrice && _ItemAmount > 0)
            {
                if (_itemName.text == _backPackManager3._spaces[i].transform.GetComponentInChildren<Spawn>().itemName) 
                {
                    _ItemAmount -= 1;
                    _backPackManager3._spaces[i].GetComponent<SpaceScript>().amount += 1;
                    _player.Dollars -= _itemToBuy.GetComponentInChildren<Spawn>().itemPrice;

                    break;
                }

            }
            else if (_backPackManager3._filled[i] ==false && _player.Dollars >= _itemToBuy.GetComponentInChildren<Spawn>().itemPrice && _ItemAmount > 0)
            {
                _ItemAmount-= 1;
                _player.Dollars -= _itemToBuy.GetComponentInChildren<Spawn>().itemPrice;
                _backPackManager3._spaces[i].GetComponent<SpaceScript>().ItemName = _itemName.text;
                _backPackManager3._filled[i] = true;
                Instantiate(_itemToBuy, _backPackManager3._spaces[i].transform, false);
                _backPackManager3._spaces[i].GetComponent<SpaceScript>().amount += 1;


                break;
            }

          //  _backpackItemCountText.text = _backPackManager3._spaces[i].GetComponent<SpaceScript>().amount.ToString();

        }

        
    }

    public void Sell()
    {
        for(int i = 0; i < _backPackManager3._spaces.Length; i++)
        {
            if (_backPackManager3._spaces[i].transform.GetComponent<SpaceScript>().amount !=0)
            {
                if(_itemName.text == _backPackManager3._spaces[i].transform.GetComponentInChildren<Spawn>().itemName)
                {
                    _ItemAmount += 1;
                    _backPackManager3._spaces[i].GetComponent<SpaceScript>().amount-= 1;
                    _player.Dollars += _itemToBuy.GetComponentInChildren<Spawn>().itemPrice / 2;

                    if (_backPackManager3._spaces[i].GetComponent<SpaceScript>().amount ==0)
                    {
                        _backPackManager3._spaces[i].GetComponent<SpaceScript>().ItemName = string.Empty;
                        GameObject.Destroy(_backPackManager3._spaces[i].transform.GetComponentInChildren<Spawn>().gameObject);
                        _backPackManager3._filled[i] = false;
                    }

                }
            }


        }
    }

    public float GetItemPrice()
    {
        return _itemToBuy.GetComponent<Spawn>().itemPrice;
    }


}
