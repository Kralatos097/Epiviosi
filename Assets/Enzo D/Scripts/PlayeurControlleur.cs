using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeurControlleur : MonoBehaviour
{
    private PlayeurControl playeurControl;

    private void Awake()
    {
        playeurControl = new PlayeurControl();
    }

    private void OnEnable()
    {
        playeurControl.Enable();
    }

    private void OnDisable()
    {
        playeurControl.Disable();
    }
        
    
    void Start()
    {
        
    }

    private void Update()
    {
        Vector2 mouvement = playeurControl.Arène.Mouvement.ReadValue<Vector2>();
        Debug.Log(mouvement);
        
    }

   
}
