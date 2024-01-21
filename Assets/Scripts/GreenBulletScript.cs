using UnityEngine;

public class GreenBulletScript : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody2D GBrb;

    private void OnEnable()
    {
        GBrb.velocity = transform.up * projectileSpeed;
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

