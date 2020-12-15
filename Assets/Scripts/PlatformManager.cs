using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour
{
    // Instantiate Platform Prefabs
    public GameObject[] platformPrefabs;

    // Instantiate player transform, original z axis spawn, the length of platform and platform limit on the screen. 
    private Transform playerTransform;
    private float spawnZ = 10.0f;
    private float platformLength = 10.0f;
    private float safeZone = 15.0f;
    private int platformLimitOnScreen = 10;
    private int lastPrefabIndex = 0;

    //Instantiate a List to detect active platform prefab
    private List<GameObject> activePlatforms;

	// Use this for initialization
	void Start ()
    {
        activePlatforms = new List<GameObject>(); // Create active platform
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Locate Player tag

        // For 1 to platform limit, Platform is spawned
        for (int i = 0; i < platformLimitOnScreen; i++)
        {
            // Spawn Clear Platform first
            if (i < 2)
                SpawnPlatform(2);
            else
                SpawnPlatform();
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // if Z Axis is crossed at every 10th value, new platform is spawned and the previous is deleted
        if (playerTransform.position.z - safeZone > (spawnZ - platformLimitOnScreen * platformLength))
        {
            SpawnPlatform();
            DeletePlatform();
        }
	}

    private void SpawnPlatform (int prefabIndex = -1)
    {
        // Spawning platforms by Instantiating a prefab as Game Object.
        GameObject gObject;
        if (prefabIndex == -1)
            gObject = Instantiate(platformPrefabs[RandomPrefabIndex()]) as GameObject;
        else
            gObject = Instantiate(platformPrefabs[prefabIndex]) as GameObject;
        gObject.transform.SetParent(transform);
        gObject.transform.position = Vector3.forward * spawnZ;
        spawnZ += platformLength;
        activePlatforms.Add(gObject);
    }

    private void DeletePlatform()
    {
        // Delete Previous Platform
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }

    // Spawning Random Blocks - Random Number Generator
    private int RandomPrefabIndex()
    {
        if (platformPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, platformPrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
