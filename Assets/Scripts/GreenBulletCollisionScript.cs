using UnityEngine;

public class GreenBulletCollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GreenEnemy"))
        {
            gameObject.SetActive(false);
            Instantiate(bulletEffect, transform.position, transform.rotation);
        }
        else if (collision.CompareTag("RedEnemy") || collision.CompareTag("BlueEnemy"))
        {
            gameObject.SetActive(false);
            Instantiate(bulletEffect, transform.position, transform.rotation);
        }
    }
}
