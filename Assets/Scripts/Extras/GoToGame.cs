using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToGame : MonoBehaviour
{
    [SerializeField] Animator anima;

    bool play;
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            SceneManager.LoadScene(0);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if(anima != null)
            {
                anima.SetBool("anim", true);
                play = true;
            }
            else
                SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.F4))
            Screen.fullScreen = !Screen.fullScreen;

        if(play == true && anima.GetBool("anim") == false)
            SceneManager.LoadScene(1);
    }
}
