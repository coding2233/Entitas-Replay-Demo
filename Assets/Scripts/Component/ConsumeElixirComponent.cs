using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ConsumeElixirComponent:IComponent
{
    //消耗的能量值
    public int amount;
}

