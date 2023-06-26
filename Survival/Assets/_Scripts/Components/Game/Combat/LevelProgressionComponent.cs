using Entitas;

[Game]
public class LevelProgressionComponent : IComponent
{
    public int level;
    public int currentEXP;
    public int nextLevelRequiredEXP;
}
