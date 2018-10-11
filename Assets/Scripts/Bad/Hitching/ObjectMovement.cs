using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;

    [HideInInspector] public HitchingScript hitchingScript;

    private float movementSpeed;
    private Vector3 movementDirection;

    private float spawnTime;
    private float deathTime;

    private void Start()
    {
        movementSpeed = Random.Range(-5f, 5f);
        movementDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        spawnTime = Time.time;
        deathTime = Random.Range(1f, lifeTime);
    }

    private void FixedUpdate()
    {
        if (Time.time >= spawnTime + deathTime)
        {
            Destroy(this.gameObject);
        }

        transform.Translate((movementDirection * movementSpeed) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        try
        {
            hitchingScript.spawned.Remove(this.gameObject);
        }
        catch { }
    }
}
