using BNG;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class weightShow : MonoBehaviour
{
    [SerializeField] 
    private Text _weightText;
    private SnapZone _snapZone;

    private void Awake()
    {
        _snapZone = GetComponent<SnapZone>();
        _weightText.text = "0.0000g";
    }

    void Update()
    {
        if (_snapZone.HeldItem is null || _snapZone.HeldItem.GetComponent<WeightableContainer>() is null)
        {
            _weightText.text = "0.0000g";
            return;
        }
        string text = _snapZone.HeldItem.GetComponent<WeightableContainer>().GetSumWeight().ToString("0.0000", CultureInfo.InvariantCulture);
        _weightText.text = text + "g";
    }
}
