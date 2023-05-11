/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              PlayerInput.cs 
 *Author:                BjazzZ
 *Version:               1.0 
 *UnityVersion：         2021.3.14f1 
 *Date:                  2022-12-04 
 *Description:           
 *History:               
================================================================*/
using Assets._Scripts.Core.Interfaces;
using UnityEngine;

namespace Assets._Scripts.Core.Player
{
    public class PlayerInput : IInput
    {
        public bool Fire1 { get; set; }
        public bool Fire1Hold { get; set; }
        public bool Fire1Release { get; set; }

        public bool Fire2 { get; set; }
        public bool Fire2Hold { get; set; }
        public bool Fire2Release { get; set; }

        public bool Reload { get; set; }
        public bool Jump { get; set; }
        public bool Use { get; set; }

        public void ReadInput()
        {
            Fire1 = Input.GetMouseButtonDown(0);
            Fire1Hold = Input.GetMouseButton(0);
            Fire1Release = Input.GetMouseButtonUp(0);

            Fire2 = Input.GetMouseButtonDown(1);
            Fire2Hold = Input.GetMouseButton(1);
            Fire2Release = Input.GetMouseButtonUp(1);

            Reload = Input.GetKeyDown(KeyCode.R);
            Jump = Input.GetKeyDown(KeyCode.Space);
            Use = Input.GetKeyDown(KeyCode.E);
        }
    }
}
