using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTheLEg : MonoBehaviour
{
    [SerializeField] Inventory inv;
    [SerializeField] GameObject Leg;

    public void DoStuff()
    {
        inv.item2 = true;

        Destroy(Leg);
    }
}
