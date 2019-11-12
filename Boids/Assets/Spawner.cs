﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    static public Spawner S;
    static public List<Boid> boids;

    [Header("Spawning")]
    public Boid boidPrefab;
    public Transform boidAnchor;
    public int numBoids = 100;
    public float spawnRadius = 100f;
    public float spawnDelay = 0.1f;

    [Header("Boids")]
    public float velocity = 30f;
    public float neighborDist = 30f;
    public float collDist = 4f;
    public float velMatching = 0.25f;
    public float flockCentering = 0.2f;
    public float collAvoid = 2f;
    public float attractPull = 2f;
    public float attractPush = 2f;
    public float attactPushDist = 5f;

    void Awake()
    {
        S = this;
        boids = new List<Boid>();
    }

    public void InstantiateBoid()
    {   
        if (boids.Count < numBoids)
        {
            Invoke("InstantiateBoid", spawnDelay);
            Boid boid = Instantiate<Boid>(boidPrefab);
            boid.transform.SetParent(boidAnchor);
            boids.Add(boid);
        }
    }

	void Update () {
        InstantiateBoid();
	}
}
