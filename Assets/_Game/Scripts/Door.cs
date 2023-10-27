using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private BoxCollider doorBox;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(ConstString.PLAYER_TAG))
        {
            GameManager.Instance.ChangeStage(GameState.State2);
            Invoke(nameof(ColoseDoor), 0.3f);
            LevelManager.Instance.SpawnBrickState2();
        }
    }

    private void ColoseDoor()
    {
        doorBox.isTrigger = false;
    }
}
