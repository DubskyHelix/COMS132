using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit coin");
        if (other.gameObject.tag == "Projectile")
        {
            Material mat = GetComponent<Renderer>().material;
            Debug.Log("hi");
            Destroy(gameObject);

            MissionDemolition.CoinGotten();
        }
    }


    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

}