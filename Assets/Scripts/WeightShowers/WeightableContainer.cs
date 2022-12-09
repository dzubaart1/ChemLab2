using System.Collections.Generic;
using UnityEngine;

public class WeightableContainer : MonoBehaviour, IColiderInteraction
{
    private List<Weightable> _weightables;

    public void ColissionDetecting(GameObject colider)
    {
        if (colider.GetComponent<Weightable>() is null || _weightables.Contains(colider.GetComponent<Weightable>()))
        {
            return;
        }
        _weightables.Add(colider.GetComponent<Weightable>());
    }

    public void OnCollisionEnter(Collision collision)
    {
        ColissionDetecting(collision.gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        ColissionDetecting(other.gameObject);
    }
    public double GetSumWeight()
    {
        double sum = 0;
        foreach (var weightable in _weightables)
        {
            sum += weightable.Weight;
        }
        return sum;
    }

    private void Awake()
    {
        _weightables = new List<Weightable>();
    }

}
