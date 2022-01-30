using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePause : MonoBehaviour
{
    public bool paused; //do we be paused rn
    public GameObject pauseScreen; //the pause screen canvas object
    public static GameObject instance;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this.gameObject;
        }

        DontDestroyOnLoad(this.gameObject);

    }


    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }
    }

    public void Pause()  //for the Resume button
    {
        paused = true;
    }

    public void Resume()  //for the Resume button
    {
        paused = false;
    }

}
