using UnityEngine;

public class RedBulletScript : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody2D RBrb;

    private void OnEnable()
    {
        RBrb.velocity = transform.up * projectileSpeed;
        Invoke("Disable", 3f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }

}
