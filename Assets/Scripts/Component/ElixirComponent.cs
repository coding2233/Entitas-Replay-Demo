using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game,Unique]
public class ElixirComponent:IComponent
{
    //能量值
    public float amount;
}

