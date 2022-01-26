using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchPlayerScript : MonoBehaviour
{
    [SerializeField] public List<GameObject> playerPrefabList;
    public PlayerInputManager InputManager;
    
    // Start is called before the first frame update
    void Awake()
    {
        InputManager.playerPrefab = playerPrefabList[0];
    }

    // Update is called once per frame
    void Update()
    {
        InputManager.playerPrefab = playerPrefabList[InputManager.playerCount];
    }
}
