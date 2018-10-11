using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanHitchingScript : MonoBehaviour
{
    [SerializeField] private int amountToSpawn = 20;
    [SerializeField] private float rateToSpawn = 5f;
    [SerializeField] private float spawnRange = 10f;
    [SerializeField] private GameObject objectToSpawn;

    [HideInInspector] public Queue<GameObject> spawned = new Queue<GameObject>();

    private float lastSpawn = -10f;
    private float nextSpawn = 0f;
    private int activeSpawns = 0;

    private void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            spawned.Enqueue(Spawn());
        }
    }

    private void FixedUpdate()
    {
        if (Time.time >= lastSpawn + nextSpawn)
        {
            int spawns = activeSpawns;
            for (int i = 0; i < amountToSpawn - spawns; i++)
            {
                Activate();
            }
            nextSpawn = UnityEngine.Random.value * rateToSpawn;
            lastSpawn = Time.time;
        }
    }

    private GameObject Spawn()
    {
        GameObject newObject = Instantiate(objectToSpawn) as GameObject;
        if (newObject.GetComponent<CleanObjectMovement>() != null)
        {
            newObject.GetComponent<CleanObjectMovement>().hitchingScript = this;
        }
        newObject.SetActive(false);
        return newObject;
    }

    private void Activate()
    {
        GameObject obj = spawned.Dequeue();
        Vector3 pos = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
        obj.transform.position = pos;
        obj.SetActive(true);
        activeSpawns++;
    }

    public void Recycle(GameObject obj)
    {
        spawned.Enqueue(obj);
        obj.SetActive(false);
        activeSpawns--;
    }
}
