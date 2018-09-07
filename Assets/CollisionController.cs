using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Apply This Script to the Main Camera
public class CollisionController : MonoBehaviour {

    static private List<aabbCollision> aabbs = new List<aabbCollision>();

    static public void Add(aabbCollision obj)
    {
        aabbs.Add(obj);
    }
    static public void Remove(aabbCollision obj)
    {
        aabbs.Remove(obj);
        //print("there are " + aabbs.Count + " AABBS registered.");
    }

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }
    void LateUpdate()
    {
        foreach(aabbCollision a in aabbs)
        {
            foreach(aabbCollision b in aabbs)
            {
                if (a == b) continue;
                if (a.isDoneChecking || b.isDoneChecking) continue;

                if (a.CheckOverlap(b))
                {
                    // overlapping!!
                    a.BroadcastMessage("OverlappingAABB", b); // observer 
                    b.BroadcastMessage("OverlappingAABB", a);
                }
            }
            a.isDoneChecking = true;
        }
    }
}
