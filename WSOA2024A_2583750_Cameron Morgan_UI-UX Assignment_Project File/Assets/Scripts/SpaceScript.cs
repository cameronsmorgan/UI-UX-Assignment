using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpaceScript : MonoBehaviour
{
    private BackPackManager _bpManager;
    public int i;
    public TextMeshProUGUI _textAmount;
    public int amount;
    public  string ItemName;

    void Start()
    {
        _bpManager= FindObjectOfType<BackPackManager>();
    }

    // Update is called once per frame
    
    void Update()
    {
        _textAmount.text = amount.ToString();

        if (amount > 2)
        {
            if (transform.childCount > 0)
            {
                Transform child = transform.GetChild(0);
                TextMeshProUGUI textMesh = child.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                    textMesh.enabled = true;
            }
        }
        else
        {
            if (transform.childCount > 1)
            {
                Transform child = transform.GetChild(1);
                TextMeshProUGUI textMesh = child.GetComponent<TextMeshProUGUI>();
                if (textMesh != null)
                    textMesh.enabled = false;
            }
        }

        if (transform.childCount == 5)
        {
            _bpManager._filled[i] = false;
        }
    }

}

