using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookForPlayer : MonoBehaviour
{
    /*private float dirX;
    private float movSpeed;
    private Rigidbody2D rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -9f) dirX = 1f;
        else if (transform.position.x > 9f) dirX = -1f;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * movSpeed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject.name.Equals("topDownCharacterTest"))
        {
            Debug.Log("Found");
        }
    }
    private void OnTriggerExit2D(Collider2D Other)
    {
        if (Other.gameObject.name.Equals("topDownCharacterTest"))
        {
            Debug.Log("Nothing");
        }
    }
    */
}
