using UnityEngine;

public class Health_PowerUp : MonoBehaviour
{
    [SerializeField] private int healthBonus = 2;
    PlayerHealth playerHealth;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerHealth.currentHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);

            playerHealth.currentHealth = playerHealth.currentHealth + healthBonus;
            
        } 
    }
}
