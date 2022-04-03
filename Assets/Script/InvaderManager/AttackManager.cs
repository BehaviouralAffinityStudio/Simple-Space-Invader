using UnityEngine;

// NOTE
//   - timerMax modifier location : Script / StateMachine / OnDeath

public class AttackManager : MonoBehaviour
{
    // Components section
    private InvaderManager invaderManager;
    [SerializeField] private GameObject invaderLaser;

    // Timer Variable Section
    public float timerMax = 0.5f; // On every enemy death (animator) : Multiplied by 0.98
    private float timerCurr = 0f;

    void Awake()
    {
        invaderManager = gameObject.GetComponent<InvaderManager>();
    }

    void FixedUpdate()
    {
        // Update Timer
        timerCurr += Time.deltaTime;

        // Pew Pew
        if (timerCurr >= timerMax)
        {
            timerCurr = 0f; // Reset timer
            Fire();
        }
    }

    private void Fire()
    {
        int random;

        do
        {
            // Create a random integer based on last row count
            // TEMP DEBUG FOR NULL GAMEOBJECT AT RANDOM INDEX FOR BOT ROW
            // DEBUG TO BE DONE:
            //      - Check debug in InvaderManager.cs
            random = Random.Range(0, invaderManager.botRow.Count - 1);

        } while (invaderManager.botRow[random] == null);

        // Set the Animator of gameObject for Attack State
        invaderManager.botRow[random].GetComponent<Animator>().SetBool("isAttacking", true);

        // Instantiate Laser 
        Instantiate(invaderLaser, invaderManager.botRow[random].transform.position, Quaternion.identity);
    }
}
