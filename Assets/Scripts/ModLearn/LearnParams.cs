using UnityEngine;


[CreateAssetMenu(fileName = "LearnParams", menuName = "Learn/Scene Params", order = 1)]
public class LearnParams : ScriptableObject
{
    public string ParamsName;
    public int[] RightAnswersList;
}