using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Bools")]
    [SerializeField] public bool item1;
    [SerializeField] public bool item2;
    [SerializeField] public bool item3;
    [SerializeField] public bool item4;
    [SerializeField] public bool item5;
    [SerializeField] public bool item6;

    [Header("Slots")]
    [SerializeField] RawImage slot1;
    [SerializeField] RawImage slot2;
    [SerializeField] RawImage slot3;
    [SerializeField] RawImage slot4;
    [SerializeField] RawImage slot5;
    [SerializeField] RawImage slot6;

    [Header("Texture Images")]
    [SerializeField] Texture image1;
    [SerializeField] Texture image2;
    [SerializeField] Texture image3;
    [SerializeField] Texture image4;
    [SerializeField] Texture image5;
    [SerializeField] Texture image6;

    Animator anima1;
    Animator anima2;
    Animator anima3;
    Animator anima4;
    Animator anima5;
    Animator anima6;

    private void Start()
    {
        anima1 = slot1.gameObject.transform.parent.GetComponent<Animator>();
        anima2 = slot2.gameObject.transform.parent.GetComponent<Animator>();
        anima3 = slot3.gameObject.transform.parent.GetComponent<Animator>();
        anima4 = slot4.gameObject.transform.parent.GetComponent<Animator>();
        anima5 = slot5.gameObject.transform.parent.GetComponent<Animator>();
        anima6 = slot6.gameObject.transform.parent.GetComponent<Animator>();

    }

    void Update()
    {
        if (item1)
        {
            slot1.texture = image1;
            anima1.SetBool("active", true);
        }


        if (item2)
        {
            slot2.texture = image2;
            anima2.SetBool("active", true);
        }

        if (item3)
        {
            slot3.texture = image3;
            anima3.SetBool("active", true);
        }

        if (item4)
        {
            slot4.texture = image4;
            anima4.SetBool("active", true);
        }

        if (item5)
        {
            slot5.texture = image5;
            anima5.SetBool("active", true);
        }

        if (item6)
        {
            slot6.texture = image6;
            anima6.SetBool("active", true);
        }
    }
}
