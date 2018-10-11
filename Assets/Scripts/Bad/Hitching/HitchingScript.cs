using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitchingScript : MonoBehaviour
{
    [SerializeField] private int amountToSpawn = 20;
    [SerializeField] private float rateToSpawn = 5f;
    [SerializeField] private float spawnRange = 10f;
    [SerializeField] private GameObject objectToSpawn;

    [HideInInspector] public List<GameObject> spawned = new List<GameObject>();

    private float lastSpawn = -10f;
    private float nextSpawn = 0f;

    private void FixedUpdate()
    {
        if (Time.time >= lastSpawn + nextSpawn)
        {
            if (spawned.Count < amountToSpawn)
            {
                for (int i = 0; i < amountToSpawn - spawned.Count; i++)
                {
                    Spawn();
                }
            }
            nextSpawn = UnityEngine.Random.value * rateToSpawn;
            lastSpawn = Time.time;
        }
    }

    private void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
        GameObject newObject = Instantiate(objectToSpawn, pos, Quaternion.identity) as GameObject;
        newObject.GetComponent<ObjectMovement>().hitchingScript = this;
        spawned.Add(newObject);
    }
}
