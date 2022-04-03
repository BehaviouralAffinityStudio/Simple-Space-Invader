using UnityEngine;
using UnityEngine.SceneManagement; // ReloadScene
using System.Collections; // IEnumerator
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public bool isGameOver = false;
    private bool waitForInput = false;
    private Animator pAnim;
    [SerializeField] private Text gameOverScreen;
    [SerializeField] private Text pressR;
    private InvaderManager invManager;


    void Awake()
    {
        // Get Component
        pAnim = GameObject.Find("Player").GetComponent<Animator>();
        invManager = GameObject.Find("InvaderManager").GetComponent<InvaderManager>();
    }

    void FixedUpdate()
    {
        if (isGameOver)
        {
            isGameOver = !isGameOver; // Debugger
            StartCoroutine("IsGameOver");
        }

        if(waitForInput)
        {
            if (Input.GetKeyDown(KeyCode.R))
               SceneManager.LoadScene("Level01");
        }
    }

    private IEnumerator IsGameOver()
    {
        // Wait until length of pDeath animation - 0.5 second to start GameOver sequence
        yield return new WaitForSeconds(pAnim.GetCurrentAnimatorStateInfo(0).length - 0.5f);

        pAnim.enabled = false; // Stops everything -> See OnPlayerDeath.cs under StateMachine folder

        // Destroy all invaders on screen
        // Restart cue visibility sake
        foreach (var invader in invManager.invaders)
        {
            if (invader == null)
                continue; // Debugger

            Destroy(invader);
        }

        // Instatiate visual cue
        gameOverScreen.enabled = true;
        do // Zooming effect test! Fancy!
        {
            gameOverScreen.fontSize++;
            yield return new WaitForSeconds(0f);
        } while (gameOverScreen.fontSize < 70);

        // HIGHSCORE SHOULD BE SAVED HERE
        PlayerPrefs.SetInt("Score", GameObject.Find("ScoreManager").GetComponent<ScoreManager>().highScore);

        // Allows Reload input
        waitForInput = !waitForInput;

        yield return new WaitForSeconds(1f);

        // Enable reload possibility cue
        pressR.enabled = true;
        do // Zooming effect test! Fancy!
        {
            pressR.fontSize++;
        } while (pressR.fontSize < 30);
    }
}
