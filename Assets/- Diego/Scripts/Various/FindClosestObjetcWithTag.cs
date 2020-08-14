using UnityEngine;
using System.Collections;

public class FindClosestObjetcWithTag : MonoBehaviour
{
    public string targetTag;
    public GameObject closestObject;

    private void OnEnable()
    {
        closestObject = FindClosestEnemy();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F)) closestObject = FindClosestEnemy();
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject currentObject in objects)
        {
            Vector3 difference = currentObject.transform.position - transform.position;
            float currentDistance = difference.sqrMagnitude;

            if (currentDistance < closestDistance)
            {
                closest = currentObject;
                closestDistance = currentDistance;
            }
        }
        return closest;
    }
}
