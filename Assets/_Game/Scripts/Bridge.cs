using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject stairSkin;
    private bool isCollect = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.PLAYER_TAG) && other.GetComponent<Player>().playerBrickList.Count != 0 && !isCollect)
        {
            other.GetComponent<Player>().RemoveBrick();
            stairSkin.SetActive(true);
            isCollect = true;
        }
    }
}
