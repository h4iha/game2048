using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    [SerializeField] GameObject gridGame;
    public static Action<string> Slide;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SpawnFill();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Slide("UpArrow");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Slide("RightArrow");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Slide("LeftArrow");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide("DownArrow");
        }
    }


    void SpawnFill()
    {
        // Tao ra cac cell ngau nhien
        int posSpawn = UnityEngine.Random.Range(0, gridGame.transform.childCount);
        if (gridGame.gameObject.transform.GetChild(posSpawn).childCount != 0)
        {
            Debug.Log(gridGame.gameObject.transform.GetChild(posSpawn).name + " is already filled");
            SpawnFill();
            return;
        }
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance < 20)
        {
            return;
        }
        else if(chance < 80)
        {
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn));
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            tempFillComponent.FillValueUpdate(2);
        }
        else
        {
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn));
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            tempFillComponent.FillValueUpdate(4);
        }
    }
}
