using UnityEngine;

public class MainMenuHandlerScript : MonoBehaviour
{
    // ----- The purpose of this game obj is so the buttons dont lose reference to the functions on scene switch -----

    public void ExitGame()
    {
        GameManagerScript.Instance.ExitGame();
    }
    public void StartEasyGame()
    {
        GameManagerScript.Instance.StartEasyGame();
    }
    public void StartMediumGame()
    {
        GameManagerScript.Instance.StartMediumGame();
    }
    public void StartHardGame()
    {
        GameManagerScript.Instance.StartHardGame();
    }
}
