using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bot : MonoBehaviour
{
    [SerializeField] private ColorData botColor;
    [SerializeField] private float moveSpeed;
    private void Update()
    {
        List<Transform> target = LevelManager.Instance.spawnPoint;

        transform.position = Vector3.MoveTowards(transform.position, target[1].position, moveSpeed * Time.deltaTime);
    }
}
    
