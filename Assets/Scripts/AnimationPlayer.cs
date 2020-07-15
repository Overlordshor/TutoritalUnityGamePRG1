using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public float RunTime = 0;

    private Animator animator;
    private readonly float runCooldown = 0.25f;

    public void PlayRun()
    {
        RunTime = runCooldown;
        animator.Play("Run");
    }

    public void PlayJump()
    {
        animator.Play("Jump");
    }

    public void PlayIdle()
    {
        animator.Play("Idle");
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
}