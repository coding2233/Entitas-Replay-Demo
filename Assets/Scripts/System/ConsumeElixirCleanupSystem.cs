using Entitas;

public class ConsumeElixirCleanupSystem : ICleanupSystem
{
    readonly GameContext _context;
    readonly IGroup<GameEntity> _entities;
    public ConsumeElixirCleanupSystem(Contexts contexts)
    {
        _context = contexts.game;
        _entities = _context.GetGroup(GameMatcher.ConsumeElixir);
    }

    public void Cleanup()
    {
        foreach (var item in _entities.GetEntities())
            item.Destroy();
    }
}

