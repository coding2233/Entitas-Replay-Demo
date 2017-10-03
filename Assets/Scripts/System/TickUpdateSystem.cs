using Entitas;
//更新帧计数
public class TickUpdateSystem : IInitializeSystem, IExecuteSystem
{
    readonly GameContext _context;
    public TickUpdateSystem(Contexts contexts)
    {
        _context = contexts.game;
    }

    public void Initialize()
    {
        _context.ReplaceTick(0);
    }

    public void Execute()
    {
        if (!_context.isPause)
            _context.ReplaceTick(_context.tick.currentTick + 1);
    }

}

