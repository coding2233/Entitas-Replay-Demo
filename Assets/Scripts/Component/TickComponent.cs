using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Unique]
public class TickComponent:IComponent
{
    //当前帧
    public long currentTick;
}

