using System.Diagnostics;

public enum GameState
{
    MainMenu = 0,
    State2 = 1,
    Gameplay = 2,
    Finish = 3
}
public class GameManager : Singleton<GameManager>
{
    private GameState state;

    public void ChangeStage(GameState gameState)
    {
        state= gameState;
    }

    public bool IsStage(GameState gameState)
    {
        return state == gameState;
    }
}
