using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private ShootingScript shootScript;

    public Rigidbody2D playerRb;
    public Camera cam;
    private float angle;
    //public float moveSpeed = 5f;
    //private Vector2 movement;
    private Vector2 mousePos;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        //movement.x = Input.GetAxisRaw("Horizontal");
        //movement.y = Input.GetAxisRaw("Vertical");
        //movement = movement.normalized;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //Takes the mouse position and converts the values to a ScreenToWorldPoint so its usable in the calculations

    }
    private void FixedUpdate()
    {

        //playerRb.velocity = movement * moveSpeed;
        Vector2 lookDir = mousePos - playerRb.position;
        float lookangle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90; //Radian angle math function used to decide the degree of where the player character is turned to

        //Locks the player turning movement 
        if (lookangle < -180 && lookangle > -270)
        {
            angle = 89;
            playerRb.rotation = angle;
        }
        else if (lookangle > -180 && lookangle < -90)
        {
            angle = -89;
            playerRb.rotation = angle;
        }
        else
        {
            playerRb.rotation = lookangle;
        }
    }
}
