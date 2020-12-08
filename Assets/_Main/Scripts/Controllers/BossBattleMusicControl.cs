using OnceUponAMemory.Main;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleMusicControl : MonoBehaviour
{
    [SerializeField]
    private GameObject bossBattleMusic = null;

    [SerializeField]
    private EnemyHealth tornadoBoss;

    private void Update()
    {
        if (tornadoBoss.currentHeatlh <= 0)
        {
            bossBattleMusic.gameObject.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bossBattleMusic.gameObject.SetActive(true);
        }

        else
        {
            bossBattleMusic.gameObject.SetActive(false);
        }
    }


}
