using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject fillPrefab;
    public static Action<string> actionKeycode;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SpawnFill();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            actionKeycode("UpArrow");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            actionKeycode("RightArrow");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            actionKeycode("LeftArrow");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            actionKeycode("DownArrow");
        }
    }


    void SpawnFill()
    {
        // Tao ra cac cell ngau nhien
        Transform[] allFills = this.transform.GetComponentsInChildren<Transform>();
        int posSpawn = UnityEngine.Random.Range(0, allFills.Length);
        if (allFills[posSpawn].childCount != 0)
        {
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
            GameObject tempCell = Instantiate(fillPrefab, allFills[posSpawn]);
            tempCell.name = allFills[posSpawn].name;
        }
        else
        {
            GameObject tempCell = Instantiate(fillPrefab, allFills[posSpawn]);
            tempCell.name = allFills[posSpawn].name;
        }
    }
}
