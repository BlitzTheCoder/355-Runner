using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to the Player Character
public class PlayerMovement : MonoBehaviour {

    public GameObject floor;

    public int phase = 1;

    float laneWidth = 3;
    int lane = 0;

	void Start () {
        laneWidth = floor.transform.localScale.x/4;
	}


    void Update() {
        float h = Input.GetAxisRaw("Horizontal");
        float targetX = 0;
        float x = 0;
        float velocityX = 10;

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
        targetX = lane * laneWidth;

        x = (targetX - transform.position.x) * .1f;

        if (phase == 1)
        {
            transform.position += new Vector3(x, 0, 0);
        } else if (phase == 2)
        {
            while (Input.GetButtonDown("Horizontal"))
            {
                velocityX *= h;
                transform.position += new Vector3(velocityX, 0, 0);
            }
            //transform.position += new Vector3(x, 0, 0);

        } else if (phase >= 3)
        {

            transform.position += new Vector3(x, 0, 0);
        }
        



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
