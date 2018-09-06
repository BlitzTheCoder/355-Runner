using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject prefabObstacle;
    public GameObject prefabWall;
    private List<GameObject> prefabWalls = new List<GameObject>();
    float delayUntilSpawn = 0;
    

	void Start () {
        for (int i = prefabWalls.Count; i <= 9; i++)
        {
            prefabWalls.Add(prefabWall);
            float nextWallZ = i * 15f;
            Vector3 pos = new Vector3(-7, 0, (nextWallZ + 20));
            Instantiate(prefabWalls[i], pos, Quaternion.identity);
        }
    }
	
	// Update is called once per frame
	void Update () {
        print(prefabWalls.Count);
        delayUntilSpawn -= Time.deltaTime;
        if (delayUntilSpawn <= 0)
        {
            Vector3 pos = new Vector3(0, 0, 20);
            Instantiate(prefabObstacle, pos, Quaternion.identity);
            delayUntilSpawn = Random.Range(1, 3);
        }
        
        for (int i = prefabWalls.Count -1; i>=0; i--)
        {
            if (prefabWalls[i].gameObject == null)
            {
                prefabWalls.RemoveAt(i);

                //prefabWalls[i].transform.position = new Vector3(-7, 0, (i*15) + 20);
            }
        }
        /*if(prefabWalls.Count <= 9)
        {
            prefabWalls.Add(prefabWall);
            //float nextWallZ = 9 * 15f;
            Vector3 pos = new Vector3(-7, 0, 170);
            Instantiate(prefabWalls[9], pos, Quaternion.identity);

        }*/
    }
}
