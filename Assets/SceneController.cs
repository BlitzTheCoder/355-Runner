using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject prefabObstacle;
    public GameObject prefabWall;
    private List<GameObject> prefabWalls = new List<GameObject>();
    float delayUntilSpawn = 0;
    float wallTimer = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delayUntilSpawn -= Time.deltaTime;
        wallTimer -= Time.deltaTime;
        if (delayUntilSpawn <= 0)
        {
            Vector3 pos = new Vector3(0, 0, 20);
            Instantiate(prefabObstacle, pos, Quaternion.identity);
            delayUntilSpawn = Random.Range(1, 3);
        }

        for (int i = prefabWalls.Count; i < 10; i++)
        {
            float nextWallZ = prefabWalls[i].transform.position.z * 7.5f;
            Vector3 pos = new Vector3(-7, 0, nextWallZ + 20);
            prefabWalls.Add(prefabWall);
            Instantiate(prefabWalls[i], pos, Quaternion.identity);
            wallTimer = 1;
        }
    }
}
