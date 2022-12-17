using UnityEngine;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;

    public void Jump()
    {
        _playerMovement.Jump();
    }
}
