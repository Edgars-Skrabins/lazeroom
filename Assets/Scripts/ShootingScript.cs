using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    //Camera shake intensity and time values

    [SerializeField] private float shakeIntensityRB;
    [SerializeField] private float shakeTimeRB;

    [SerializeField] private float shakeIntensityGB;
    [SerializeField] private float shakeTimeGB;

    [SerializeField] private float shakeIntensityBB;
    [SerializeField] private float shakeTimeBB;

    //Muzzle flash effects

    [SerializeField] private Transform muzzleLocation;

    [SerializeField] private GameObject muzzleflashRB;
    [SerializeField] private GameObject muzzleflashGB;
    [SerializeField] private GameObject muzzleflashBB;

    //Colors for different states

    private Color redShootingColor = new Color(175f, 0f, 0f, 0f);
    private Color greenShootingColor = new Color(0f, 165f, 0f, 0f);
    private Color blueShootingColor = new Color(0f, 0f, 190f, 0f);

    private bool isFiring1;
    private bool isFiring2;
    private bool isFiring3;

    [SerializeField] private UnityEngine.Rendering.Universal.Light2D circleLight;
    [SerializeField] private UnityEngine.Rendering.Universal.Light2D squareLight;

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private Transform[] shootingPointsShotgun;

    private void Update()
    {
        // ----- Colors of the player -----

        if (GameManagerScript.Instance.gunSelection == 1)
        {
            if (Input.GetMouseButton(0))
            {
                circleLight.color = redShootingColor;
                squareLight.color = redShootingColor;
            }
            else
            {
                circleLight.color = Color.red;
                squareLight.color = Color.red;
            }
        }
        else if (GameManagerScript.Instance.gunSelection == 2)
        {
            if (Input.GetMouseButton(0))
            {
                circleLight.color = greenShootingColor;
                squareLight.color = greenShootingColor;
            }
            else
            {
                circleLight.color = Color.green;
                squareLight.color = Color.green;
            }
        }
        else if (GameManagerScript.Instance.gunSelection == 3)
        {
            if (Input.GetMouseButton(0))
            {
                circleLight.color = blueShootingColor;
                squareLight.color = blueShootingColor;
            }
            else
            {
                circleLight.color = Color.blue;
                squareLight.color = Color.blue;
            }
        }



        // -----Answers for selecting different bullets-----


        //Selection with numbers

        if (Input.GetKey("1") || Input.GetKey("[1]"))
        {
            GameManagerScript.Instance.gunSelection = 1;
        }
        else if (Input.GetKey("2") || Input.GetKey("[2]"))
        {
            GameManagerScript.Instance.gunSelection = 2;
        }
        else if (Input.GetKey("3") || Input.GetKey("[3]"))
        {
            GameManagerScript.Instance.gunSelection = 3;
        }

        //Selection with the scroll wheel

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            GameManagerScript.Instance.gunSelection++;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            GameManagerScript.Instance.gunSelection--;
        }

        //Selection with the arrows
        if (Input.GetKey("up"))
        {
            GameManagerScript.Instance.gunSelection++;
        }
        else if (Input.GetKey("down"))
        {
            GameManagerScript.Instance.gunSelection--;
        }

        GameManagerScript.Instance.gunSelection = Mathf.Clamp(GameManagerScript.Instance.gunSelection, 1, 3); // Limits the gunSelection integer to be only between 1 to 3 so it doesnt go above 3 or below 1 when switching guns with the scroll wheel or arrows

        // -----Answers for which bullet is selected-----

        //Gun1Selection
        if (GameManagerScript.Instance.gunSelection == 1)
        {
            isFiring2 = false;
            isFiring3 = false;

            if (Input.GetMouseButton(0))
            {
                isFiring1 = true;
            }
            else
            {
                isFiring1 = false;
            }
        }

        //Gun2Selection
        else if (GameManagerScript.Instance.gunSelection == 2)
        {
            isFiring1 = false;
            isFiring3 = false;

            if (Input.GetMouseButton(0))
            {
                isFiring2 = true;
            }
            else
            {
                isFiring2 = false;
            }
        }
        else if (GameManagerScript.Instance.gunSelection == 3)
        {
            isFiring1 = false;
            isFiring2 = false;

            if (Input.GetMouseButton(0))
            {
                isFiring3 = true;
            }
            else
            {
                isFiring3 = false;
            }
        }

        // -----Answers for firing the bullets-----

        //Gun1Firing
        if (isFiring1 == true)
        {
            if (GameManagerScript.Instance.timerRB >= GameManagerScript.Instance.cooldownRB)
            {
                ShootRedBullet();
                GameManagerScript.Instance.timerRB = 0f;
            }
        }
        //Gun2Firing
        if (isFiring2 == true)
        {
            if (GameManagerScript.Instance.timerGB >= GameManagerScript.Instance.cooldownGB)
            {
                ShootGreenBullet();
                GameManagerScript.Instance.timerGB = 0f;
            }
        }
        if (isFiring3 == true)
        {
            if (GameManagerScript.Instance.timerBB >= GameManagerScript.Instance.cooldownBB)
            {
                ShootBlueBullet();
                GameManagerScript.Instance.timerBB = 0f;
            }
        }
    }

    // ----- Functions for spawning the bullets -----

    private void ShootRedBullet()
    {
        GameObject obj = RedBulletPoolerScript.PoolerRB.GetPooledObjectRB();
        if (obj == null) return; // Backs out of the function if the returned value is null to not cause an error

        obj.transform.position = shootingPoint.position;
        obj.transform.rotation = shootingPoint.rotation;
        obj.SetActive(true);

        CameraShakeScript.Instance.ShakeCamera(shakeIntensityRB, shakeTimeRB); // Camera shake

        Instantiate(muzzleflashRB, muzzleLocation.position, muzzleLocation.rotation); // Muzzle flash effect

        AudioManagerScript.audiomanager.Play("redlasersfx");

    }

    private void ShootGreenBullet()
    {
        GameObject obj = GreenBulletPoolerScript.PoolerGB.GetPooledObjectGB();
        if (obj == null) return; // Backs out of the function if the returned value is null to not cause an error

        obj.transform.position = shootingPoint.position;
        obj.transform.rotation = shootingPoint.rotation;
        obj.SetActive(true);

        CameraShakeScript.Instance.ShakeCamera(shakeIntensityGB, shakeTimeGB); // Camera shake

        Instantiate(muzzleflashGB, muzzleLocation.position, muzzleLocation.rotation); // Muzzle flash effect

        AudioManagerScript.audiomanager.Play("greenlasersfx");

    }
    private void ShootBlueBullet()
    {
        GameObject obj0 = BlueBulletPoolerScript.PoolerBB.GetPooledObjectBB();
        if (obj0 == null) return; // Backs out of the function if the returned value is null to not cause an error

        obj0.transform.position = shootingPointsShotgun[0].position;
        obj0.transform.rotation = shootingPointsShotgun[0].rotation;
        obj0.SetActive(true);

        GameObject obj1 = BlueBulletPoolerScript.PoolerBB.GetPooledObjectBB();
        if (obj1 == null) return; // Backs out of the function if the returned value is null to not cause an error

        obj1.transform.position = shootingPointsShotgun[1].position;
        obj1.transform.rotation = shootingPointsShotgun[1].rotation;
        obj1.SetActive(true);

        GameObject obj2 = BlueBulletPoolerScript.PoolerBB.GetPooledObjectBB();
        if (obj2 == null) return; // Backs out of the function if the returned value is null to not cause an error

        obj2.transform.position = shootingPointsShotgun[2].position;
        obj2.transform.rotation = shootingPointsShotgun[2].rotation;
        obj2.SetActive(true);

        Instantiate(muzzleflashBB, muzzleLocation.position, muzzleLocation.rotation); // Muzzle flash effect

        CameraShakeScript.Instance.ShakeCamera(shakeIntensityBB, shakeTimeBB); // Camera shake

        AudioManagerScript.audiomanager.Play("bluelasersfx");

    }
}
