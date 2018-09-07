using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour {

    public Transform pointIn;
    public Transform pointOut;

    public Transform[] wallSpawnPoints;

    public GameObject prefabWall;

    public const float speed = 20;

    [HideInInspector]
    public bool isDead = false;

    void Start()
    {

        if (wallSpawnPoints.Length == 0) return;
        if (!prefabWall) return;

        for (int i = wallSpawnPoints.Length - 1; i >= 0; i--)
        {
            Vector3 spawnPos = wallSpawnPoints[i].position;

            //Spawn a wall, parent it to this chuck of track
            Instantiate(prefabWall, spawnPos, Quaternion.identity, transform);
        }
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;

        if(pointOut.position.z < -5)
        {
            isDead = true;
        }
    }
}
