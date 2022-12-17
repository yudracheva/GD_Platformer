using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private int amountOfMoney = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponentInParent<PlayerMoney>() is {} playerMoney)
        {
            playerMoney.Add(amountOfMoney);
            this.gameObject.SetActive(false);
        }
    }
}
