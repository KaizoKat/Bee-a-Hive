using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LouisChangeTExt : MonoBehaviour
{
    [SerializeField] Inventory inv;

    [SerializeField] GameObject textBox1;
    [SerializeField] GameObject textBox2;
    [SerializeField] byte clicks;
    [SerializeField] DialogueManager dm;

    bool check;
    void Update()
    {
        if(inv.item2 == true && check == false)
        {
            textBox1.SetActive(false);
            textBox2.SetActive(true);
            check = true;
        }
        else
        {
            textBox1.SetActive(false);
            textBox2.SetActive(true);
        }

        if (clicks == 4)
            dm.writeSpeed = 0.06f;
        if (clicks == 7)
            dm.writeSpeed = 0.2f;
    }

    
    public void Click()
    {
        clicks++;
    }
}
