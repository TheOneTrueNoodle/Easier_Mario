using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resurntomainmenu : MonoBehaviour
{
    [SerializeField] public string scenename;
    public GameObject destroy;

    public void mainmenu()
    {
        SceneManager.LoadScene(sceneName: scenename);
    }
}
