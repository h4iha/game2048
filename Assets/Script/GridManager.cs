using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public GridLayoutGroup gridGame;
    public GameObject cellGO;

    void Start()
    {
        calculateSpacingAndCellSizeGridLG(4);
        createBoard(4);
    }

    void calculateSpacingAndCellSizeGridLG(int numOfRows)
    {
        float spacing = 1024 / (float)(21 * numOfRows + 1);
        gridGame.cellSize = new Vector2(20*spacing, 20*spacing);
        gridGame.spacing = new Vector2(spacing, spacing);
    }


    void createBoard(int numOfRows)
    {
        for (int i = 0; i < gridGame.transform.childCount; i++)
            Destroy(gridGame.transform.GetChild(i).gameObject);
        for (int i = 0; i < numOfRows; i++)
        {
            for (int j = 0; j < numOfRows; j++)
            {
                GameObject newCellGO = Instantiate(cellGO, transform);
                newCellGO.name = i.ToString() + ":" + j.ToString();
            }
        }
    }

    public void newGame()
    {
        calculateSpacingAndCellSizeGridLG(ChangeNumOfRows.numberOfRows);
        createBoard(ChangeNumOfRows.numberOfRows);
        //random number apear
    }
}
