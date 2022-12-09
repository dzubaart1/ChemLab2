using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class DebugCanvasCntrl : MonoBehaviour
{
    [SerializeField]
    private Transform _content;

    public Text listItem;

    public void AddDebugText(string text)
    {
        listItem.text = text;
        Instantiate(listItem, _content);
    }

    public void CleanDebugText()
    {
        for(int i = 0; i < _content.childCount; i++)
        {
            Destroy(_content.GetChild(i));
        }
    }
}
