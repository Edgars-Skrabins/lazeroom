using UnityEngine;


public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D[] healthbars;

    [SerializeField] private GameObject explosionFX;
    [SerializeField] private GameObject deathFX;

    [SerializeField] private GameObject crosshair;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RedEnemy") || collision.CompareTag("GreenEnemy") || collision.CompareTag("BlueEnemy"))
        {
            GameManagerScript.Instance.playerLifes -= 1;
            Instantiate(explosionFX, transform.position, transform.rotation);
        }
    }
    private void OnEnable()
    {
        Cursor.visible = false;
        crosshair.SetActive(true);
    }
    private void OnDisable()
    {
        Cursor.visible = true;
        crosshair.SetActive(false);
    }

    void Update()
    {

        // ----- Answers for what happens when lifes go down (Mostly just changes lights of the health bars) ----- 
        foreach (var Light2D in healthbars)
        {
            if (Light2D.color == Color.green)
            {
                Light2D.intensity = 200;
            }
            else
            {
                Light2D.intensity = 300;
            }
        }

        if (GameManagerScript.Instance.playerLifes == 3)
        {
            if (GameManagerScript.Instance.gunSelection == 1)
            {
                foreach (var Light2D in healthbars)
                {
                    Light2D.color = Color.red;
                }
            }
            else if (GameManagerScript.Instance.gunSelection == 2)
            {
                foreach (var Light2D in healthbars)
                {
                    Light2D.color = Color.green;
                }
            }
            else if (GameManagerScript.Instance.gunSelection == 3)
            {
                foreach (var Light2D in healthbars)
                {
                    Light2D.color = Color.blue;
                }
            }
        }
        else if (GameManagerScript.Instance.playerLifes == 2)
        {
            if (GameManagerScript.Instance.gunSelection == 1)
            {
                healthbars[2].color = Color.grey;
                for (int i = 0; i < GameManagerScript.Instance.playerLifes; i++)
                {
                    healthbars[i].color = Color.red;
                }
            }
            else if (GameManagerScript.Instance.gunSelection == 2)
            {
                healthbars[2].color = Color.grey;
                for (int i = 0; i < GameManagerScript.Instance.playerLifes; i++)
                {
                    healthbars[i].color = Color.green;
                }
            }
            else if (GameManagerScript.Instance.gunSelection == 3)
            {
                healthbars[2].color = Color.grey;
                for (int i = 0; i < GameManagerScript.Instance.playerLifes; i++)
                {
                    healthbars[i].color = Color.blue;
                }
            }
        }
        else if (GameManagerScript.Instance.playerLifes == 1)
        {
            if (GameManagerScript.Instance.gunSelection == 1)
            {
                healthbars[0].color = Color.red;
                healthbars[1].color = Color.grey;
                healthbars[2].color = Color.grey;

            }
            else if (GameManagerScript.Instance.gunSelection == 2)
            {
                healthbars[0].color = Color.green;
                healthbars[1].color = Color.grey;
                healthbars[2].color = Color.grey;
            }
            else if (GameManagerScript.Instance.gunSelection == 3)
            {
                healthbars[0].color = Color.blue;
                healthbars[1].color = Color.grey;
                healthbars[2].color = Color.grey;
            }
        }
        else if (GameManagerScript.Instance.playerLifes == 0)
        {
            foreach (var Light2D in healthbars)
            {
                Light2D.color = Color.grey;
            }
            deathFX.SetActive(true);
        }

        if (GameManagerScript.Instance.playerLifes > 0)
        {
            deathFX.SetActive(false);
        }

    }
}
