using System.Numerics;
using UnityEngine;

public class PLStateAttack : IState
{
    public void OnEnter(PlayerAuto playerAuto)
    {
        playerAuto.setTargetToEnemy();
    }

    public void OnExecute(PlayerAuto playerAuto)
    {
        if (!playerAuto.checkEnemy())
        {
            playerAuto.MoveToEnemy();
        }
        else
        {
            playerAuto.target = playerAuto.transform;
            playerAuto.AttackEnemy();
        }

    }

    public void OnExit(PlayerAuto playerAuto)
    {

    }
}