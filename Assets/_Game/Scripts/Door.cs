using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Platform platform;
    [SerializeField] private Door door;
    private bool isCollect = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(ConstString.PLAYER_TAG) && !isCollect)
        {
            Character character = other.GetComponent<Character>();
            character.currentPlatform = platform;
            platform.SpawnBrick(character.colorPlayerData);
            isCollect = true;
        }
    }

    
}
