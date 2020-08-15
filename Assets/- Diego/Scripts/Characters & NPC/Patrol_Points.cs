using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol_Points : MonoBehaviour
{
    public bool random = false;

    public float movemetSpeed = 3.0f;
    public float waitTime = 1.0f;
    private float timer = 0.0f;

    public Transform[] patrolPoints;
    private int randomPoint = 0;
    private int currentPoint = 0;

    private void Start()
    {
        randomPoint = Random.Range(0, patrolPoints.Length);
        currentPoint = 0;
        timer = waitTime;
    }

    private void Update()
    {
        if (random)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[randomPoint].position, movemetSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, patrolPoints[randomPoint].position) < 0.2f)
            {
                if (timer <= 0)
                {
                    randomPoint = Random.Range(0, patrolPoints.Length);
                    timer = waitTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
        else if (!random)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPoint].position, movemetSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, patrolPoints[currentPoint].position) < 0.2f)
            {
                if (timer <= 0)
                {
                    currentPoint++;

                    if ((currentPoint - 1) >= patrolPoints.Length)
                    {
                        Debug.Log("Al menos lo intento...");
                        currentPoint = 0;
                    }

                    timer = waitTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
    }
}
