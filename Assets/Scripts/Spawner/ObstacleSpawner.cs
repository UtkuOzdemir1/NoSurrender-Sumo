using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private GameObject spawnParent;
    public GameObject collectablePrefab;

    public int numberOfCollectable = 15;
    public float levelWitdh = 3f;
    public float levelHeigth = 3f;

    // Start is called before the first frame update
    void Start()
    {
        spawnParent = new GameObject("Collectables");
        for (int i = 0; i < numberOfCollectable; i++)
        {
            SpawnObjects();
        }
    }
    void Update()
    {
        if(spawnParent.transform.childCount < numberOfCollectable - 4)
        {
            StartCoroutine(SpawnDelay());
        }
    }

    void SpawnObjects()
    {
        Vector3 spawnPosition = new Vector3();

        spawnPosition.y = 0.5f;
        spawnPosition.z = Random.Range(-levelHeigth, levelHeigth);
        spawnPosition.x = Random.Range(-levelWitdh, levelWitdh);
        GameObject collectable = Instantiate(collectablePrefab, spawnPosition, Quaternion.identity);
        collectable.transform.parent = spawnParent.transform;
    }

    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(2f);
        for (int i = spawnParent.transform.childCount; i < numberOfCollectable; i++)
        {
            SpawnObjects();
        }
    }
}
