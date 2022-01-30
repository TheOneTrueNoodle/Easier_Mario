using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Transform respawnpoint;
    public CharacterController cc;

    private void Start()
    {
        cc = player.GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("teleepoot");
            cc.enabled = false;
            player.transform.position = respawnpoint.position;
            cc.enabled = true;
        }
    }
}
