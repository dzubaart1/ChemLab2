using UnityEngine;
using Zenject;

public class FirstLabInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        InitialSignals();

    }

    void InitialSignals()
    {
        Container.DeclareSignal<SignalShowCanvas>();
        Container.DeclareSignal<SignalShowPanel>();
        Container.DeclareSignal<SignalShowModal>();
        Container.DeclareSignal<SignalAnswerJob>();
    }
}
