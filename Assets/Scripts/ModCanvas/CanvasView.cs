using BNG;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class CanvasView : MonoBehaviour
{
    [SerializeField] private int CanvasId;

    private CanvasCntrl _canvasCntrl;
    private CanvasGroup _canvasGroup;

    private SignalBus _signalBus;

    private bool _isActivated;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _signalBus.Subscribe<SignalShowCanvas>(ShowCanvas);
    }
    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasCntrl = new CanvasCntrl(CanvasId, _canvasGroup);
        CanvasGroupCntrl.ChangeStateCanvas(_canvasGroup, false);
    }
    public void ShowCanvas(SignalShowCanvas props)
    {
        CanvasGroupCntrl.ChangeStateCanvas(_canvasGroup, props.CanvasId == CanvasId);
        _isActivated = props.CanvasId == CanvasId;
    }
}
