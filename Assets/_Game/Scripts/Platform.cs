using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform[] spawnPoint;
    [SerializeField] private GameObject brickPrefab;

    public void SpawnBrick()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            Instantiate(brickPrefab, spawnPoint[i].position, Quaternion.identity);
        }
    }
}
