using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Unique]
public class JumpInTimeComponent:IComponent
{
    public long targetTick;
}
