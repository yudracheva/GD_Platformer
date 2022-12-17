using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        return;
        var horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        var isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed); 

        //var isAttackButtonPressed = Input.GetButtonDown(GlobalStringVars.ATTACK);
        //if (isAttackButtonPressed)
//            playerAttack.Attack();
    }
}
