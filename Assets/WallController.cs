using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

    const float speed = -10;
    public float posZ = 0;
    Vector3 vector;


    void Start () {
		
	}
	
	void Update () {


        transform.position += new Vector3(0, 0, speed) * Time.deltaTime;

        if (transform.position.z <= -20)
        {
            Destroy(gameObject);
        }
        

    }
}
