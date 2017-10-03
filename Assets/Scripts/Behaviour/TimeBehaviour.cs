using Entitas;
using UnityEngine;
using UnityEngine.UI;

public class TimeBehaviour : MonoBehaviour, ITickListener
{
    GameContext _context;
    Text _text;

    private void Awake()
    {
        _context = Contexts.sharedInstance.game;
        _context.CreateEntity().AddTickListener(this);
    }
    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void TickChanged(long cureentTick)
    {
        var sec = (cureentTick / 60) % 60;
        var min = (cureentTick / 60)/60;
        var secText = sec > 9 ? "" + sec : "0" + sec;
        var minText = min > 9 ? "" + min : "0" + min;
        _text.text = minText + ":" + secText;
    }
}

