using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStairState : IState
{
    public void OnEnter(Bot bot)
    {
        bot.MoveTarget(bot.goalPos);
        
    }

    public void OnExecute(Bot bot)
    {
        if(bot.brickCount == 0)
        {
            bot.ChangeState(new GetBrickState());
        }
    }

    public void OnExit(Bot bot)
    {
        
    }
}
