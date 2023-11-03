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
                //Set mau gach = mau cua nguoi choi
                stairColorData = other.GetComponent<Character>().colorPlayerData;
                //Xoa gach cua nguoi choi
                other.GetComponent<Character>().RemoveBrick();
                //Doi mau stair giong moi mau cua nguoi choi
                SetColor(stairColorData);
                //Hien thi stair
                stairSkin.SetActive(true);
                //Set trang thai cho stair la da va cham roi
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
