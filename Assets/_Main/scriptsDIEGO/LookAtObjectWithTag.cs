using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObjectWithTag : MonoBehaviour
{
    public string tagObject;
    private GameObject objectWithTag;

    private void Start()
    {
        objectWithTag = GameObject.FindGameObjectWithTag(tagObject);
    }

    private void Update()
    {
        Vector2 direction = new Vector2(objectWithTag.transform.position.x - transform.position.x, objectWithTag.transform.position.y - transform.position.y);

        transform.up = direction;
    }
}
