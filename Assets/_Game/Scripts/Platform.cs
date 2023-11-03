using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform[] spawnPoint;
    public List<Vector3> emtpyPos = new List<Vector3>();
    [SerializeField] private Brick brickPrefab;

    private void Start()
    {
        for (int i = 0; i < spawnPoint.Length; i++)
        {
            emtpyPos.Add(spawnPoint[i].position);
        }
    }

    public void SpawnBrick()
    {
        for (int i = emtpyPos.Count - 1; i >= 0; i--)
        {
            Brick brick = Instantiate(brickPrefab, emtpyPos[i], Quaternion.identity);
            emtpyPos.RemoveAt(i);
        }
    }

    public void AddEmtyPos(Vector3 postion)
    {
        emtpyPos.Add(postion);
    }


}
