using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bee : MonoBehaviour
{

    public bool HaveBee = false;
    public GameObject heart;
    public GameObject BeeToy;
    public GameObject PleaseHelp;
    public GameObject thankYouText;
    public GameObject thankYouText2;
    private IEnumerator coroutine;

    

    // Start is called before the first frame update
    void Start()
    {
        HaveBee = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (HaveBee == true)
        {
         
            PleaseHelp.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bee")
        {
            HaveBee = true;
            Destroy(other.gameObject);
        }

        if (other.tag == "Child" & HaveBee == true)
        {
            heart.SetActive(true);
            thankYouText.SetActive(true);
            BeeToy.SetActive(true);
            StartCoroutine(coroutineB());


        }

        IEnumerator coroutineA()
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Jaga Test Scene");
        }
        IEnumerator coroutineB()
        {
            yield return new WaitForSeconds(3.0f);
            thankYouText.SetActive(false);
            thankYouText2.SetActive(true);
            StartCoroutine(coroutineA());
        }


    }


}
