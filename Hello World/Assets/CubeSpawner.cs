using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;



    void Start()
    {
        Instantiate (cubePrefabVar);


    }

    
    void Update()
    {
        Instantiate(cubePrefabVar);
    }
}
