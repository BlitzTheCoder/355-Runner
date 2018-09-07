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

    void Update()
    {
        transform.position += new Vector3(0, Mathf.Sin(Time.time*speed), 0) * Time.deltaTime;
        transform.Rotate(0, rotSpeed * Time.deltaTime, 0, Space.World);
    }
}
