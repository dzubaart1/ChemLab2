using System;
using UnityEngine;

public class JSONSaver : MonoBehaviour, ISaver
{
    public void Load()
    {
        Console.WriteLine("Load");
    }

    public void Save()
    {
        Console.WriteLine("Save");
    }
}
