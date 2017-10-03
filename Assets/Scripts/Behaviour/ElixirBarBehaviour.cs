using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ElixirBarBehaviour : MonoBehaviour, IElixirListener
{
    private GameContext _context;
    private Slider _slider;
    private void Awake()
    {
        _context = Contexts.sharedInstance.game;
        _context.CreateEntity().AddElixirLisenter(this);
    }
    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void ElixirAmountChanged(float amount)
    {
        float value = amount / ProduceElixirSystem.ElixirCapacity;
        _slider.value = value;
    }
}

