// <copyright file="IHasLife.cs" company="MickDarkstar">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Mikael Fehrm, micke@tempory.org</author>
// <date>08/30/2021 11:39:58 AM </date>
// <summary>Contract for gameobjects of type HealthBar </summary>

namespace Assets._Scripts.Core.Interfaces
{
    public interface IHealthBar
    {
        void Set(float currentHealth, float maxHealth);
    }
}