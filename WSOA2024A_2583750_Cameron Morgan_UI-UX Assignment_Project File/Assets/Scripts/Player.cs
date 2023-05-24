using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public int Dollars;
    public TextMeshProUGUI _dollarAmountText;

    void Update()
    {
        _dollarAmountText.text = Dollars + "Dollars";

        
    }

}
