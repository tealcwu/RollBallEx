using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // max pickups to spawn
    public int PickupCount = 10;

    // pickup prefab
    public GameObject PickupPrefab;

    // pickup root object
    GameObject pickupRoot;

    // Use this for initialization
    void Start()
    {
        // add the pickup to game object list
        pickupRoot = GameObject.Find("Pickups");

        SpawnPickups();
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
            GameObject newPickup = Instantiate(PickupPrefab, new Vector3(x, y, z), Quaternion.identity);

            // add new pickup to root
            newPickup.transform.parent = pickupRoot.transform;
        }
    }
}
