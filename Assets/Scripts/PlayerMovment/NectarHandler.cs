using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NectarHandler : MonoBehaviour
{
    [SerializeField] public float polen;
    [SerializeField] public float Honney;
    [SerializeField] ParticleSystem particles;
    [SerializeField] TextMeshProUGUI polenDisplay;
    [SerializeField] TextMeshProUGUI honneyDisplay;

    ParticleSystem.EmissionModule particlesEmi;
    ParticleSystem.VelocityOverLifetimeModule particlesVOL;
    bool collecting;
    int flowerCount;

    string Leters;
    string Kilograms;

    string Polen_n;
    string Honney_n;

    private void Start()
    {
        particlesEmi = particles.emission;
        particlesVOL = particles.velocityOverLifetime;
    }
    private void Update()
    {
        if (flowerCount > 1)
            collecting = true;
        else
            collecting = false;

        if (collecting == true)
        {
            particles.Play();
            particlesEmi.rateOverTime = flowerCount * 10;
        }
        else
        {
            particles.Stop();
        }

        if (polen < 0)
            polen = 0;

        SetWeights();

        polenDisplay.text = Polen_n + Kilograms;
        honneyDisplay.text = Honney_n + Leters;
    }

    void SetWeights()
    {
        switch (polen)
        {
            case <= 999:
                Kilograms = " g";
                Polen_n = Mathf.FloorToInt(polen).ToString();
                break;

            case <= 999999:
                Polen_n = Mathf.FloorToInt(polen / 1000).ToString();
                Kilograms = " Kg";
                break;

            case <= 999999999:
                Kilograms = " Mg";
                Polen_n = Mathf.FloorToInt(polen / 1000000).ToString();
                break;

            case <= 999999999999:
                Kilograms = " Gg";
                Polen_n = Mathf.FloorToInt(polen / 1000000000).ToString();
                break;

            case <= 999999999999999:
                Kilograms = " Tg";
                Polen_n = Mathf.FloorToInt(polen / 1000000000000).ToString();
                break;

            case <= 999999999999999999:
                Kilograms = " Yg";
                Polen_n = Mathf.FloorToInt(polen / 1000000000000000).ToString();
                break;

            case <= 9999999999999999999:
                Kilograms = " INF";
                Polen_n = Mathf.FloorToInt(polen / 10000000000000000).ToString();
                break;
        }

        switch (Honney)
        {
            case <= 999:
                Leters = " l";
                Honney_n = Mathf.FloorToInt(Honney).ToString();
                break;

            case <= 999999:
                Honney_n = Mathf.FloorToInt(Honney / 1000).ToString();
                Leters = " Kl";
                break;

            case <= 999999999:
                Leters = " Ml";
                Honney_n = Mathf.FloorToInt(Honney / 1000000).ToString();
                break;

            case <= 999999999999:
                Leters = " Gl";
                Honney_n = Mathf.FloorToInt(Honney / 1000000000).ToString();
                break;

            case <= 999999999999999:
                Leters = " Tl";
                Honney_n = Mathf.FloorToInt(Honney / 1000000000000).ToString();
                break;

            case <= 999999999999999999:
                Leters = " Yl";
                Honney_n = Mathf.FloorToInt(Honney / 1000000000000000).ToString();
                break;

            case <= 9999999999999999999:
                Leters = " INF";
                Honney_n = Mathf.FloorToInt(Honney / 10000000000000000).ToString();
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Flower")
        {
            flowerCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Flower")
        {
            flowerCount--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.transform.tag == "Flower")
        {
            polen += 0.0003f * flowerCount;
        }

        if (other.transform.tag == "Honeycomb")
        {
            if(polen > 0)
            {
                polen -= 0.03f;
                Honney += 0.03f;

                particlesVOL.radial = -5;
                flowerCount = 10;
            }
            else
            {
                particlesVOL.radial = 5;
                flowerCount = 0;
            }
        }
    }
}
