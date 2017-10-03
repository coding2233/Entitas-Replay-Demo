using System.Collections.Generic;
using Entitas;

public class ElixirConsumePersistSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context; 
    public ElixirConsumePersistSystem(Contexts contexts):base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        if (_context.isPause)
            return;
        var previousEntries = _context.hasConsumptionHistory ? _context.consumptionHistory.entries : new List<ConsumptionEntity>();
        foreach (var entity in entities)
        {
            previousEntries.Add(new ConsumptionEntity(_context.tick.currentTick, entity.consumeElixir.amount));
        }
        _context.ReplaceConsumptionHistory(previousEntries);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasConsumeElixir;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.ConsumeElixir);
    }
}

