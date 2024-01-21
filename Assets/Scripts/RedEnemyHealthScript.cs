using UnityEngine;

public class RedEnemyHealthScript : MonoBehaviour
{
    [SerializeField] private GameObject deathExplosionEffect;
    [SerializeField] private int health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("RedBullet"))
        {
            health -= 1;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            health = 0;
        }
    }

    private void OnEnable()
    {
        health = 1;
    }

    private void Update()
    {
        if (health <= 0)
        {
            Instantiate(deathExplosionEffect, transform.position, transform.rotation);
            this.gameObject.SetActive(false);

            AudioManagerScript.audiomanager.Play("explosionsfx");

        }
    }
}
