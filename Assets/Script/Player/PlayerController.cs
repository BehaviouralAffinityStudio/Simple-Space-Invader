using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // gObj to spawn : thrusterFire
    [SerializeField] private GameObject thrusterFire;

    // Movement variable section
    [SerializeField] private float moveSpeed = 3.5f;
    [SerializeField] private float clampXaxisMin = -3.5f;
    [SerializeField] private float clampXaxisMax = 3.5f;
    private float axis;

    void FixedUpdate()
    {
        // Movement Section
        axis = Input.GetAxisRaw("Horizontal") * moveSpeed;
        transform.Translate(axis * Time.deltaTime, 0f, 0f);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, clampXaxisMin, clampXaxisMax), transform.position.y, transform.position.z); // Clamp movement on X axis
    }
}
