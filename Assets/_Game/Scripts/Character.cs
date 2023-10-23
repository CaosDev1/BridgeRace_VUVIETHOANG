using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.Brick))
        {
            BrickColor brickColor = other.GetComponent<Brick>().brickColor;
            Debug.Log(brickColor);

            if (brickColor == BrickColor.Blue || brickColor == BrickColor.None)
            {
                Player player= GetComponent<Player>();
                player.AddBrick();
            }
        }
    }
}
