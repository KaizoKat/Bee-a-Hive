using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveBee : MonoBehaviour
{
    [SerializeField] Transform positioner;

    int speed = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed *= 2;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed /= 2;

        if (Vector3.Distance(transform.position, positioner.transform.position) > 1)
            transform.position = Vector3.Slerp(transform.position, positioner.transform.position, speed * Time.deltaTime);
    }
}
