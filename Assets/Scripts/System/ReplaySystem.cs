using System.Collections.Generic;
using Entitas;

public class ReplaySystem : ReactiveSystem<GameEntity>
{
    readonly GameContext _context;

    public ReplaySystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var logicSystems = _context.logicSystem.systems;
        logicSystems.Initialize();
        var actions = _context.hasConsumptionHistory ? _context.consumptionHistory.entries : new List<ConsumptionEntity>();
        var actionIndex = 0;
        for (int tick = 0; tick <= _context.jumpInTime.targetTick; tick++)
        {
            _context.ReplaceTick(tick);
            if (actions.Count > actionIndex && actions[actionIndex].tick == tick)
            {
                _context.CreateEntity().AddConsumeElixir(actions[actionIndex].amount);
                actionIndex++;
            }
            logicSystems.Execute();
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasJumpInTime;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.JumpInTime);
    }
}
