using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Player player;
    [SerializeField] private Transform startPos;
    

    private void Start()
    {
        player.transform.position = startPos.transform.position;
    }
    
}
