using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Add Brick Info")]
    public List<Transform> playerBrickList;
    [SerializeField] private Transform playerBrickPrefab;
    [SerializeField] private Transform brickHolder;

    [Header("Color Player Info")]
    [SerializeField] private Material[] colorPlayer;
    public ColorData colorPlayerData;
    [SerializeField] private MeshRenderer renderPlayer;


    private void Start()
    {
        //EnnableJoystickInput();
        SetColor(colorPlayerData);
    }
    public void AddBrick()
    {
        int index = playerBrickList.Count;

        Transform brickSpawn = Instantiate(playerBrickPrefab, brickHolder);
        playerBrickList.Add(brickSpawn);

        brickSpawn.localPosition = index * 0.4f * Vector3.up;
    }

    public void RemoveBrick()
    {
        int index = playerBrickList.Count - 1;
        Transform brickSpawn = playerBrickList[index];

        if (playerBrickList.Count >= 0)
        {
            playerBrickList.Remove(brickSpawn);
            Destroy(brickSpawn.gameObject);
        }
    }

    private void SetColor(ColorData colorData)
    {
        int index = (int)colorData;
        renderPlayer.material = colorPlayer[index];
    }
}

