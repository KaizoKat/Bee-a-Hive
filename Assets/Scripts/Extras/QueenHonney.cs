using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenHonney : MonoBehaviour
{
    [SerializeField] NectarHandler honneyInator;
    [SerializeField] GameObject otherPannel;
    [SerializeField] GameObject myPannel;
    [SerializeField] Inventory inv;

    bool hha = false;

    private void FixedUpdate()
    {
        if (honneyInator.Honney >= 1 && hha == false)
        {
            hha = true;
            otherPannel.SetActive(false);
            myPannel.SetActive(true);
            StartCoroutine(killTheQueen());
        }
    }

    public void RemoveHonney()
    {
        honneyInator.Honney = 0;
    }

    IEnumerator killTheQueen()
    {
        yield return new WaitForSeconds(60);
        Destroy(transform.parent.gameObject);
    }

    byte clicks;
    public void Click()
    {
        clicks++;

        if (clicks == 6)
            inv.item1 = true;
    }
}
