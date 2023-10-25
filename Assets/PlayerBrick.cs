using UnityEngine;

public class PlayerBrick : MonoBehaviour
{
    [SerializeField] private Material[] colorBrick;
    [SerializeField] private MeshRenderer brickPlayerRender;
    [SerializeField] private ColorData playerBrickColor;

    private void Start()
    {
        playerBrickColor = Player.Instance.colorPlayerData;
        SetColor(playerBrickColor);
    }

    private void SetColor(ColorData colorData)
    {
        int index = (int)colorData;
        brickPlayerRender.material = colorBrick[index];
    }
}
