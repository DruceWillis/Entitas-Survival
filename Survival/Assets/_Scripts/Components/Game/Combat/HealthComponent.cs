using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Event(EventTarget.Self)]
public class HealthComponent : IComponent
{
    public int value;
}
