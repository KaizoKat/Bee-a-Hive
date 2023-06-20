using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LookAt : MonoBehaviour
{
    [SerializeField] public Vector3 lookAt;
    [SerializeField] public Transform parity;
    Transform combiner;

    void Update()
    {
        if (lookAt == Vector3.zero)
            combiner = parity;
        else if (lookAt != Vector3.zero)
            combiner.position = lookAt; 

        var targetRotation = Quaternion.LookRotation(combiner.position - transform.position);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }
}
