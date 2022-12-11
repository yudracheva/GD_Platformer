using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private LayerMask _groundMask;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var ovverlapCircleTransform = _groundColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(ovverlapCircleTransform, _jumpOffset, _groundMask);
    }

    public void Move(float horizontalDirection, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
            Jump();
    }

    private void Jump()
    {
        if (_isGrounded)
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }
}
