using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class ConsumeButtonBehaviour : MonoBehaviour, IPauseListener, IElixirListener
{
    private GameContext _context;
    //点击按钮消耗的能量
    [SerializeField]
    private int _consumptionAmount;
    private Button _button;
    [SerializeField]
    private Image _image;
    private void Awake()
    {
        _context = Contexts.sharedInstance.game;
        var entity= _context.CreateEntity();
        entity.AddPauseListener(this);
        entity.AddElixirLisenter(this);
    }

    private void Start()
    {
        _button = GetComponent<Button>();
    }

    public void PauseStateChanged(bool isPause)
    {
        _button.enabled = !isPause;
    }

    public void ElixirAmountChanged(float amount)
    {
        var ratio = 1.0f - Mathf.Clamp01(amount / (float)_consumptionAmount);
        _image.fillAmount = ratio;
        _button.enabled = Mathf.Abs(ratio - 0.0f) < Mathf.Epsilon;
    }

    public void PressButton()
    {
        if (_context.isPause)
            return;
        _context.CreateEntity().AddConsumeElixir(_consumptionAmount);
    }

}

