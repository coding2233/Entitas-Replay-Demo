using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class ProduceElixirSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly GameContext _context;

    //能量的最大值
    public const float ElixirCapacity = 14f;
    //每次能量增长的幅度
    readonly float _productionStep = 0.01f;

    public ProduceElixirSystem(Contexts contexts) : base(contexts.game)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceElixir(0);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        var newAmount = _context.elixir.amount + _productionStep;
        newAmount = Mathf.Min(ElixirCapacity, newAmount);
        _context.ReplaceElixir(newAmount);
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

