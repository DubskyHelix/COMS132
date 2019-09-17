using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float absX = 10, absY = 5;
    [SerializeField] float maxDistanceDelta = 0.1f;

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-absX, absX);
        float y = Random.Range(-absY, absY);

        transform.position = new Vector3(x, y);

        x = Random.Range(-absX, absX);
        y = Random.Range(-absY, absY);

        target = new Vector3(x, y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, target) < Mathf.Epsilon)
        {
            float x = Random.Range(-absX, absX);
            float y = Random.Range(-absY, absY);

            target = new Vector3(x, y);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, maxDistanceDelta);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
