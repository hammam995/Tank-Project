using System.Collections;
using System.Collections.Generic;
using Tank;
using UnityEngine;

namespace MoonMonster.Codetest
{
    public class PlayerInput : MonoBehaviour
    {
        public int PlayerNumber = 1; 
        private TankMovementPlayer movementPlayer;
        private string _movementAxisName;         
        private string _turnAxisName;

        void Start()
        {
            movementPlayer = gameObject.GetComponent<TankMovementPlayer>();
            _movementAxisName = "Vertical" + PlayerNumber;
            _turnAxisName = "Horizontal" + PlayerNumber;
        }

        void Update()
        {
            movementPlayer.SetMoveInput(Input.GetAxis (_movementAxisName),Input.GetAxis (_turnAxisName));
        }
    }

}