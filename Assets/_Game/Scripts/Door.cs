using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Platform platform;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(ConstString.PLAYER_TAG))
        {
            platform.SpawnBrick();
        }
    }
}
