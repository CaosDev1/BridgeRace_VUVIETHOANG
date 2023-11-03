using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerBrick : MonoBehaviour
{
    [SerializeField] private Material[] colorBrick;
    [SerializeField] private MeshRenderer brickPlayerRender;
    [SerializeField] private ColorData playerBrickColor;
    
    public void SetColor(ColorData colorData)
    {
        int index = (int)colorData;
        brickPlayerRender.material = colorBrick[index];
    }
}
