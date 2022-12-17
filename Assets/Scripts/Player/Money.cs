using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    private int _currentValueOfMoney = 0;

    public void Add(int amountOfMoney)
    {
        _currentValueOfMoney += amountOfMoney;
    }

    public int GetCurrentAmountOfMoney()
    {
        return _currentValueOfMoney;
    }
}
