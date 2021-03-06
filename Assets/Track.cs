﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{

    public Transform pointIn;
    public Transform pointOut;
    public Transform floor;

    public Transform[] wallSpawnPoints;

    public GameObject wall;
    public GameObject powerUp;
    public GameObject[] obstacles;

    public static float speedMultiplier = 1;
    public const float speed = 20;

    [HideInInspector]
    public bool isDead = false;

    void Start()
    {

        if (wallSpawnPoints.Length == 0) return;
        if (!wall) return;

        for (int i = wallSpawnPoints.Length - 1; i >= 0; i--)
        {
            Vector3 spawnPos = wallSpawnPoints[i].position;

            //Spawn a wall, parent it to this chuck of track
            Instantiate(wall, spawnPos, Quaternion.identity, transform);
        }

        float rand = Random.Range(0, 5);
        if(rand == 3) SpawnPowerUp(); //each chunk of track has a 20% chance of spawning a powerup
                                      //if (rand == 1 || rand == 2 || rand == 4) 
        SpawnObstacle();
    }

    void Update()
    {
        transform.position += new Vector3(0, 0, -(speed*speedMultiplier)) * Time.deltaTime;

        if (pointOut.position.z < -5)
        {
            isDead = true;
        }
    }

    /// <summary>
    /// Picks a random lane and spawms a powerup
    /// </summary>
    void SpawnPowerUp()
    {
        float rand = Random.Range(-1, 2);
        float xPos = (floor.transform.localScale.x / 4) * rand;
        Vector3 position = new Vector3(xPos, 0, 0) + transform.position;
        Instantiate(powerUp, position, Quaternion.identity, transform);

    }
    void SpawnObstacle()
    {
        float randLane = Random.Range(-1, 2);
        int randObs = Random.Range(0, 9);
        float xPos = (floor.transform.localScale.x / 4) * randLane;
        Vector3 position = new Vector3(xPos, 0, 0) + transform.position;
        Instantiate(obstacles[randObs], position, Quaternion.identity, transform);

    }
}
