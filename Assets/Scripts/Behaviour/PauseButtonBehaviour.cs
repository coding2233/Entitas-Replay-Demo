using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonBehaviour : MonoBehaviour, IPauseListener
{
    GameContext _context;
    [SerializeField]
    Text _text;
    private void Awake()
    {
        _context = Contexts.sharedInstance.game;
        _context.CreateEntity().AddPauseListener(this);
    }
    
    public void PauseStateChanged(bool isPause)
    {
        _text.text = isPause ? "Resume" : "Pause";
    }

    public void PressButton()
    {
        _context.isPause = !_context.isPause;
    }
}

