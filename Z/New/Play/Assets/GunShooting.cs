using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    [SerializeField] GameObject prefabBullet;
    [SerializeField] float bulletOffset = 1f;
    [SerializeField] float bulletForce = 1000f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(prefabBullet, transform.position + transform.up * bulletOffset, Quaternion.identity);
            Rigidbody rigid = bullet.GetComponent<Rigidbody>();
            rigid.AddForce(transform.up * bulletForce);
        }
    }
}
