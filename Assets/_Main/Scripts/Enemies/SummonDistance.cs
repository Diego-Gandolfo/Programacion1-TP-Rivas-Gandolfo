using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonDistance : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float maxDistance = 0;

    public bool canSummon = false;

    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) <= maxDistance)
        {
            canSummon = true;
        }
        else
        {
            canSummon = false;
        }
    }
}
