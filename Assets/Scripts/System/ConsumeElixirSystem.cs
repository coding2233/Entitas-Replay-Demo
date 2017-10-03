using System.Collections.Generic;
using Entitas;

public class ConsumeElixirSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context; 
    public ConsumeElixirSystem(Contexts contexts):base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        float amount = 0.0f;
        foreach (var item in entities)
        {
            if (_context.elixir.amount < item.consumeElixir.amount)
                return;
            amount = _context.elixir.amount-item.consumeElixir.amount;
            _context.ReplaceElixir(amount);
        }
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

