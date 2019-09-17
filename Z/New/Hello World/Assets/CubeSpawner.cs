using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject cubePrefabVar;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< HEAD
        Instantiate(cubePrefabVar);
=======
        //Instantiate(cubePrefabVar);
>>>>>>> f7df6143a1875f02efdccac4b6e069034ede29d9
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(cubePrefabVar);
    }
}
