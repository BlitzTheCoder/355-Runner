﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public Track prefabTrack;

    public float trackLength = 5;

    float elapsedTime = 0;

    public float targetTime = 10;


    List<Track> tracks = new List<Track>();

    void Start()
    {
        SpawnSomeTrack();
    }

    void Update()
    {

        for (int i = tracks.Count - 1; i >= 0; i--)
        {
            if (tracks[i].isDead)
            {
                Destroy(tracks[i].gameObject);
                tracks.RemoveAt(i);
            }
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime >= targetTime && Track.speedMultiplier != 4)
        {
            Speedup();
            print("Speed Up!");
        } else if(Track.speedMultiplier == 4)
        {
            print("Speed at Max!");
        }

        //print(elapsedTime);

    }
    void SpawnSomeTrack()
    {
        while (tracks.Count < trackLength)
        {
            Vector3 ptOut = Vector3.zero;

            if (tracks.Count > 0) ptOut = tracks[tracks.Count - 1].pointOut.position;

            Vector3 ptIn = prefabTrack.pointIn.position;

            Vector3 pos = (prefabTrack.transform.position - ptIn) + ptOut;

            Track newTrack = Instantiate(prefabTrack, pos, Quaternion.identity);

            tracks.Add(newTrack);
        }
    }
    void Speedup()
    {

        Track.speedMultiplier += 1;

        elapsedTime = 0;
    }
    void LateUpdate()
    {
        if (tracks.Count < trackLength) SpawnSomeTrack(); //Called as a Late Update to avoid creating gaps between tracks

    }
}
