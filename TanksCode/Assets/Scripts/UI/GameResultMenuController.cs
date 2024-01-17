using System;
using MoonMonster.Codetest;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class GameResultMenuController : MonoBehaviour
    {
        [SerializeField] private UnityEvent LoseAction, WinAction;
        [SerializeField] private GameManager gameManager;
        
        private void Awake()
        {
            gameManager.PlayerLoseEvent += OnPlayerLose;
            gameManager.PlayerVictoryEvent += OnPlayerVictory;
        }

        private void OnDestroy()
        {
            gameManager.PlayerLoseEvent -= OnPlayerLose;
            gameManager.PlayerVictoryEvent -= OnPlayerVictory;
        }
        
        private void OnPlayerLose()
        {
            LoseAction.Invoke();
        }

        private void OnPlayerVictory()
        {
            WinAction.Invoke();
        }
    }
}
