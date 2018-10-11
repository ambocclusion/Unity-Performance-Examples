using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericObjectMovement : MonoBehaviour
{
    public List<System.Action> OnDestroyAction = new List<System.Action>();
    [SerializeField] private float lifeTime = 5f;

    private float movementSpeed;
    private Vector3 movementDirection;

    private float spawnTime;
    private float deathTime;

    private void OnEnable()
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
        foreach (var d in OnDestroyAction)
        {
            d.Invoke();
        }
    }
}
