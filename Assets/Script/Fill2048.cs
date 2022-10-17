using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fill2048 : MonoBehaviour
{
    int value;
    [SerializeField] Text valueDisplay;

    public void FillValueUpdate(int valueInput)
    {
        value = valueInput;
        valueDisplay.text = value.ToString();
    }
}
