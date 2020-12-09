using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OnceUponAMemory.Main
{
    public class MiniTornadoController : MonoBehaviour
    {
        [SerializeField] private float damage = 0f;
        private Rigidbody2D rb2D = null;

        private void Awake()
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        public void ImpulseMiniTornado(Vector2 dir, float imp)
        {
            rb2D.AddForce(dir * imp, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(damage);
            }

            if (collision.gameObject.name != gameObject.name && collision.gameObject.name != "TornadoBoss" && collision.gameObject.name != "BossBattleMusic(Trigger)")
            {
                Destroy(gameObject);
            }
        }
    }
}
