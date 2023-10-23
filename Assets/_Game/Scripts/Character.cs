using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private bool canGetRedBrick;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.BRICK_TAG))
        {
            BrickColor brickColor = other.GetComponent<Brick>().brickColor;
            Debug.Log(brickColor);

            if (brickColor == BrickColor.Blue || brickColor == BrickColor.None)
            {
                Player player= GetComponent<Player>();
                player.AddBrick();
            }

            if(canGetRedBrick)
            {
                if(brickColor == BrickColor.Red || brickColor == BrickColor.None)
            {
                    Player player = GetComponent<Player>();
                    player.AddBrick();
                }
            }
        }
    }
}
