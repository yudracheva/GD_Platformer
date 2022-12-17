using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class MoneyGUI : MonoBehaviour
{
    [FormerlySerializedAs("_money")] [SerializeField] private PlayerMoney playerMoney;
    [SerializeField] private TMP_Text _text;

    // Update is called once per frame
    void Update()
    {
        _text.text = playerMoney.GetCurrentAmountOfMoney().ToString();
    }
}
