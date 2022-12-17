using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private PlayerAttack _playerAttack;

    public void Attack()
    {
        _playerAttack.Attack();
    }
}
