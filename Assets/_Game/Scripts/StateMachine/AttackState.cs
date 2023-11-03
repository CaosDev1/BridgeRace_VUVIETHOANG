using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState
{
    public void OnEnter(Bot bot)
    {
        bot.MoveTarget(bot.goalPos);
    }

    public void OnExecute(Bot bot)
    {
        if(bot.brickCount == 0)
        {
            bot.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Bot bot)
    {
        
    }
}
