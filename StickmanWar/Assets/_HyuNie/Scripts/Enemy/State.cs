public abstract class State{
    protected Enemy _enemy;
    public State(Enemy enemy) { _enemy = enemy;}
    public virtual void OnEnter(){}
    public virtual void OnExit(){}
    public abstract void OnExecute();
}