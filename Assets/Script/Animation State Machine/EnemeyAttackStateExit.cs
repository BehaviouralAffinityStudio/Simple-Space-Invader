using UnityEngine;

public class EnemeyAttackStateExit : StateMachineBehaviour
{
    // Transition requirements for smooth exit from attacking state to other (movement for Space Invader) state
    //      conditions of transiton : null
    //      has exit time           : true
    //      exit time               : 0 seconds
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false);
    }
}
