using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movemnt : MonoBehaviour
{
    [SerializeField] private Animator anima;
    [SerializeField] private Transform player;
    [SerializeField] public byte HP = 100;

    bool walk;
    bool attack;
    bool die;

    bool waiting;
    void Update()
    {
        if(waiting == false)
        {
            if (Vector3.Distance(transform.position, player.position) > 150)
            {
                walk = true;
            }
            else if (Vector3.Distance(transform.position, player.position) <= 100)
            {
                walk = false;
                if (Random.Range(0, 20) == 20 && attack == false)
                {
                    attack = true;
                }
                else
                {
                    attack = false;
                }
            }

            if (HP == 0)
            {
                die = true;
            }
            StartCoroutine(CompleteTasks());
        }

    }

    IEnumerator CompleteTasks()
    {
        waiting = true;
        if(walk == true)
        {
            anima.SetBool("Walk", true);
            transform.position += Vector3.forward * 4;
            yield return new WaitForSeconds(3);
            anima.SetBool("Walk", false);
            waiting = false;
            StopAllCoroutines();
        }

        if(attack == true)
        {
            anima.SetBool("Attack", true);
            Vector3 plPos = player.transform.position;
            yield return new WaitForSeconds(3);
            anima.SetBool("Attack", false);
            if (Vector3.Distance(plPos,player.transform.position) <= 5)
            {
                Debug.Log("Dammage!");
            }
            waiting = false;
            StopAllCoroutines();
        }

        if(die == true)
        {
            anima.SetBool("Die", true);
            yield return new WaitForSeconds(3);
        }
    }
}
