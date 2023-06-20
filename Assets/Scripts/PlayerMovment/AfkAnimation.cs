using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfkAnimation : MonoBehaviour
{
    [SerializeField] Animator anima;
    [SerializeField] int waitTime;
    [SerializeField] int timer;
    [SerializeField] Rigidbody player;

    bool waiting;
    Quaternion startRot;
    private void Start()
    {
        startRot = transform.parent.transform.rotation;
    }
    void Update()
    {
        if (!Input.anyKey && waiting == false)
            StartCoroutine(Seconds());
        else if(Input.anyKey)
            timer = 0;
        else
            StopCoroutine(Seconds());
        
        if(timer == 10)
        {
            player.AddForce(Vector3.forward * 5, ForceMode.Force);
        }

        if(timer >= waitTime)
        {
            anima.SetBool("isAfk", true);
        }

        if(anima.GetBool("isAfk") == true)
        {
            timer = 0;
            StopCoroutine(Seconds());
        }
    }

    IEnumerator Seconds()
    {
        waiting = true;
        yield return new WaitForSeconds(1);
        timer++;
        waiting = false;
    }

    void Finnish()
    {
        anima.SetBool("isAfk", false);
        timer = 0;
    }
}
