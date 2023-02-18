using Entitas;

public class EnemySpawnSystem : IInitializeSystem, IExecuteSystem
{
    private Contexts _contexts;
    

    public EnemySpawnSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Initialize()
    {
        throw new System.NotImplementedException();
    }
    
    public void Execute()
    {

    }

}
