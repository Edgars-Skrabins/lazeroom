using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuHandlerScript : MonoBehaviour
{

    [SerializeField] private GameObject crosshair;

    [SerializeField] private GameObject victoryscreen;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject deathMenu;

    [SerializeField] private GameObject deadPlayer;
    [SerializeField] private GameObject alivePlayer;

    [SerializeField] private ShootingScript shootscript;

    private string lastDifficulty; // Keeps the last difficulty used in memory to reenable the right wave

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void BacktoMenu()
    {
        //Turns off all the menus
        victoryscreen.SetActive(false);
        pauseMenu.SetActive(false);
        deathMenu.SetActive(false);
        deadPlayer.SetActive(false);
        alivePlayer.SetActive(true);

        //Clears the enemies out
        for (int i = 0; i < RedEnemyPoolerScript.PoolerRE.pooledObjectsRE.Count; i++)
        {
            RedEnemyPoolerScript.PoolerRE.pooledObjectsRE[i].SetActive(false);
        }
        for (int i = 0; i < GreenEnemyPoolerScript.PoolerGE.pooledObjectsGE.Count; i++)
        {
            GreenEnemyPoolerScript.PoolerGE.pooledObjectsGE[i].SetActive(false);
        }
        for (int i = 0; i < BlueEnemyPoolerScript.PoolerBE.pooledObjectsBE.Count; i++)
        {
            BlueEnemyPoolerScript.PoolerBE.pooledObjectsBE[i].SetActive(false);
        }

        for (int i = 0; i < RedBulletPoolerScript.PoolerRB.pooledObjectsRB.Count; i++)
        {
            RedBulletPoolerScript.PoolerRB.pooledObjectsRB[i].SetActive(false);
        }
        for (int i = 0; i < GreenBulletPoolerScript.PoolerGB.pooledObjectsGB.Count; i++)
        {
            GreenBulletPoolerScript.PoolerGB.pooledObjectsGB[i].SetActive(false);
        }
        for (int i = 0; i < BlueBulletPoolerScript.PoolerBB.pooledObjectsBB.Count; i++)
        {
            BlueBulletPoolerScript.PoolerBB.pooledObjectsBB[i].SetActive(false);
        }

        GameManagerScript.Instance.easyWaveScript.enabled = false;
        GameManagerScript.Instance.mediumWaveScript.enabled = false;
        GameManagerScript.Instance.hardWaveScript.enabled = false;

        Time.timeScale = 1;
        SceneManager.LoadScene(0);

    }
    public void Retry()
    {
        deadPlayer.SetActive(false);
        alivePlayer.SetActive(true);

        Time.timeScale = 1;
        GameManagerScript.Instance.playerLifes = 3;

        //Reenables the wave
        if (lastDifficulty == ("Easy"))
        {
            GameManagerScript.Instance.easyWaveScript.enabled = true;
        }
        else if (lastDifficulty == ("Medium"))
        {
            GameManagerScript.Instance.mediumWaveScript.enabled = true;
        }
        else if (lastDifficulty == ("Hard"))
        {
            GameManagerScript.Instance.hardWaveScript.enabled = true;
        }

        deathMenu.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                Cursor.visible = false;              
                crosshair.SetActive(false);
                pauseMenu.SetActive(true);
            }
            else if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                Cursor.visible = true;
                crosshair.SetActive(true);
                pauseMenu.SetActive(false);
            }
        }

        //For managing when the crosshair and the cursor shows or doesnt show 
        if (Time.timeScale == 0f)
        {
            shootscript.enabled = false;
            Cursor.visible = true;
            crosshair.SetActive(false);
        }
        else if (Time.timeScale == 1f)
        {
            shootscript.enabled = true;
            Cursor.visible = false;
            crosshair.SetActive(true);
        }

        if (GameManagerScript.Instance.playerLifes == 0)
        {
            Cursor.visible = true;

            shootscript.enabled = false;

            deadPlayer.SetActive(true);
            alivePlayer.SetActive(false);

            deathMenu.SetActive(true);

            if (GameManagerScript.Instance.easyWaveScript.enabled == true)
            {
                lastDifficulty = ("Easy");
                GameManagerScript.Instance.easyWaveScript.enabled = false;
            }
            else if (GameManagerScript.Instance.mediumWaveScript.enabled == true)
            {
                lastDifficulty = ("Medium");
                GameManagerScript.Instance.mediumWaveScript.enabled = false;
            }
            else if (GameManagerScript.Instance.hardWaveScript.enabled == true)
            {
                lastDifficulty = ("Hard");
                GameManagerScript.Instance.hardWaveScript.enabled = false;
            }

            //Clears the enemies out
            for (int i = 0; i < RedEnemyPoolerScript.PoolerRE.pooledObjectsRE.Count; i++)
            {
                RedEnemyPoolerScript.PoolerRE.pooledObjectsRE[i].SetActive(false);
            }
            for (int i = 0; i < GreenEnemyPoolerScript.PoolerGE.pooledObjectsGE.Count; i++)
            {
                GreenEnemyPoolerScript.PoolerGE.pooledObjectsGE[i].SetActive(false);
            }
            for (int i = 0; i < BlueEnemyPoolerScript.PoolerBE.pooledObjectsBE.Count; i++)
            {
                BlueEnemyPoolerScript.PoolerBE.pooledObjectsBE[i].SetActive(false);
            }

            for (int i = 0; i < RedBulletPoolerScript.PoolerRB.pooledObjectsRB.Count; i++)
            {
                RedBulletPoolerScript.PoolerRB.pooledObjectsRB[i].SetActive(false);
            }
            for (int i = 0; i < GreenBulletPoolerScript.PoolerGB.pooledObjectsGB.Count; i++)
            {
                GreenBulletPoolerScript.PoolerGB.pooledObjectsGB[i].SetActive(false);
            }
            for (int i = 0; i < BlueBulletPoolerScript.PoolerBB.pooledObjectsBB.Count; i++)
            {
                BlueBulletPoolerScript.PoolerBB.pooledObjectsBB[i].SetActive(false);
            }
        }
        else if(GameManagerScript.Instance.playerLifes > 0)
        {
            shootscript.enabled = true;
        }
    }

}
