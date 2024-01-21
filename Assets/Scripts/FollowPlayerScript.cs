using UnityEngine;

public class FollowPlayerScript : MonoBehaviour
{

    private static Transform playertf;
    private static PlayerMovementScript playermovementscript;

    [SerializeField] private Rigidbody2D enemyRb;

    private Vector3 toplayerVector;

    private void OnEnable()
    {
        if (playermovementscript == null || playertf == null)
        {
            playermovementscript = FindObjectOfType<PlayerMovementScript>();
            playertf = playermovementscript.transform;
        }
    }

    private void Update()
    {
        if (playermovementscript == null || playertf == null)
        {
            return;
        }
        else
        {
            FollowPlayer();
        }
    }

    public void FollowPlayer()
    {
        //Somehow makes the enemy look at the player ¯\_(ツ)_/¯

        float angle = Mathf.Atan2(toplayerVector.y, toplayerVector.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        toplayerVector = (playertf.position - transform.localPosition).normalized;
        enemyRb.velocity = (toplayerVector * GameManagerScript.Instance.enemySpeed);
    }
}