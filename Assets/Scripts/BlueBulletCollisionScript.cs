using UnityEngine;

public class BlueBulletCollisionScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform thisTF = GetComponent<Transform>();

        if (collision.CompareTag("BlueEnemy"))
        {
            gameObject.SetActive(false);
            Instantiate(bulletEffect, transform.position, thisTF.rotation);
        }
        else if (collision.CompareTag("RedEnemy") || collision.CompareTag("GreenEnemy"))
        {
            gameObject.SetActive(false);
            Instantiate(bulletEffect, transform.position, thisTF.rotation);
        }
    }
}
