/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              IInput.cs 
 *Author:                BjazzZ 
 *Version:               1.0 
 *UnityVersion:          2021.3.14f1 
 *Date:                  2022-12-04 
 *Description:           
 *History:               
================================================================*/

namespace Assets._Scripts.Core.Interfaces
{
    public interface IInput
	{
        void ReadInput();

        bool Idle
        {
            get
            {
                return
                    WeaponIdle &&
                    !Jump &&
                    !Use;
            }
        }

        bool WeaponIdle
        {
            get
            {
                return
                    !Fire1 &&
                    !Fire1Hold &&
                    !Fire1Release &&
                    !Fire2 &&
                    !Fire2Hold &&
                    !Fire2Release &&
                    !Reload;
            }
        }

        bool Fire1 { get;}
        bool Fire1Hold { get;}
        bool Fire1Release { get; }

        bool Fire2 { get;}
        bool Fire2Hold { get;}
        bool Fire2Release { get; }

        bool Reload { get;}
        bool Jump { get;}
        bool Use { get;}
    }
}
