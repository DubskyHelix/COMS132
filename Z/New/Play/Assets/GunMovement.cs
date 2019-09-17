using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5f;

    void Update()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, rotation * rotationSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
