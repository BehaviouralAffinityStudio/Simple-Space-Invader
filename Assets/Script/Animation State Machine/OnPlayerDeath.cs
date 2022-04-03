using UnityEngine;

public class OnPlayerDeath : StateMachineBehaviour
{    
    // Enemies Reference Section
    private InvaderManager invManager;

    // Player Reference Section
    private Transform pSpawn;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Get Components
        invManager = GameObject.Find("InvaderManager").GetComponent<InvaderManager>();
            pSpawn = GameObject.Find("pSpwnPos").GetComponent<Transform>();
                     GameObject.Find("LifeManager").GetComponent<LifeManager>().pDeath = true; // Remove a life -> LifeManager.cs

        // Toggle InvaderManager's components
        EnemyStateToggle(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isDead", false);                        // Reset Death State
        animator.gameObject.transform.position = pSpawn.position; // Move Player to PLayer Spawning Position
        
        // Toggle InvaderManager's components
        EnemyStateToggle(true);
    }

    private void EnemyStateToggle(bool toState)
    {
        GameObject.Find("InvaderManager").GetComponent<MovementManager>().enabled = toState; // Stop Invaders mouvement
        GameObject.Find("InvaderManager").GetComponent<AttackManager>().enabled = toState;   // Stop Invaders attack

        // Stop Invaders animator
        foreach (var invaders in invManager.invaders)
        {
            if (invaders == null) // Bug prevention
                continue;

            invaders.GetComponent<Animator>().enabled = toState;
        }
    }
}
