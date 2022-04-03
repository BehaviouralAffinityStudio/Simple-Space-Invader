using UnityEngine;
using System.Collections.Generic; // List

public class LifeManager : MonoBehaviour
{
    // isDead check Section
    [SerializeField] private Animator playerAnimator;
    public bool pDeath = false;

    // Lives Section
    [SerializeField] private short lifeQtyAtStart = 3;
    public List<GameObject> lives;
    public GameObject sprLife;
    public float sprSize = 0.64f;

    private void Awake()
    {
        for (int i = 0; i < lifeQtyAtStart; ++i)
        {

            lives.Add(Instantiate(sprLife, transform.position + new Vector3(i*sprSize, 0f, 0f), Quaternion.identity)); // Instantiate Lives
            lives[i].transform.parent = gameObject.transform;                                                          //   As child of LifeManager 
        }
    }

    // TO BE DONE:
    //    - Set LifeManager in sync with ScoreManager (???????????)
    private void FixedUpdate()
    {
        // On Death
        //      Reduce life
        //      Adjust range of List for Debug
        if (pDeath)
        { 
            Destroy(lives[lives.Count-1]);
            lives.RemoveRange(lives.Count-1, 1);
            pDeath = false;

            if (lives.Count == 0)
                GameObject.Find("GameManager").GetComponent<GameOver>().isGameOver = true;
        }
    }
}
