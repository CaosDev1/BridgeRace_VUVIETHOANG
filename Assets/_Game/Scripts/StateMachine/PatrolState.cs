using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PatrolState : IState
{
    int targetBrick;
    public void OnEnter(Bot bot)
    {
        targetBrick = Random.Range(1, 4);
    }

    public void OnExecute(Bot bot)
    {
        if(bot.brickCount >= targetBrick)
        {
            bot.ChangeState(new AttackState());
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
