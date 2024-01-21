using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance { get; private set; }

    public SpawnEasyWaveScript easyWaveScript;
    public SpawnMediumWaveScript mediumWaveScript;
    public SpawnHardWaveScript hardWaveScript;

    public int gunSelection;

    //Timers for each bullet
    public float timerRB;
    public float timerGB;
    public float timerBB;

    //Player health
    public float playerLifes = 3;

    //Cooldowns for each bullet
    public float cooldownRB;
    public float cooldownGB;
    public float cooldownBB;

    //Enemy speed for setting the velocity in FollowPlayerScript
    public float enemySpeed;

    public void Start()
    {

        gunSelection = 1;

        cooldownRB = 0.6f;
        cooldownGB = 0.1f;
        cooldownBB = 0.3f;


        timerRB = cooldownRB;
        timerGB = cooldownGB;
        timerBB = cooldownBB;

        enemySpeed = 3f;
    }

    public void Update()
    {
        //Timers for each bullet
        timerRB += Time.deltaTime;
        timerGB += Time.deltaTime;
        timerBB += Time.deltaTime;

    }

    //Makes GameManager into a singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartEasyGame()
    {
        easyWaveScript.enabled = true;
        SceneManager.LoadScene(1);
        playerLifes = 3;
    }
    public void StartMediumGame()
    {
        mediumWaveScript.enabled = true;
        SceneManager.LoadScene(1);
        playerLifes = 3;
    }
    public void StartHardGame()
    {
        hardWaveScript.enabled = true;
        SceneManager.LoadScene(1);
        playerLifes = 3;
    }
    public void ExitGame()
    {
        Application.Quit();
        playerLifes = 3;
    }
}