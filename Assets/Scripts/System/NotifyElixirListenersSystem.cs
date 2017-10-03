using System.Collections.Generic;
using Entitas;

public class NotifyElixirListenersSystem:ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _listeners;

    public NotifyElixirListenersSystem(Contexts contexts):base(contexts.game)
    {
        _context = contexts.game;
        _listeners = _context.GetGroup(GameMatcher.ElixirLisenter);
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        float amount = _context.elixir.amount;
        foreach (var item in _listeners.GetEntities())
            item.elixirLisenter.value.ElixirAmountChanged(amount);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasElixir;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Elixir);
    }
}

