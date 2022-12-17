using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")] 
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded = false;
    [SerializeField] private float _speed;

    [Header("Settings")]
    [SerializeField] private Transform _groundColliderTransform;
    [SerializeField] private float _jumpOffset;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private AnimationCurve _curve;

    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Boolean _isJumping = false;
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        var ovverlapCircleTransform = _groundColliderTransform.position;
        _isGrounded = Physics2D.OverlapCircle(ovverlapCircleTransform, _jumpOffset, _groundMask);
    }

    public void Move(float horizontalDirection, bool isJumpButtonPressed)
    {
        if (!_health.IsAlive) 
            return;

        if (_isGrounded && _isJumping)
        {
            _isJumping = false;
        }

        if (isJumpButtonPressed)
            Jump();

        if (Math.Abs(horizontalDirection) > 0.01f)
            HorizontalMovement(horizontalDirection);
        else
            _animator.SetBool("isRunning", false);
    }

    private void HorizontalMovement(float horizontalDirection)
    {
        _rb.velocity = new Vector2(_curve.Evaluate(horizontalDirection), _rb.velocity.y);
        _animator.SetBool("isRunning", true);
        _spriteRenderer.flipX = horizontalDirection < 0;
    }

    private void Jump()
    {
        if (_isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            _animator.SetTrigger("isJumping");
            _isJumping = true;
        }
    }
}