using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique, Event(EventTarget.Self)]
public class LevelProgressionComponent : IComponent
{
    public int level;
    public int currentEXP;
    public int nextLevelRequiredEXP;
}
