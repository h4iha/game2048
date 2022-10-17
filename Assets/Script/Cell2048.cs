using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2048 : MonoBehaviour
{
    private int indexLeft;
    private int indexRight;
    private int indexTop;
    private int indexBottom;

    GameObject leftGameObject;
    GameObject rightGameObject;
    GameObject upGameObject;
    GameObject downGameObject;

    public int index;
    public Cell2048 Left;
    public Cell2048 Right;
    public Cell2048 Up;
    public Cell2048 Down;
    public GameObject gridGame;
    public Fill2048 fill;

    private void OnEnable()
    {
        GameController.Slide += OnSlide;
    }

    private void OnDisable()
    {
        GameController.Slide -= OnSlide;
    }
    private void OnSlide(string WhatKeyWasSent)
    {
        if (WhatKeyWasSent == "UpArrow")
        {
            //GameObject currentGO = gridGame.gameObject.transform.GetChild(index).gameObject;
            if (Up != null)
                return;
            Cell2048 currentCell = this;
            SlideUp(currentCell);
        }
        if (WhatKeyWasSent == "RightArrow")
        {
            //if (Right != null)
            //    return;
            //Cell2048 currentCell = this;
        }
        if (WhatKeyWasSent == "DownArrow")
        {
            //if (Down != null)
            //    return;
            //Cell2048 currentCell = this;
        }
        if (WhatKeyWasSent == "LeftArrow")
        {
            //if (Left != null)
            //    return;
            //Cell2048 currentCell = this;
        }

    }

    void SlideUp(Cell2048 currentCell)
    {
        if (currentCell.Down == null)
            return;
        if (currentCell.fill != null)
        {
            Cell2048 nextCell = currentCell.Down;
            while (nextCell.Down != null && nextCell.fill == null)
            {
                Debug.Log("Loop");
                nextCell = nextCell.Down;
            }
            if (nextCell.fill != null)
            {
                if (currentCell.fill.value == nextCell.fill.value)
                {
                    //nextCell.fill.Double();
                    nextCell.fill.transform.parent = currentCell.transform;
                    currentCell.fill = nextCell.fill;
                    nextCell.fill = null;
                }
                else if (currentCell.Down.fill != nextCell.fill)
                {
                    Debug.Log("!doubled");
                    nextCell.fill.transform.parent = currentCell.Down.transform;
                    currentCell.Down.fill = nextCell.fill;
                    nextCell.fill = null;
                }
            }
        }
        else
        {
            Cell2048 nextCell = currentCell.Down;
            while (nextCell.Down != null && nextCell.fill == null)
            {
                Debug.Log("here");
                nextCell = nextCell.Down;
            }
            if (nextCell.fill != null)
            {
                nextCell.fill.transform.parent = currentCell.transform;
                currentCell.fill = nextCell.fill;
                nextCell.fill = null;
                SlideUp(currentCell);
                Debug.Log("Slide to Empty");
            }
        }
        if (currentCell.Down == null)
            return;
        SlideUp(currentCell.Down);
    }
    void Start()
    {
        index = transform.GetSiblingIndex();
        gridGame = GameObject.FindWithTag("Board");
        FindLeft();
        FindRight();
        FindTop();
        FindBottom();
        
    }
    public void Update()
    {
        if (fill == this.GetComponentInChildren<Fill2048>())
            return;
        fill = this.GetComponentInChildren<Fill2048>();
    }
    void FindLeft()
    {
        if (index % ChangeNumOfRows.numberOfRows != 0)
        {
            indexLeft = index - 1;
            leftGameObject = gridGame.gameObject.transform.GetChild(indexLeft).gameObject;
            Left = leftGameObject.GetComponent<Cell2048>();
        }
    }
    void FindRight()
    {
        if (((index + 1) % ChangeNumOfRows.numberOfRows) != 0)
        {

            indexRight = index + 1;
            rightGameObject = gridGame.gameObject.transform.GetChild(indexRight).gameObject;
            Right = rightGameObject.GetComponent<Cell2048>();
        }
    }
    void FindTop()
    {
        if (index > ChangeNumOfRows.numberOfRows - 1)
        {
            indexTop = index - ChangeNumOfRows.numberOfRows;
            upGameObject = gridGame.gameObject.transform.GetChild(indexTop).gameObject;
            Up = upGameObject.GetComponent<Cell2048>();
        }
    }
    void FindBottom()
    {
        if (index < ((ChangeNumOfRows.numberOfRows - 1) * ChangeNumOfRows.numberOfRows))
        {
            indexBottom = index + ChangeNumOfRows.numberOfRows;
            downGameObject = gridGame.gameObject.transform.GetChild(indexBottom).gameObject;
            Down = downGameObject.GetComponent<Cell2048>();
        }
    }
}
