using Entitas;
using Entitas.CodeGeneration.Attributes;
using System.Collections.Generic;

[Game,Unique]
public class ConsumptionHistoryComponent:IComponent
{
    public List<ConsumptionEntity> entries;
}

public class ConsumptionEntity
{
    public long tick
    {
        get;
        private set;
    }
    public int amount
    {
        get;
        private set;
    }
    public ConsumptionEntity(long tick, int amount)
    {
        this.tick = tick;
        this.amount = amount;
    }
}

