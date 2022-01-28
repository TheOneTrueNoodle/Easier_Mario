using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] public string scenename;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAAAA");
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName: scenename);
        }
    }
}
