using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCntrl : ICanvas
{
    [SerializeField] private int CanvasId;
    private CanvasGroup _group;

    public CanvasCntrl(int id, CanvasGroup group)
    {
        CanvasId = id;
        _group = group;
    }
    public void CreateMenu()
    {
        throw new System.NotImplementedException();
    }

    public void ShowCanvas(SignalShowCanvas props)
    {
        CanvasGroupCntrl.ChangeStateCanvas(_group, props.CanvasId == CanvasId);
    }
}
