public abstract class AbstractState
{
   protected BaseFSM fsm;

    public AbstractState(BaseFSM Somefsm)
    {
        fsm = Somefsm;
    }

    public virtual void EnterState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }

}
