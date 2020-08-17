using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    public float speed = 2f;
    public float stopAt;
    public Transform player;
    public Transform weapon;

    public string tagObject;
    private GameObject objectWithTag;
    void Start()
    {
        objectWithTag = GameObject.FindGameObjectWithTag(tagObject);
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopAt)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        Vector2 direction = new Vector2(objectWithTag.transform.position.x, objectWithTag.transform.position.y - transform.position.y);
        transform.up = -direction;
    }
}
