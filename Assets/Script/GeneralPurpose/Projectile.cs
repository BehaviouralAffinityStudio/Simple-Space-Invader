using UnityEngine;
using System.Collections.Generic;

public class Projectile : MonoBehaviour
{

    [SerializeField] private Rigidbody2D projectile;

    void Start()
    {
        // AddForce on projectile spawn
        if (gameObject.layer == 10) // Player laser
            projectile.AddForce(new Vector2(0f, 300f));
        else if (gameObject.layer == 11) // Enemy laser
            projectile.AddForce(new Vector2(0f, -300f));

        // Note : Space Invader :
        //      Global projectile speed is 300f
        //      Layers
        //          pLaser : 10
        //          eLaser : 11
    }

    // TRIGGER SECTION
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Reminder
        //      Collision Ignore may be applied in Physics2D layers
        if (other.gameObject.tag == "Player"  || other.gameObject.tag == "Enemy") // Trigger Pl || En
        {
            Destroy(gameObject, 0f);
            other.gameObject.GetComponent<Animator>().SetBool("isDead", true);
        }
        else if (other.gameObject.tag == "Border") // Trigger Border
            Destroy(gameObject, 0.3f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Reminder
        //      Collision Ignore may be applied in Physics2D layers
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy") // Trigger Pl || En
        {
            Destroy(gameObject, 0f);
            other.gameObject.GetComponent<Animator>().SetBool("isDead", true);
        }
        else if (other.gameObject.tag == "Border") // Trigger Border
            Destroy(gameObject, 0.3f);
    }
}
