using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    private Animator animator; 

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) 
        {
            animator.SetBool("isWalkingFront", true);
        }
        else
        {
            animator.SetBool("isWalkingFront", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalkingBack", true);
        }
        else
        {
            animator.SetBool("isWalkingBack", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalkingLeft", true);
        }
        else
        {
            animator.SetBool("isWalkingLeft", false);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalkingRight", true);
        }
        else
        {
            animator.SetBool("isWalkingRight", false);
        }
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
}
