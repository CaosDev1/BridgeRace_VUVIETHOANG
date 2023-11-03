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

    public void SpawnBrick(ColorData colorType)
    {
        if(emtpyPos.Count >= 0) 
        {
            for (int i = emtpyPos.Count - 1; i >= 0; i--)
            {
                Brick brick = Instantiate(brickPrefab, emtpyPos[i], Quaternion.identity);
                brickPrefab.SetColor(colorType);
                emtpyPos.RemoveAt(i);
            }
        }
    }

    public void EmtyPos(Vector3 brickPos)
    {
        emtpyPos.Add(brickPos);
    }

    
    

}
