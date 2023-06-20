using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoundSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Spawnables;
    [SerializeField] float Ammounts;
    [SerializeField] Transform player;
    [SerializeField] LayerMask spawnableLayer;
    [SerializeField] Vector3 area;

    bool done;
    byte counter;
    void Update()
    {
        if(Vector3.Distance(transform.position,player.position) < 600 && done == false)
        {
            if (counter <= 10)
            {
                for (int i = 0; i < Ammounts; i++)
                {
                    Vector3 pos = new Vector3(transform.position.x + Random.Range(-area.x, area.x), 499, transform.position.z + Random.Range(-area.z, area.z));
                    Instantiate(Spawnables[Random.Range(0, Spawnables.Length)], pos, Quaternion.identity, transform.parent);
                }

                foreach (Transform child in transform.parent)
                {
                    if (child.tag == "Flower")
                    {
                        RaycastHit hit;
                        child.gameObject.transform.localEulerAngles = new Vector3(-90, 180, 0);

                        if (Physics.Raycast(child.transform.position, -child.transform.forward, out hit, 1000))
                            child.gameObject.transform.position = hit.point;
                    }
                }
            }
            else if (counter <= 10)
            {
                counter++;
            }
            else
            {
                counter = 0;
            }

            done = true;
        }
        
        if(Vector3.Distance(transform.position, player.position) >= 600)
        {
            foreach (Transform child in transform.parent)
            {
                if(counter <= 10)
                {
                    if (child.tag == "Flower")
                    {
                        Destroy(child.gameObject);
                        counter++;
                    }
                }
                else if(counter <= 10)
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
            }
            done = false;
        }

    }
}
