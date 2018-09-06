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
}
