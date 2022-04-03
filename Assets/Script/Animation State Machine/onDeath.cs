using UnityEngine;

public class onDeath : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.tag == "Enemy")
        {
            animator.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.gameObject.tag == "Enemy")
        {
            GameObject.Find("InvaderManager").GetComponent<AttackManager>().timerMax *= 0.99f;
            GameObject.Find("InvaderManager").GetComponent<MovementManager>().moveSpeed *= 1.055f;
            GameObject.Find("InvaderManager").GetComponent<MovementManager>().invadersLeft--;
        }

        Destroy(animator.gameObject, 0f);
    }
}
