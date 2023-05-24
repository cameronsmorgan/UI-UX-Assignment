using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackPackManager : MonoBehaviour
{

    public bool[] _filled;
    public GameObject[] _spaces;
    public GameObject[] _chestSlots;

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < _spaces.Length; i++)
        {
            if (_spaces[i].gameObject == item)
            {
                _filled[i] = false;
                _spaces[i] = null;
                break;

            }
        }
    }
}
