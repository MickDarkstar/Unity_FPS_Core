/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              Routine.cs 
 *Author:                BjazzZ
 *Version:               1.0 
 *UnityVersion：         2021.3.14f1 
 *Date:                  2022-12-07 
 *Description:           
 *History:               
================================================================*/

using UnityEngine;

namespace Assets._Scripts.Core.Coroutines
{
    public class Routine : MonoBehaviour // Todo: derive från SingletonBase och gör osynlig samt oförstörbar
    {
        private static Routine instance;
        public static Routine Instance
        {
            get
            {
                Init();
                return instance;
            }
        }

        private static void Init()
        {
            if (instance == null || instance.Equals(null))
            {
                var gameObject = new GameObject("Routine");
                instance = gameObject.AddComponent<Routine>();
            }
        }
    }
}
