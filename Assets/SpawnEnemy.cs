using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public Transform[] pointsSpawn;
    public GameObject prefabEnemy;

    public float timeToSpawn = 3f;
    private float timerSpawn = 3f;


    private void Update()
    {
        timerSpawn -= Time.deltaTime;

        if (timerSpawn <= 0)
            Spawn();
    }

    public void Spawn()
    {
        foreach (var point in pointsSpawn) 
        {
            Instantiate(prefabEnemy, point.position, Quaternion.identity);
            timerSpawn = timeToSpawn;
        }
    }
}
