using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorData
{
    Blue = 0,
    Green = 1,
    Red = 2,
    None = 3
}
public class Brick : MonoBehaviour
{
    [SerializeField] private Material[] brickColor;
    [SerializeField] private MeshRenderer renderBrick;
    public ColorData colorData;

    private void Start()
    {
        colorData = (ColorData)Random.Range(0, 3);
        SetColor(colorData);
        
    }

    private void SetColor(ColorData colorData)
    {
        int index = (int)colorData;
        renderBrick.material = brickColor[index];
    }

    
}
