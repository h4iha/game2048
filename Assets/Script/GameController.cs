using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject cellPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SpawnCell();
        }
    }


    void SpawnCell()
    {
        // Tao ra cac cell ngau nhien
        Transform[] allCells = this.transform.GetComponentsInChildren<Transform>();
        int posSpawn = Random.Range(0, allCells.Length);
        if (allCells[posSpawn].childCount != 0)
        {
            SpawnCell();
            return;
        }

        int chance = Random.Range(0, 100);
        if (chance < 20)
        {
            return;
        }
        else if(chance < 80)
        {
            GameObject tempCell = Instantiate(cellPrefab, allCells[posSpawn]);
            tempCell.name = allCells[posSpawn].name;
        }
        else
        {
            GameObject tempCell = Instantiate(cellPrefab, allCells[posSpawn]);
            tempCell.name = allCells[posSpawn].name;
        }
    }
}
