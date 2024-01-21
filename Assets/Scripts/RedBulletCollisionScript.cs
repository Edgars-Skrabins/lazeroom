using UnityEngine;

public class RedBulletCollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedEnemy"))
        {
            this.gameObject.SetActive(false);
            Instantiate(bulletEffect, transform.position, transform.rotation);
        }
        else if (collision.CompareTag("GreenEnemy") || collision.CompareTag("BlueEnemy"))
        {
            this.gameObject.SetActive(false);
            Instantiate(bulletEffect, transform.position, transform.rotation);
        }
    }
}
