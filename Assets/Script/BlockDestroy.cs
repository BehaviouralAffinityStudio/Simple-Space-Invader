using UnityEngine;
using System.Collections.Generic;

public class BlockDestroy : MonoBehaviour
{
    // TEST SECTION START
    [SerializeField] private float blockSprSize = 0.03f;
    // TEST SECTION END


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Block")
        {
            DestroyMultipleBlock(other);
        }
        else if (this.tag == "Block" && other.tag == "Enemy")
            Destroy(gameObject);
    }

    private void DestroyMultipleBlock(Collider2D other)
    {
        // 0 - Left | 1 - Top_Left | 2 - Top | 3 - Top_Right | 4 - Right
        int[] direction = new int[5];
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position, new Vector2(Random.Range(0, 2), Random.Range(0, 2)), blockSprSize);
        //hit = Physics.SphereCast(transform.position, new Vector3(0f, 0f, 0f), out hit, blockSprSize,0 , 10);
        Debug.DrawLine(transform.position, hit.point, Color.red);

        if (hit)
        {
            hit = Physics2D.Raycast(hit.transform.position, new Vector2(Random.Range(0,2), Random.Range(0, 2)), blockSprSize);
            Destroy(hit.transform.gameObject, 0f);
        }

        // nextPoss[index] * direction[index]

        Destroy(gameObject, 0f);

        Destroy(other.gameObject, 0f);
    }

}
