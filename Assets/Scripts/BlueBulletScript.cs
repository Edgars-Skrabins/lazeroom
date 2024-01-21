using UnityEngine;

public class BlueBulletScript : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private Rigidbody2D BBrb;

    private void OnEnable()
    {
        BBrb.velocity = transform.up * projectileSpeed;
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
