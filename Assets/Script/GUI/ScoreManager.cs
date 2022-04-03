using UnityEngine;
using UnityEngine.UI; // TEXT

public class ScoreManager : MonoBehaviour
{
    // Score Variable Section
    private int score = 0;
    public int highScore = 0;
    private int point = 10;
    public bool scoreTrigger = false;

    // LiveUp Variable Section
    [SerializeField] private int liveUpScoreReq = 150;
    [SerializeField] private int liveUpScoreCurr;
    [SerializeField] private LifeManager lMngr;

    // Text GameObjects
    private Text txtScore;
    private Text txtHighScore;

    // Animator for player death state
    Animator animator;

    void Awake()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        highScore = PlayerPrefs.GetInt("Score");
                                                        // DEBUG START
                                                        // NOTE : scoreTrigger starts at 10 points otherwise
                                                        scoreTrigger = false;
                                                        // DEBUG END

        // Get Components
            txtScore = GameObject.Find("Grid/Canvas/SCORE/ScorePts").GetComponent<Text>();          // Score
        txtHighScore = GameObject.Find("Grid/Canvas/HIGH-SCORE/HighScorePts").GetComponent<Text>(); // HighScore
            animator = GameObject.Find("Player").GetComponent<Animator>();                          // Player Animator
               lMngr = GameObject.Find("LifeManager").GetComponent<LifeManager>();                  // Life Manager

        txtHighScore.text = highScore.ToString();
    }

    void FixedUpdate()
    {
        // ScoreManager
        if (scoreTrigger)
        {
            // Score
            score += point;
            liveUpScoreCurr += point;
            txtScore.text = score.ToString("0");

            // High Score
            if (score > highScore)
            {
                highScore = score;
                txtHighScore.text = score.ToString("0");
            }

            scoreTrigger = false;
        }

        // Live UP
        if (liveUpScoreCurr >= liveUpScoreReq)
        {
            liveUpScoreCurr = 0; // Reset
            lMngr.lives.Add(Instantiate(lMngr.sprLife, lMngr.transform.position + new Vector3(lMngr.lives.Count * lMngr.sprSize, 0f, 0f), Quaternion.identity)); // Instantiate
            lMngr.lives[lMngr.lives.Count - 1].transform.parent = lMngr.gameObject.transform; // is now child of LifeManager
        }    


        // IF PLAYER DEATH SAVE HIGHSCORE IN FILE HERE
        if (animator.GetBool("isDead"))
        {
            // WRITE SCORE TO FILE
        }
    }
}
