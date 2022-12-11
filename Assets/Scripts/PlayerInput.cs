using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        var horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        var isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP);

        playerMovement.Move(horizontalDirection, isJumpButtonPressed); 
    }
}
