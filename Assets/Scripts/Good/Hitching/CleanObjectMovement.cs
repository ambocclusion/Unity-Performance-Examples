using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanObjectMovement : MonoBehaviour
{
    [SerializeField] private float lifeTime = 5f;
    [SerializeField] private bool useRandomLifetime = true;

    [HideInInspector] public CleanHitchingScript hitchingScript;

    private float movementSpeed;
    private Vector3 movementDirection;

    private float spawnTime;
    private float deathTime;

    private void OnEnable()
    {
        movementSpeed = Random.Range(-5f, 5f);
        movementDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        spawnTime = Time.time;
        if (useRandomLifetime)
        {
            deathTime = Random.Range(1f, lifeTime);
        }
        else
        {
            deathTime = lifeTime;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time >= spawnTime + deathTime)
        {
            Recycle();
        }

        transform.Translate((movementDirection * movementSpeed) * Time.deltaTime);
    }

    public void Recycle()
    {
        hitchingScript.Recycle(this.gameObject);
    }
}
