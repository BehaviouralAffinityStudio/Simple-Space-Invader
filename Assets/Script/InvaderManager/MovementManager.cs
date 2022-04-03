using UnityEngine;
// DEBUG TO BE DONE : L.57

// NOTE
//   - timerMax modifier location : Script / StateMachine / OnDeath

public class MovementManager : MonoBehaviour
{
    // Player position reference for GameOver
    private Transform pTransform;

    // Invaders variable Section
                     private InvaderManager invaderManager;
                     private float sprSize = 0.64f;
                     public  short invadersLeft = 50;
                     public  float moveSpeed = 0.15f;
    [SerializeField] private float clampXaxisMin = -3.5f;
    [SerializeField] private float clampXaxisMax = 3.5f;

    void Awake()
    {
        // Get Components
        pTransform = GameObject.Find("Player").GetComponent<Transform>();
        invaderManager = gameObject.GetComponent<InvaderManager>();
    }

    void FixedUpdate()
    {
        Movement();

        if (invadersLeft == 1)
            moveSpeed = 4f;
    }

    private void Movement()
    {
        // Movement
        foreach (var invader in invaderManager.invaders)
        {
            if (invader.gameObject == null)
                continue;

            invader.transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);

            // On Clamping : Drop Control
            if (invader.transform.position.x >= clampXaxisMax || invader.transform.position.x <= clampXaxisMin)
            {
                // Clamp
                invader.transform.position = new Vector3(
                                                            Mathf.Clamp(invader.transform.position.x, clampXaxisMin, clampXaxisMax), // Clamp X
                                                            invader.transform.position.y, // NA  clamp on Y
                                                            invader.transform.position.z // NA clamp on Z
                                                        );

                // Drop down by one sprSize
                foreach (var iinvader in invaderManager.invaders)
                {
                    if (iinvader.gameObject == null)
                        continue;
                    // DEBUG TO BE DONE:
                    //      - Clip on wall and move indefinitely downward when moving at a certain speed and beyond
                    iinvader.transform.position = new Vector3(iinvader.transform.position.x, iinvader.transform.position.y - sprSize, iinvader.transform.position.z);

                    // Game over sequence on player Y axis contact
                    if (iinvader.transform.position.y <= pTransform.position.y + sprSize)
                    {
                        GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("isDead", true);
                        GameObject.FindWithTag("GameManager").GetComponent<GameOver>().isGameOver = true;
                    }
                }
                moveSpeed *= -1;
            }
        }
    }
}
