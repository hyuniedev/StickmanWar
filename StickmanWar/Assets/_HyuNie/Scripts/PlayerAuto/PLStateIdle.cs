public class PLStateIdle : IState{
    public void OnEnter(PlayerAuto playerAuto){
        
    }

    public void OnExecute(PlayerAuto playerAuto)
    {
        playerAuto.enemy = playerAuto.findEnemy();
    }

    public void OnExit(PlayerAuto playerAuto)
    {
        
    }
}