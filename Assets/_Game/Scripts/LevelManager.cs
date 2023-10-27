using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Player player;
    [SerializeField] private Transform startPos;
    [SerializeField] private List<Transform> spawnPoint = new List<Transform>();
    [SerializeField] private List<Transform> spawnPointState2= new List<Transform>();
    [SerializeField] private GameObject brickPrefab;

    private void Start()
    {
        player.transform.position = startPos.transform.position;
        SpawnBrick();
    }
    public void SpawnBrick()
    {

        for (int i = 0; i < spawnPoint.Count; i++)
        {
            Instantiate(brickPrefab, spawnPoint[i].position, brickPrefab.transform.rotation);
        }

    }

    public void SpawnBrickState2()
    {
        for (int i = 0; i < spawnPoint.Count; i++)
        {
            Instantiate(brickPrefab, spawnPointState2[i].position, brickPrefab.transform.rotation);
        }
    }
}
