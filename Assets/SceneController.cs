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
            prefabWalls.Add(prefabWall);
            float nextWallZ = i * 15f;
            Vector3 pos = new Vector3(-7, 0, (nextWallZ + 20));
            Instantiate(prefabWalls[i], pos, Quaternion.identity);
        }
        for (int i = prefabWalls.Count -1; i>0; i--)
        {
            if (prefabWalls[i].transform.position.z < -20)
            {
                prefabWalls[i].gameObject.Destroy(gameObject);
                prefabWalls.RemoveAt(i);
            }
        }
    }
}
