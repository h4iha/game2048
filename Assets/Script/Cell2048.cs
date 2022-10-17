using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell2048 : MonoBehaviour
{
    [SerializeField] int index;
    private int indexLeft;
    private int indexRight;
    private int indexTop;
    private int indexBottom;

    GameObject leftGameObject;
    GameObject rightGameObject;
    GameObject topGameObject;
    GameObject bottomGameObject;

    [SerializeField] Cell2048 Left;
    [SerializeField] Cell2048 Right;
    [SerializeField] Cell2048 Top;
    [SerializeField] Cell2048 Bottom;
    [SerializeField] GameObject gridGame;

    void Start()
    {
        index = transform.GetSiblingIndex();
        gridGame = GameObject.FindWithTag("Board");
        FindLeft();
        FindRight();
        FindTop();
        FindBottom();
    }
    private void OnEnable()
    {
        GameController.actionKeycode += OnActionKeycode;
    }

    private void OnDisable()
    {
        GameController.actionKeycode -= OnActionKeycode;
    }
    private void OnActionKeycode(string WhatKeyWasSent)
    {
        Debug.Log(WhatKeyWasSent);
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
            topGameObject = gridGame.gameObject.transform.GetChild(indexTop).gameObject;
            Top = topGameObject.GetComponent<Cell2048>();
        }


    }
    void FindBottom()
    {
        if (index < ((ChangeNumOfRows.numberOfRows - 1) * ChangeNumOfRows.numberOfRows))
        {
            indexBottom = index + ChangeNumOfRows.numberOfRows;
            bottomGameObject = gridGame.gameObject.transform.GetChild(indexBottom).gameObject;
            Bottom = bottomGameObject.GetComponent<Cell2048>();
        }
    }

}
