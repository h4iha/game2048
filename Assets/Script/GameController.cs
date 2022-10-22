using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public static int ticker;
    [SerializeField] GameObject fillPrefab;
    [SerializeField] GameObject gridGame;
    public static Action<string> Slide;
    public int myScore;
    [SerializeField] Text scoreDisplay;
    int isGameOver;
    [SerializeField] GameObject gameOverPanel;
    public Color[] fillColors;
    [SerializeField] int winningScore;
    [SerializeField] GameObject winningPanel;
    bool hasWon;
    private void OnEnable()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        StartSpawnFill();
        StartSpawnFill();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SpawnFill();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ticker = 0;
            isGameOver = 0;
            Slide("UpArrow");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ticker = 0;
            isGameOver = 0;
            Slide("RightArrow");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ticker = 0;
            isGameOver = 0;
            Slide("LeftArrow");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ticker = 0;
            isGameOver = 0;
            Slide("DownArrow");
        }

    }

    void StartSpawnFill()
    {
        int posSpawn = UnityEngine.Random.Range(0, gridGame.transform.childCount);
        if (gridGame.gameObject.transform.GetChild(posSpawn).childCount != 0)
        {
            // check fill da co hay chua
            SpawnFill();
            return;
        }
        //them ngau nhien fill = 2
        GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
        Fill2048 tempFillComp = tempFill.GetComponent<Fill2048>();
        gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComp;
        tempFillComp.FillValueUpdate(2);
    }
    public void SpawnFill()
    {
        //check xem fill da day hay chua
        bool isFull = true;
        for (int i = 0; i < gridGame.transform.childCount; i++)
        {
            if (gridGame.gameObject.transform.GetChild(i).GetComponent<Cell2048>().fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
        {
            return;
        }
        //chay random vi tri cua children trong grid
        int posSpawn = UnityEngine.Random.Range(0, gridGame.transform.childCount);
        if (gridGame.gameObject.transform.GetChild(posSpawn).childCount != 0)
        {
            //check fill da co hay chua
            SpawnFill();
            return;
        }
        //random co hoi xuat hien 2, 4 voi ti le:  60% xuat hien 2, 20% xuat hien 4 va khong xuat hien
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance < 20)
        {
            //khong xuat hien
            return;
        }
        else if(chance < 80)
        {
            //2
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(2);
        }
        else
        {
            //4
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(4);
        }
    }
    public void LeftSpawnFill()
    {
        //check xem fill da day hay chua
        bool isFull = true;
        for (int i = 0; i < gridGame.transform.childCount; i++)
        {
            if (gridGame.gameObject.transform.GetChild(i).GetComponent<Cell2048>().fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
        {
            return;
        }
        //chay random vi tri cua children trong grid
        int random = UnityEngine.Random.Range(0, ChangeNumOfRows.numberOfRows - 1);
        int posSpawn = random * ChangeNumOfRows.numberOfRows;
        if (gridGame.gameObject.transform.GetChild(posSpawn).childCount != 0)
        {
            //check fill da co hay chua
            SpawnFill();
            return;
        }
        //random co hoi xuat hien 2, 4 voi ti le:  60% xuat hien 2, 20% xuat hien 4 va khong xuat hien
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance < 20)
        {
            //khong xuat hien
            return;
        }
        else if (chance < 80)
        {
            //2
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(2);
        }
        else
        {
            //4
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(4);
        }
    }
    public void RightSpawnFill()
    {
        //check xem fill da day hay chua
        bool isFull = true;
        for (int i = 0; i < gridGame.transform.childCount; i++)
        {
            if (gridGame.gameObject.transform.GetChild(i).GetComponent<Cell2048>().fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
        {
            return;
        }
        //chay random vi tri cua children trong grid
        int random = UnityEngine.Random.Range(1, ChangeNumOfRows.numberOfRows);
        int posSpawn = random * ChangeNumOfRows.numberOfRows - 1;
        if (gridGame.gameObject.transform.GetChild(posSpawn * ChangeNumOfRows.numberOfRows - 1).childCount != 0)
        {
            //check fill da co hay chua
            SpawnFill();
            return;
        }
        //random co hoi xuat hien 2, 4 voi ti le:  60% xuat hien 2, 20% xuat hien 4 va khong xuat hien
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance < 20)
        {
            //khong xuat hien
            return;
        }
        else if (chance < 80)
        {
            //2
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(2);
        }
        else
        {
            //4
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(4);
        }
    }
    public void UpSpawnFill()
    {
        //check xem fill da day hay chua
        bool isFull = true;
        for (int i = 0; i < gridGame.transform.childCount; i++)
        {
            if (gridGame.gameObject.transform.GetChild(i).GetComponent<Cell2048>().fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
        {
            return;
        }
        //chay random vi tri cua children trong grid
        int posSpawn = UnityEngine.Random.Range(0, ChangeNumOfRows.numberOfRows - 1);
        if (gridGame.gameObject.transform.GetChild(posSpawn).childCount != 0)
        {
            //check fill da co hay chua
            SpawnFill();
            return;
        }
        //random co hoi xuat hien 2, 4 voi ti le:  60% xuat hien 2, 20% xuat hien 4 va khong xuat hien
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance < 20)
        {
            //khong xuat hien
            return;
        }
        else if (chance < 80)
        {
            //2
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(2);
        }
        else
        {
            //4
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(4);
        }
    }
    public void DownSpawnFill()
    {
        //check xem fill da day hay chua
        bool isFull = true;
        for (int i = 0; i < gridGame.transform.childCount; i++)
        {
            if (gridGame.gameObject.transform.GetChild(i).GetComponent<Cell2048>().fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
        {
            return;
        }
        //chay random vi tri cua children trong grid
        int posSpawn = UnityEngine.Random.Range(ChangeNumOfRows.numberOfRows*(ChangeNumOfRows.numberOfRows - 1), ChangeNumOfRows.numberOfRows*ChangeNumOfRows.numberOfRows -1);
        if (gridGame.gameObject.transform.GetChild(posSpawn).childCount != 0)
        {
            //check fill da co hay chua
            SpawnFill();
            return;
        }
        //random co hoi xuat hien 2, 4 voi ti le:  60% xuat hien 2, 20% xuat hien 4 va khong xuat hien
        int chance = UnityEngine.Random.Range(0, 100);
        if (chance < 20)
        {
            //khong xuat hien
            return;
        }
        else if (chance < 80)
        {
            //2
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(2);
        }
        else
        {
            //4
            GameObject tempFill = Instantiate(fillPrefab, gridGame.gameObject.transform.GetChild(posSpawn).transform);
            Fill2048 tempFillComponent = tempFill.GetComponent<Fill2048>();
            gridGame.gameObject.transform.GetChild(posSpawn).GetComponent<Cell2048>().fill = tempFillComponent;
            tempFillComponent.FillValueUpdate(4);
        }
    }
    public void ScoreUpdate(int scoreIn)
    {
        myScore += scoreIn;
        scoreDisplay.text = myScore.ToString();
    }
    public void GameOverCheck()
    {
        isGameOver++;
        if (isGameOver >= ChangeNumOfRows.numberOfRows*ChangeNumOfRows.numberOfRows)
        {
            gameOverPanel.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    //win with poin
    public void WinningCheck(int highestFill)
    {
        if (hasWon)
            return;
        if (highestFill == winningScore)
        {
            winningPanel.SetActive(true);
            hasWon = true;
        }
    }
    public void KeepPlaying()
    {
        winningPanel.SetActive(false);
    }

}
