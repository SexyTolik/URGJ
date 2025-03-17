using System;
using UnityEngine;

namespace GameContent.Scripts.Player
{
    public class PlayerController : MonoComponent
    {
        public event Action LMBClicked;
        public event Action RMBClicked;
        public event Action DashPressed;
        public event Action JumpPressed;
        public event Action ReloadPressed;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                LMBClicked?.Invoke();
            }
            if (Input.GetMouseButtonDown(1))
            {
                RMBClicked?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                DashPressed?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JumpPressed?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                ReloadPressed?.Invoke();
            }
        }
    }
}