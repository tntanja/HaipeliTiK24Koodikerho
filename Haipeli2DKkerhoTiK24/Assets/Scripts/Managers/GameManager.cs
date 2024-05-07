using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager instance;
    public GameState currentGameState;
    private Master controls;
    
    void Awake()
    {
        if(instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }

        controls = new Master();
    }

    private void OnEnable() {
      controls.Enable();   
    }

     private void OnDisable() {
      controls.Disable(); 
    }

    public bool IsGamePlay() {
        return currentGameState == GameState.Gameplay;
    }

    public void ChangeGameState(GameState newState) {
        currentGameState = newState;
    }

    private void Update() {
        GamePause();
    }

    private void GamePause() {
        if (controls.Game.Pause.triggered) {
            if(IsGamePlay()) {
                ChangeGameState(GameState.Pause);
            } else {
                ChangeGameState(GameState.Gameplay);
            }
        }
    }
}
