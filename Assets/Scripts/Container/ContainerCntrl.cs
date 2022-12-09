using BNG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCntrl : MonoBehaviour
{
    public SubstanceParams substanceParams;
    public SnapZone snapZone;
    public CupCntrl cupCntrl;

    public void Start()
    {
        cupCntrl.gameObject.name += substanceParams.name;
        snapZone.OnlyAllowNames.Clear();
        snapZone.OnlyAllowNames.Add(cupCntrl.gameObject.name);
    }

    public bool isClosed()
    {
        return snapZone.HeldItem is not null;
    }
}
