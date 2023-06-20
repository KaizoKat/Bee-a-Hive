using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishUIAnination : MonoBehaviour
{
    [SerializeField] Animator anima;
    void fin()
    {
        anima.SetBool("anim", false);
    }
}
