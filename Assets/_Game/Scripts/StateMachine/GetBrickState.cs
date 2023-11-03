using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GetBrickState : IState
{
    int targetBrick;
    public void OnEnter(Bot bot)
    {
        targetBrick = Random.Range(7, 18);
    }

    public void OnExecute(Bot bot)
    {
        if(bot.brickCount >= targetBrick)
        {
            bot.ChangeState(new MoveStairState());
            
        }
        else
        {
            bot.FindTarget();
            bot.MoveTarget(bot.destination);
            
        }
    }

    public void OnExit(Bot bot)
    {
        
    }

    
}
