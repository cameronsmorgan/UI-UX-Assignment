using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShopTimer : MonoBehaviour

{
    public GameObject[] ShopSlots;
    private bool _gameHasStarted = false;
    public TextMeshProUGUI Timer;

    private Coroutine _spawnCoroutine;

    // Start is called before the first frame update
    void Start()
    {

        foreach (GameObject slot in ShopSlots)
        {
            slot.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameHasStarted)
        {

            if (Input.GetMouseButtonDown(0))
            {
                _gameHasStarted = true;


                _spawnCoroutine = StartCoroutine(SpawnPortals());
            }
        }
    }

    IEnumerator SpawnPortals()
    {
        while (true)
        {

            yield return new WaitForSeconds(5f);


            int randomIndex = Random.Range(0, ShopSlots.Length);
            ShopSlots[randomIndex].SetActive(true);


        }
    }
}



