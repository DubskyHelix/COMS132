using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
    private Neighborhood neighborhood;

    void Awake()
    {
        neighborhood = GetComponent<Neighborhood>();
        rigid = GetComponent<Rigidbody>();
        pos = Random.insideUnitSphere * Spawner.S.spawnRadius;

        Vector3 vel = Random.onUnitSphere * Spawner.S.velocity;
        rigid.velocity = vel;

        LookAhead();

        Color randColor = Color.black;
        while(randColor.r + randColor.g + randColor.b < 1.0f)
        {
            randColor = new Color(Random.value, Random.value, Random.value);
        }

        Renderer[] rends = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer r in rends)
        {
            r.material.color = randColor;
        }

        TrailRenderer tRend = GetComponent<TrailRenderer>();
        tRend.material.SetColor("_TintColor", randColor);
    }

    private void LookAhead()
    {
        transform.LookAt(pos + rigid.velocity);
    }

    void FixedUpdate()
    {
        Vector3 vel = rigid.velocity;
        Spawner spn = Spawner.S;

        // COLLISION AVOIDANCE - Avoid neighbors who are too close
        Vector3 velAvoid = Vector3.zero;
        Vector3 tooClosePos = neighborhood.avgClosePos;
        if (tooClosePos != Vector3.zero)
        {
            velAvoid = pos - tooClosePos;
            velAvoid.Normalize();
            velAvoid *= spn.velocity;
        }

        // VELOCITY MATCHING - Try to match velocity with neighbors
        Vector3 velAlign = neighborhood.avgVel;
        if (velAlign != Vector3.zero)
        {
            // We're really interested in direction, so normalize the velocity
            velAlign.Normalize();
            // and then set it to the speed we choose
            velAlign *= spn.velocity;
        }

        // FLOCK CENTERING - Move towards the center of local neighbors
        Vector3 velCenter = neighborhood.avgPos;
        if (velCenter != Vector3.zero)
        {
            velCenter -= transform.position;
            velCenter.Normalize();
            velCenter *= spn.velocity;
        }

        // ATTRACTION - Move towards the attractor
        Vector3 delta = Attractor.POS - pos;
        // Check whether we are attracked or avoiding the Attractor
        bool attracted = delta.magnitude > spn.attactPushDist;
        Vector3 velAttract = delta.normalized * spn.velocity;

        // Apply all the velocities
        float fdt = Time.fixedDeltaTime;
        if (velAvoid != Vector3.zero)
        {
            vel = Vector3.Lerp(vel, velAvoid, spn.collAvoid * fdt);
        }
        else
        {
            if (velAlign != Vector3.zero)
            {
                vel = Vector3.Lerp(vel, velAlign, spn.velMatching * fdt);
            }
            if (velCenter != Vector3.zero)
            {
                vel = Vector3.Lerp(vel, velCenter, spn.flockCentering * fdt);
            }
            if (velAttract != Vector3.zero)
            {
                if (attracted)
                {
                    vel = Vector3.Lerp(vel, velAttract, spn.attractPull * fdt);
                }
                else
                {
                    vel = Vector2.Lerp(vel, -velAttract, spn.attractPush * fdt);
                }
            }
        }

        // Set vel to the velocity on the Spawner singleton
        vel = vel.normalized * spn.velocity;
        // Finally assign this to the Rigidbody
        rigid.velocity = vel;
        // Look in the direction of the new velocity
        LookAhead();
    }

    public Vector3 pos
    {
        get { return transform.position;  }
        set { transform.position = value;  }
    }

    public Rigidbody rigid { get; private set; }
}
