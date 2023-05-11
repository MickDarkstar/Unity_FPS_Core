/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              IState.cs 
 *Author:                BjazzZ
 *Version:               1.1
 *UnityVersion：         2021.3.14f1 
 *Date:                  2022-12-07 
 *Description:           
 *History:               Added Abort()
================================================================*/

namespace Assets._Scripts.Core.FiniteStateMachines
{
    public interface IState
    {
        public bool Finished { get { return true; } }

        void OnEnter();
        void OnExit();
        void Tick();
        void Abort();
    }
}
