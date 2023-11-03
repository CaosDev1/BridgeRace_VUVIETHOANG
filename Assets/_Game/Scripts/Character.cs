using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    

    [Header("Add Brick Info")]
    public List<PlayerBrick> playerBrickList;
    [SerializeField] private PlayerBrick playerBrickPrefab;
    [SerializeField] private Transform brickHolder;

    [Header("Color Player Info")]
    [SerializeField] private Material[] colorPlayer;
    public ColorData colorPlayerData;
    [SerializeField] private MeshRenderer renderPlayer;

    public int brickCount => playerBrickList.Count;
    public Platform currentPlatform;
    public Vector3 goalPos;
    
    protected virtual void Start()
    {
        //EnnableJoystickInput();
        SetColor(colorPlayerData);
    }
    public void AddBrick()
    {
        int index = playerBrickList.Count;

        PlayerBrick playerBrick = Instantiate(playerBrickPrefab, brickHolder);
        playerBrick.SetColor(colorPlayerData);
        
        playerBrickList.Add(playerBrick);

        playerBrick.transform.localPosition = index * 0.4f * Vector3.up;
    }

    public void RemoveBrick()
    {
        int index = playerBrickList.Count - 1;
        PlayerBrick playerBrick = playerBrickList[index];

        if (playerBrickList.Count >= 0)
        {
            playerBrickList.Remove(playerBrick);
            Destroy(playerBrick.gameObject);
        }
    }

    private void SetColor(ColorData colorData)
    {
        int index = (int)colorData;
        renderPlayer.material = colorPlayer[index];
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.BRICK_TAG))
        {
            Brick brick = other.GetComponent<Brick>();
            if (colorPlayerData == brick.colorData)
            {
                AddBrick();
                brick.OnDespawn();
                Destroy(brick.gameObject);
            }
        }
    }
}

