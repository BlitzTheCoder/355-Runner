using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aabbCollision : MonoBehaviour {

    public Vector3 halfSize;

    MeshRenderer _mesh; //C# field

    public MeshRenderer mesh // C# property
    {
        get
        {
            if (!_mesh) _mesh = GetComponent<MeshRenderer>(); // "lazy" initialization
            return _mesh;
        }
    }
    public Bounds bounds
    {
        get
        {
            return mesh.bounds;
        }
    }

    [HideInInspector] public bool isDoneChecking = false;

    bool isOverlapping = false;
	void Start () {

        CollisionController.Add(this);

	}
    void OnDestroy()
    {
        CollisionController.Remove(this);
    }
	
	
	void Update () {
        isDoneChecking = false;
        isOverlapping = false;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = isOverlapping ? Color.red : Color.white;
        Gizmos.DrawWireCube(transform.position, mesh.bounds.size);
    }
    [HideInInspector]
    /// <summary>
    /// Checks to see if some other AABB overlaps this AABB.
    /// </summary>
    /// <param name="other">The AABB component to check against.</param>
    /// <returns></returns> if True, the two AABBs overlap.
    /// 
    public bool CheckOverlap(aabbCollision other)
    {

        if (other.bounds.min.x > this.bounds.max.x) return false;
        if (other.bounds.max.x < this.bounds.min.x) return false;

        if (other.bounds.min.y > this.bounds.max.y) return false;
        if (other.bounds.max.y < this.bounds.min.y) return false;

        if (other.bounds.min.z > this.bounds.max.z) return false;
        if (other.bounds.max.z < this.bounds.min.z) return false;


        return true;
    }

    void OverlappingAABB(aabbCollision other)
    {
        isOverlapping = true;
    }
}
