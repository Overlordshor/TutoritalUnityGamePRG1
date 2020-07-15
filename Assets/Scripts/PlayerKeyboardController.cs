using UnityEngine;

public class PlayerKeyboardController : MonoBehaviour
{
    public Player Player;
    public Transform GroundCheck;
    public LayerMask LayerGround;

    private bool isGrounded = false;
    private readonly float groundRadius = 0.3f;

    private void Start()
    {
        Player = Player == null ? GetComponent<Player>() : Player;
    }

    private void Update()
    {
        if (Player != null)
        {
            isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, LayerGround);
            if (!isGrounded)
            {
                return;
            }
            if (Input.GetKey(KeyCode.D))
            {
                Player.MoveRight();
            }
            if (Input.GetKey(KeyCode.A))
            {
                Player.MoveLeft();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.Jump();
            }
        }
    }
}