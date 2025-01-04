using System.Collections;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform spawnPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.transform.position = spawnPoint.position;
        }
    }
}