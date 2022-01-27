using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    [TextArea(15,20)]
    [SerializeField] public List<string> lines = new List<string>();

    private int indexLines = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnConfirm()
    {
        Debug.Log(lines[indexLines]);
        indexLines++;
    }
}
