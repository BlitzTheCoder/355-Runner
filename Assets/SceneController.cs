using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject prefabObstacle;
    public GameObject prefabWall;
    private List<GameObject> walls = new List<GameObject>();
    float delayUntilSpawn = 0;
    

	void Start () {
        for (int i = walls.Count; i <= 9; i++)
        {
            //walls.Add(prefabWall);
            float nextWallZ = i * 15f;
            Vector3 pos = new Vector3(-7, 0, (nextWallZ + 20));
            GameObject wall = Instantiate(walls[i], pos, Quaternion.identity);
            walls.Add(wall);

        }
    }
	
	// Update is called once per frame
	void Update () {
        print(walls.Count);
        delayUntilSpawn -= Time.deltaTime;
        if (delayUntilSpawn <= 0)
        {
            Vector3 pos = new Vector3(0, 0, 20);
            Instantiate(prefabObstacle, pos, Quaternion.identity);
            delayUntilSpawn = Random.Range(1, 3);
        }
        
        for (int i = walls.Count -1; i>=0; i--)
        {
            if (walls[i].gameObject == null)
            {
                walls.RemoveAt(i);

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
