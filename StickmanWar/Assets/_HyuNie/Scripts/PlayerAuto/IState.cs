public interface IState{
    void OnEnter(PlayerAuto playerAuto);
    void OnExecute(PlayerAuto playerAuto);
    void OnExit(PlayerAuto playerAuto);
}