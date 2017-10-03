using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ElixirAmountBehaviour : MonoBehaviour, IElixirListener
{
    private GameContext _context;
    private Text _text;

    private void Awake()
    {
        _context = Contexts.sharedInstance.game;
        _context.CreateEntity().AddElixirLisenter(this);
    }
    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void ElixirAmountChanged(float amount)
    {
        _text.text =""+(int)amount;
    }
}
