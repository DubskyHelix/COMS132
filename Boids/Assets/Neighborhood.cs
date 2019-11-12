using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neighborhood : MonoBehaviour
{
    private List<Boid> neighbors;
    private SphereCollider coll;

    void Awake()
    {
        neighbors = new List<Boid>();
        coll = GetComponent<SphereCollider>();
        coll.radius = Spawner.S.neighborDist / 2f;
    }

    void FixedUpdate()
    {
        coll.radius = Spawner.S.neighborDist / 2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Boid b = other.GetComponent<Boid>();
        if (b && !neighbors.Contains(b))
        {
            neighbors.Add(b);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Boid b = other.GetComponent<Boid>();
        if (b && neighbors.Contains(b))
        {
            neighbors.Remove(b);
        }
    }

    public Vector3 avgPos
    {
        get
        {
            Vector3 avg = Vector3.zero;
            if (neighbors.Count > 0)
            {
                foreach (Boid b in neighbors)
                {
                    avg += b.pos;
                }
                avg /= neighbors.Count;
            }
            return avg;
        }
    }

    public Vector3 avgVel
    {
        get
        {
            Vector3 avg = Vector3.zero;
            if (neighbors.Count > 0)
            {
                foreach (Boid b in neighbors)
                {
                    avg += b.rigid.velocity;
                }
                avg /= neighbors.Count;
            }
            return avg;
        }
    }

    public Vector3 avgClosePos
    {
        get
        {
            Vector3 avg = Vector3.zero;
            int nearCount = 0;
            if (neighbors.Count > 0)
            {
                foreach (Boid b in neighbors)
                {
                    Vector3 delta = b.pos - transform.position;
                    if (delta.magnitude <= Spawner.S.collDist)
                    {
                        avg += b.pos;
                        nearCount++;
                    }
                }
                if (nearCount > 0)
                {
                    avg /= nearCount;
                }
            }
            return avg;
        }
    }
}
