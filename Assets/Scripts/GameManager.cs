using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // max pickups to spawn
    public int PickupCount = 10;

    // enemies count to spawn
    public int EnemiesCount = 3;

    // pickup prefab
    public GameObject PickupPrefab;

    // enemy prefab
    public GameObject EnemyPrefab;

    // pickup root object
    GameObject pickupRoot;

    // enemy root object
    GameObject enemyRoot;

    List<Vector3> objectPositionList = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        // add the pickup to game object list
        pickupRoot = GameObject.Find("Pickups");
        enemyRoot = GameObject.Find("Enemies");

        SpawnPickups();
        SpawnEnemies();
    }

    // spawn random pickups
    void SpawnPickups()
    {
        // generate random pickup
        for (int i = 0; i < PickupCount; i++)
        {
            float x = Random.Range(-9, 9);
            float y = PickupPrefab.transform.position.y;
            float z = Random.Range(-9, 9);

            // instantiate pickup object
            GameObject newPickup = Instantiate(PickupPrefab, GetUniquePosition(PickupPrefab.transform.position), Quaternion.identity);

            // add new pickup to root
            newPickup.transform.parent = pickupRoot.transform;
        }
    }

    // spaen random enemy
    void SpawnEnemies()
    {
        // generate random enemies
        for(int i=0;i<EnemiesCount;i++)
        {
            

            // instantiate enemy object
            GameObject newEnemy = Instantiate(EnemyPrefab, GetUniquePosition(EnemyPrefab.transform.position), Quaternion.identity);

            // add new enemy to root
            newEnemy.transform.parent = enemyRoot.transform;
        }
    }

    Vector3 GetUniquePosition(Vector3 original)
    {
        float x = Random.Range(-9, 9);
        float y = original.y;
        float z = Random.Range(-9, 9);

        Vector3 newPos = new Vector3(x, y, z);

        if(objectPositionList.Contains(newPos))
        {
            newPos = GetUniquePosition(original);
        }

        return newPos;
    }
}
