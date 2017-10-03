using System.Collections.Generic;
using Entitas;

//在取消暂停的时候，清掉当前帧之后的数据
public class CleanupConsumtionHistorySystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;
    public CleanupConsumtionHistorySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var actions = _context.hasConsumptionHistory ? _context.consumptionHistory.entries : new List<ConsumptionEntity>();
        int count = 0;
        for (int index = actions.Count - 1; index >= 0; index--)
        {
            if (actions[index].tick > _context.tick.currentTick)
            {
                count++;
            }
            else
            {
                break;
            }
        }
        actions.RemoveRange(actions.Count - count, count);
    }

    protected override bool Filter(GameEntity entity)
    {
        // throw new System.NotImplementedException();
        // return true;
        return entity.isPause;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.Pause.Removed()); ;
    }
}

