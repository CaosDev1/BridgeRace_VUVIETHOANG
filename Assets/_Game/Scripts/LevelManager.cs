using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Transform startPos;

    private void Start()
    {
        player.transform.position = startPos.position;
    }

}
