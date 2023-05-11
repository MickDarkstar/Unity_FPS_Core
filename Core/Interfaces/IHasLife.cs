// <copyright file="IHasLife.cs" company="MickDarkstar">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Mikael Fehrm, micke@tempory.org</author>
// <date>08/30/2021 11:39:58 AM </date>
// <summary>Contract for gameobject that should have a life XD </summary>

using UnityEngine;

namespace Assets._Scripts.Core.Interfaces
{
    public interface IHasLife
    {
        float Health { get; }
        float MaxHealth { get; }
        bool Immortal { get; set; }

        void SetHealth(float value);
        void SetMaxHealth(float value);
        void IncreaseHealth(float value);

        float Armor { get; }
        float MaxArmor { get; }
        void SetArmor(float value);
        void SetMaxArmor(float value);
        void IncreaseArmor(float value);

        bool IsAlive();
        void TakeDamage(float value, GameObject source = null);
        void Die();
    }
}