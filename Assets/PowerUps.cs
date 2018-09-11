using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {
    public enum Type // PowerUp.Type
    {
        None,
        Slowmo,
        Health,
        JetpackBoost
    }

    public Type type;

    

    float speed = 5;
    float rotSpeed = 100;

    void Start()
    {
        float rand = Random.Range(0, 3);

        if (rand == 0)
        {
            type = Type.Slowmo;
        }
        else if (rand == 1)
        {
            type = Type.Health;
        }
        else
        {
            type = Type.JetpackBoost;
        }

        //print(rand);
        //print("I am a " + type);

    }

    void Update()
    {
        transform.position += new Vector3(0, Mathf.Sin(Time.time*speed), 0) * Time.deltaTime;
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
    }
}
