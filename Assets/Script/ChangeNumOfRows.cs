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
        numberOfRows = 4;
        displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();
    }
    public void PlusNumOfRows()
    {
        numberOfRows++;
        if (numberOfRows > 8 || numberOfRows == null)
        {
            numberOfRows = 8;
            displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();
        }
        displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();
    }
    public void MinusNumOfRows()
    {
        numberOfRows--;
        if (numberOfRows < 4 || numberOfRows == null)
        {
            numberOfRows = 4;
            displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();
        }
        displayNxN.text = numberOfRows.ToString() + "x" + numberOfRows.ToString();
        
    }
}
