using System.Collections.Generic;
using Entitas;

public class NotifyPauseListenersSystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _listeners;
    public NotifyPauseListenersSystem(Contexts contexts):base(contexts.game)
    {
        _context = contexts.game;
        _listeners = _context.GetGroup(GameMatcher.PauseListener);
    }
    
    protected override void Execute(List<GameEntity> entities)
    {
        bool value = _context.isPause;
        foreach (var item in _listeners.GetEntities())
            item.pauseListener.value.PauseStateChanged(value);
    }

    protected override bool Filter(GameEntity entity)
    {
        //     return entity.isPause;
        return true;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Pause.AddedOrRemoved());
    }
}

