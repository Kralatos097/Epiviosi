using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    [TextArea(15,20)]
    [SerializeField] public List<string> lines = new List<string>();

    public Text text;

    private int indexLines = 0;
    // Start is called before the first frame update
    void Start()
    {
        text.text = lines[indexLines];
        indexLines++;
    }

    void OnConfirm()
    {
        if (lines.Count <= indexLines)
        {
            //LoadGameScene
        }
        else
        {
            text.text = lines[indexLines];
            indexLines++;
        }
    }
}
