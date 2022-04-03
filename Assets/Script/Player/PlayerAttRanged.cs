using UnityEngine;
using System.Collections;

public class PlayerAttRanged : MonoBehaviour
{
    // 0 - Projectile | 1 - Firing animation as Object to not link it to this.gameObject
    [SerializeField] private GameObject[] projectile = new GameObject[2];
    // Animator for the gameObject firing
    [SerializeField] private Animator animator;

    void Update()
    {
        // Main attack - Left mouse button
        if (Input.GetMouseButtonDown(0) && !animator.GetBool("isFiring"))
        {
            // Firing animation - Canon
            animator.SetBool("isFiring", true);

            // Instantiate gameObjects
            Instantiate(projectile[1], this.transform.position, Quaternion.identity); // Muzzle Flash
            Instantiate(projectile[0], this.transform.position, Quaternion.identity); // Projectile -> PlayerAttRanged.cs
        }
    }
}
