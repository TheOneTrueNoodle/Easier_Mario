using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Respawn script = FindObjectOfType<Respawn>();
            script.respawnpoint = this.transform;
        }
    }
}
