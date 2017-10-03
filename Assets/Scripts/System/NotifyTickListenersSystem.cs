using System.Collections.Generic;
using Entitas;

public class NotifyTickListenersSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _listeners;

    public NotifyTickListenersSystem(Contexts contexts):base(contexts.game)
    {
        _context = contexts.game;
        _listeners = _context.GetGroup(GameMatcher.TickListener);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        long tick = _context.tick.currentTick;
        foreach (var item in _listeners.GetEntities())
            item.tickListener.value.TickChanged(tick);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasTick;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Tick);
    }
}

