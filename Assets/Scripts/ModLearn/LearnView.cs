using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LearnView : MonoBehaviour
{
    private SignalBus _signalBus;
    private LearnCntrl _cntrl;
    [SerializeField] private LearnParams _params;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
        _signalBus.Subscribe<SignalAnswerJob>(WriteAnswer);
        _cntrl = new LearnCntrl(this);
    }

    public void WriteAnswer(SignalAnswerJob answer)
    {
        _cntrl.WriteAnswer(answer.AnswerId);

        if (!_cntrl.CheckCorrectAnswer(_params.RightAnswersList))
        {
            _signalBus.Fire<SignalShowCanvas>(new SignalShowCanvas() { CanvasId = 404 });
            return;
        }

        if(_cntrl.CheckCompliteLearn(_params.RightAnswersList))
        {
            _signalBus.Fire<SignalShowCanvas>(new SignalShowCanvas() { CanvasId = 200 });
            return;
        }
    }
}
