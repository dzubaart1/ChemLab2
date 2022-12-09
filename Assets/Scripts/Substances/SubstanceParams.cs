using UnityEngine;

[CreateAssetMenu(fileName = "SubstanceParams", menuName = "Substance/Substance Params", order = 1)]
public class SubstanceParams : ScriptableObject
{
    public string name;
    public Color color;
    public GameObject prefab;
}