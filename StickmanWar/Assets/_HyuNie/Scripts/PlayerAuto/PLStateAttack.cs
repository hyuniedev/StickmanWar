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
        playerAuto.AttackEnemy();
    }

    public void OnExit(PlayerAuto playerAuto)
    {

    }
}