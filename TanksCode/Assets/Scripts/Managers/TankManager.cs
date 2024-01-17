using System;
using AI;
using Tank;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MoonMonster.Codetest
{
    [Serializable]
    public class TankManager
    {
        public Color TankColor;
        public Transform SpawnPoint;
        [HideInInspector] public int TankNumber;
        [HideInInspector] public string ColoredPlayerText;
        [HideInInspector] public GameObject Instance;
        [HideInInspector] public int Wins;

        private TankMovementPlayer movementPlayer;
        private PlayerInput _playerInput;
        private AIBattleController aiBattleController;
        private GameObject _canvasGameObject;
        public event Action Disable, Enable; 

        public void Setup()
        {
            movementPlayer = Instance.GetComponent<TankMovementPlayer>();
            _playerInput = Instance.GetComponent<PlayerInput>();
            aiBattleController = Instance.GetComponent<AIBattleController>();
            _canvasGameObject = Instance.GetComponentInChildren<Canvas>().gameObject;

            if(_playerInput)
                _playerInput.PlayerNumber = TankNumber;
            if(aiBattleController)
                aiBattleController.Target = Object.FindObjectOfType<PlayerInput>().transform;

            if(_playerInput)
                ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(TankColor) + ">PLAYER " + TankNumber + "</color>";
            else if(aiBattleController)
            {
                ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(TankColor) + ">AI</color>";
            }

            MeshRenderer[] renderers = Instance.GetComponentsInChildren<MeshRenderer>();

            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].material.color = TankColor;
            }
        }

        public void DisableControl()
        {
            Disable?.Invoke();
            if (movementPlayer) movementPlayer.enabled = false;
            if (_playerInput)
                _playerInput.enabled = false;
            if (aiBattleController)
                aiBattleController.enabled = false;
        }

        public void EnableControl()
        {
            Enable?.Invoke();
            if (movementPlayer) 
                movementPlayer.enabled = true;
            if(_playerInput)
                _playerInput.enabled = true;
            if(aiBattleController)
                aiBattleController.enabled = true;
        }

        public void Reset()
        {
            Instance.transform.position = SpawnPoint.position;
            Instance.transform.rotation = SpawnPoint.rotation;

            Instance.SetActive(false);
            Instance.SetActive(true);
        }
    }
}