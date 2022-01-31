using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePause : MonoBehaviour
{
    public bool paused; //do we be paused rn
    public GameObject pauseScreen; //the pause screen canvas object
    public static GameObject instance;
    public bool unstarted = true;

    private GameObject Player;


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

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindGameObjectWithTag("Player");


        if (paused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
            Player.GetComponent<Third_Person_Movement>().enabled = false;
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
            if (!unstarted)
            {
                Player.GetComponent<Third_Person_Movement>().enabled = true;
            }
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

    public void Startit()
    {
        unstarted = false;
    }
}
