using UnityEngine;

public class ScoreUpdateTrigger : MonoBehaviour
{
    private ScoreManager scoreManager;

    void Awake()
    {
       scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
            scoreManager.scoreTrigger = true;
    }
}

