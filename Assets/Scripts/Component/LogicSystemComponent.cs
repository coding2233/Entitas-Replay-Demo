using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game, Unique]
public class LogicSystemComponent : IComponent
{
    public Systems systems;
}