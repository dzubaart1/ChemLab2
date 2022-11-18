using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnCntrl
{
    public List<int> CurAnswers = new List<int>();
    private LearnView View;

    public LearnCntrl(LearnView _view)
    {
        View = _view;
    }

    public bool CheckCorrectAnswer(int[] answers)
    {
        for(int i = 0; i < CurAnswers.Count; i++)
        {
            if(CurAnswers[i] != answers[i])
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckCompliteLearn(int[] answers)
    {
        return CheckCorrectAnswer(answers) && answers.Length.Equals(CurAnswers.Count);
    }
    public void CompliteLearn()
    {
        Debug.Log("learn complite");
    }

    public void WriteAnswer(int id)
    {

        CurAnswers.Add(id);
        Debug.Log(id);
        Debug.Log(CurAnswers.Count);

    }
}
