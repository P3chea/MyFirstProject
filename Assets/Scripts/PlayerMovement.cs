using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private bool onGround = false;
    private Rigidbody2D _playerRigidbody;

    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius;
    [SerializeField] private Animator _anim;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCircle = groundCheck.position;
        onGround = Physics2D.OverlapCircle(overlapCircle, checkRadius, groundMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (Mathf.Abs(direction) != 0)
            Walk(direction);
        if (isJumpButtonPressed)
            Jump();
    }

    void Jump()
    {
        if (onGround)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, jumpForce);
            _anim.SetBool("Jumping", true);
        }
    }

    private void Walk(float direction)
    {
        _playerRigidbody.velocity = new Vector2(direction * speed, _playerRigidbody.velocity.y);
        _anim.SetFloat("Walk", Mathf.Abs(direction));
        Flip();
    }

    private void Flip()
    {
        if (Mathf.Abs(_playerRigidbody.velocity.x) > 0)
        {
            _spriteRenderer.flipX = (_playerRigidbody.velocity.x < 0);
        }
    }
    public void OnJumpAnimationEnd()
    {
        _anim.SetBool("Jumping", false);
    }
}