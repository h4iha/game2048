using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Tile2048 : MonoBehaviour
{
    public int index;
    public int indexLeft;
    public int indexRight;
    public int indexTop;
    public int indexBottom;
    public GameObject Left;
    public GameObject Right;
    public GameObject Top;
    public GameObject Bottom;
    public GameObject gridGame;

    void Start()
    {
        index = transform.GetSiblingIndex();
        gridGame = GameObject.FindWithTag("Board");
        FindLeft();
        FindRight();
        FindTop();
        FindBottom();
    }

    void FindLeft()
    {
        if (index % ChangeNumOfRows.numberOfRows != 0)
        {
            indexLeft = index - 1;
            Left = gridGame.gameObject.transform.GetChild(indexLeft).gameObject;
        }
    }
    void FindRight()
    {
        if ((index + 1) % ChangeNumOfRows.numberOfRows != 0)
        {

            indexRight = index + 1;
            Right = gridGame.gameObject.transform.GetChild(indexRight).gameObject;
        }
    }

    void FindTop()
    {
        if (index >= ChangeNumOfRows.numberOfRows)
        {
            indexTop = index - ChangeNumOfRows.numberOfRows;
            Top = gridGame.gameObject.transform.GetChild(indexTop).gameObject;
        }
        
    }
    void FindBottom()
    {
        if (index < (ChangeNumOfRows.numberOfRows - 1) * ChangeNumOfRows.numberOfRows)
        {
            indexBottom = index + ChangeNumOfRows.numberOfRows;
            Bottom = gridGame.gameObject.transform.GetChild(indexBottom).gameObject;
        }
    }

}
