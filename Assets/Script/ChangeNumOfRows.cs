using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNumOfRows : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static int numberOfRows;
    public Text displayNxN;

    void Start()
    {
        if (numberOfRows < 4)
            numberOfRows = 4;
        if (numberOfRows > 8)
            numberOfRows = 8;
        displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();
    }
    public void PlusNumOfRows()
    {
        if (numberOfRows <= 7)
            numberOfRows++;
        else
            numberOfRows = 8;
        displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();


    }
    public void MinusNumOfRows()
    {
        if (numberOfRows >=5)
            numberOfRows--;
        else
            numberOfRows = 4;
        displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();

    }
}
