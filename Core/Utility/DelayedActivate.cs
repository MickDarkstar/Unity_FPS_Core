/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              DelayedActivate.cs 
 *Author:                BjazzZ 
 *Version:               1.0 
 *UnityVersion:          2021.3.14f1 
 *Date:                  2022-12-14 
 *Description:           
 *History:               
================================================================*/

using UnityEngine;

namespace Assets._Scripts.Game.Utility
{
    public class DelayedActivate : MonoBehaviour
    {
        public void ActivateAfter(float delayTime) => Invoke("Activate", delayTime);
        private void Activate() => gameObject.SetActive(true);
    }
}
