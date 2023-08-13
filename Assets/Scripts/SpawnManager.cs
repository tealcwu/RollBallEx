using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject PickUpPrefab; // PickUp prefab
    public GameObject EnemyPrefab;  // Enemy prefab
    public int PickUpSpawnCount = 8;// The counts of pickups to spawn
    public int EnemySpawnCount = 3; // The counts of enemy to spawn
    public float SpawnRadius = 8f;  // The radius to spawn randomly

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rotation = new Vector3(45, 45, 45);

        for (int i = 0; i <= PickUpSpawnCount; i++)
        {
            SpawnRandom(PickUpPrefab, rotation);
        }

        for (int j = 0; j <=EnemySpawnCount; j++)
        {
            SpawnRandom(EnemyPrefab);
        }
    }

    /// <summary>
    /// Spawn game objects
    /// </summary>
    /// <param name="target"></param>
    public void SpawnRandom(GameObject target)
    {
        // get random position
        Vector3 randomPostion = GenerateRandomPosition();

        // instantiate game object
        Instantiate(target, randomPostion, Quaternion.identity);
    }

    /// <summary>
    /// Spawn game objects with specified rotation
    /// </summary>
    /// <param name="target"></param>
    /// <param name="rotation"></param>
    public void SpawnRandom(GameObject target, Vector2 rotation)
    {
        // get random position
        Vector3 randomPostion = GenerateRandomPosition();

        // instantiate game object
        Instantiate(target, randomPostion, Quaternion.Euler(rotation));
    }

    /// <summary>
    /// Generate a random position
    /// </summary>
    /// <returns></returns>
    public Vector3 GenerateRandomPosition()
    {
        float x = Random.Range(-SpawnRadius, SpawnRadius);
        float z = Random.Range(-SpawnRadius, SpawnRadius);

        Vector3 randomPosition = new Vector3(x,0.5f,z);

        return randomPosition;
    }
}
