using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrickColor
{
    Red = 1,
    Green = 2,
    Blue = 3,
    None = 4
}
public class Brick : MonoBehaviour
{
    public BrickColor brickColor;
}
