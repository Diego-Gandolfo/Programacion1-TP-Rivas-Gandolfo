using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Attack01 : MonoBehaviour
{
    public string axisFire = "Fire1";
    public GameObject attackArea;
    public LayerMask m_LayerMask;
    public float damage;
    public float delay;


    private void Update()
    {
        if (Input.GetAxis(axisFire) != 0)
        {
            ListObjects(); 
        }
    }

    private void ListObjects()
    {
        Characer_AttackArea01 char_AttackArea01 = attackArea.GetComponent<Characer_AttackArea01>();

        foreach (Collider2D collider in char_AttackArea01.collidersInAttackArea)
        {
            Debug.Log(collider + " > " + collider.gameObject.name);
        }
    }
}
