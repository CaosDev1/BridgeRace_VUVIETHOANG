using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    [SerializeField] private GameObject stairSkin;
    [SerializeField] private Material[] stairColor;
    [SerializeField] private MeshRenderer stairRender;
    public ColorData stairColorData;
    public bool isCollect = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(ConstString.PLAYER_TAG) && other.GetComponent<Character>().playerBrickList.Count != 0)
        {
            if (!isCollect)
            {
                stairColorData = other.GetComponent<Character>().colorPlayerData;
                other.GetComponent<Character>().RemoveBrick();
                SetColor(stairColorData);
                stairSkin.SetActive(true);
                isCollect = true;
            }
            else if (stairColorData != other.GetComponent<Character>().colorPlayerData)
            {
                other.GetComponent<Character>().RemoveBrick();
                stairColorData = other.GetComponent<Character>().colorPlayerData;
                SetColor(stairColorData);
            }

        }
    }

    private void SetColor(ColorData colorData)
    {
        int index = (int)colorData;
        stairRender.material = stairColor[index];
    }
    
}
