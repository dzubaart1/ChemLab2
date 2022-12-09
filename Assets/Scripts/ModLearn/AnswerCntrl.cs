using UnityEngine;
using Zenject;
using static Save;

public class AnswerCntrl : MonoBehaviour
{
    public int Id;
    private SignalBus _signalBus;
    private bool complited = false;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void InitiateAnswer()
    {
        if (!complited)
        {
            _signalBus.Fire<SignalAnswerJob>(new SignalAnswerJob() { AnswerId = Id });
            complited = true;
            this.enabled = false;
        }
    }

    public void LoadData(ObjectSaveData objSaveData)
    {
        transform.position = new Vector3(objSaveData.pos.x, objSaveData.pos.y, objSaveData.pos.z);
    }
}
