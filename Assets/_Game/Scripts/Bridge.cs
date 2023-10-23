using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.Player) && other.GetComponent<Player>().playerBrickList.Count != 0)
        {
            other.GetComponent<Player>().RemoveBrick();
        }
    }
}
