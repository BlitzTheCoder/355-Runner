using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the Player Character
public class PlayerMovement : MonoBehaviour {

    float laneWidth = 3;
    int lane = 0;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Horizontal"))
        {

            //print("I'm down");
            if (h == -1) // if pressing left
            {
                lane--;
            }
            else if (h == 1) // if pressing right
            {
                lane++;
            }
            lane = Mathf.Clamp(lane, -1, 1);
        }

        float targetX = lane * laneWidth;

        float x = (targetX - transform.position.x) * .1f;
        transform.position += new Vector3(x, 0, 0);



	}

    void OverlappingAABB (aabbCollision other)
    {
        

        if (other.tag == "Powerup")
        {
            // it must be a powerup...
            PowerUps powerup = other.GetComponent<PowerUps>();
            switch (powerup.type)
            {
                case PowerUps.Type.None:
            break;
                case PowerUps.Type.Slowmo:
                    break;
                case PowerUps.Type.Health:
                    break;
                case PowerUps.Type.JetpackBoost:
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
