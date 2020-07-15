using UnityEngine;

public partial class Player : MonoBehaviour
{
    public Bag bag;

    private readonly float runSpeed = 6;
    private readonly float jumpForce = 12;

    private MoveState moveState = MoveState.Idle;
    private DirectionState directionState = DirectionState.Right;
    private Transform transformPlayer;
    private Rigidbody2D rigidbodyPlayer;
    private AnimationPlayer animationPlayer;

    public void MoveRight()
    {
        if (moveState != MoveState.Jump)
        {
            moveState = MoveState.Run;
            if (directionState == DirectionState.Left)
            {
                transformPlayer.localScale = new Vector3(-transformPlayer.localScale.x,
                                                         transformPlayer.localScale.y,
                                                         transformPlayer.localScale.z);
                directionState = DirectionState.Right;
            }
            animationPlayer.PlayRun();
        }
    }

    public void MoveLeft()
    {
        if (moveState != MoveState.Jump)
        {
            moveState = MoveState.Run;
            if (directionState == DirectionState.Right)
            {
                transformPlayer.localScale = new Vector3(-transformPlayer.localScale.x,
                                                         transformPlayer.localScale.y,
                                                         transformPlayer.localScale.z);
                directionState = DirectionState.Left;
            }
            animationPlayer.PlayRun();
        }
    }

    public void Jump()
    {
        if (moveState != MoveState.Jump)
        {
            rigidbodyPlayer.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            moveState = MoveState.Jump;
            animationPlayer.PlayJump();
        }
    }

    private void Idle()
    {
        moveState = MoveState.Idle;
        animationPlayer.PlayIdle();
    }

    private void Start()
    {
        animationPlayer = GetComponent<AnimationPlayer>();
        transformPlayer = GetComponent<Transform>();
        rigidbodyPlayer = GetComponent<Rigidbody2D>();
        bag = GetComponent<Bag>();
        directionState = transformPlayer.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }

    private void Update()
    {
        if (moveState == MoveState.Jump)
        {
            if (rigidbodyPlayer.velocity == Vector2.zero)
            {
                Idle();
            }
        }
    }

    private void FixedUpdate()
    {
        if (moveState == MoveState.Run)
        {
            float translation = Input.GetAxis("Horizontal") * runSpeed;
            rigidbodyPlayer.velocity = new Vector3(translation, rigidbodyPlayer.velocity.y);

            animationPlayer.RunTime -= Time.deltaTime;
            if (animationPlayer.RunTime <= 0)
            {
                Idle();
            }
        }
        //if (moveState == MoveState.Run)
        //{
        //    rigidbodyPlayer.velocity = (directionState
        //        == DirectionState.Right ? Vector2.right : -Vector2.right) * runSpeed;
        //    runTime -= Time.deltaTime;
        //    if (runTime <= 0)
        //    {
        //        Idle();
        //    }
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            bag.AddCoin();
            Destroy(collision.gameObject);
        }
    }
}