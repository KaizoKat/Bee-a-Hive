using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;

    Vector3 direction;
    int VerticalDirection;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            VerticalDirection = 1;
        else if (Input.GetKey(KeyCode.LeftControl))
            VerticalDirection = -1;
        else
            VerticalDirection = 0;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Speed *= 2;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            Speed /= 2;

        direction = new Vector3(Input.GetAxisRaw("Horizontal"), VerticalDirection, Input.GetAxisRaw("Vertical"));
        rb.AddForce(direction * Speed, ForceMode.Force);
    }
}
