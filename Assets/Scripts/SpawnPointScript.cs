using UnityEngine;

public class SpawnPointScript : MonoBehaviour
{
    public Vector3[] spawnPoints;

    private SpawnEasyWaveScript spawnEasyWavescript;
    private SpawnMediumWaveScript spawnMediumWavescript;
    private SpawnHardWaveScript spawnHardWavescript;

    private void Start()
    {
        spawnEasyWavescript = FindObjectOfType<SpawnEasyWaveScript>();
        spawnEasyWavescript.TakeSpawnPoints(spawnPoints);

        spawnMediumWavescript = FindObjectOfType<SpawnMediumWaveScript>();
        spawnMediumWavescript.TakeSpawnPoints(spawnPoints);

        spawnHardWavescript = FindObjectOfType<SpawnHardWaveScript>();
        spawnHardWavescript.TakeSpawnPoints(spawnPoints);
    }

    public void Awake()
    {
        spawnPoints[0] = new Vector3(-12, 1, 0);
        spawnPoints[1] = new Vector3(-12, 5, 0);
        spawnPoints[2] = new Vector3(-8, 8, 0);
        spawnPoints[3] = new Vector3(-2, 8, 0);
        spawnPoints[4] = new Vector3(2, 8, 0);
        spawnPoints[5] = new Vector3(8, 8, 0);
        spawnPoints[6] = new Vector3(12, 5, 0);
        spawnPoints[7] = new Vector3(12, 5, 0);
        spawnPoints[8] = new Vector3(12, 1, 0);
    }

}
