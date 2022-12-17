using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyGUI : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private TMP_Text _text;

    // Update is called once per frame
    void Update()
    {
        _text.text = _money.GetCurrentAmountOfMoney().ToString();
    }
}
