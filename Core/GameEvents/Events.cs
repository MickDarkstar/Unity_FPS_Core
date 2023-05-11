// <copyright file="Events.cs" company="MickDarkstar">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Mikael Fehrm, micke@tempory.org</author>
// <date>08/30/2021 11:39:58 AM </date>
// <summary>Class representing all current defined events</summary>

namespace Assets._Scripts.GameEvents
{
    using Assets._Scripts.Core;
    using Assets._Scripts.GameEvents.GameEventTypes;
    using UnityEngine;

    /// <summary>
    /// Container för spelets alla definierade Events
    /// Borde väl heta GameEvents då det är en container för specifika event i just ETT spel
    /// </summary>
    public static class Events
    {
        #region GameState, Scenes 
        public static readonly Event OnLevelStart = new Event();
        public static readonly Event<GameState> OnGameStateChanged = new Event<GameState>();
        #endregion

        #region Enemies
        public static readonly Event<GameObject> OnKilled = new Event<GameObject>();
        #endregion

        #region UI - Playermessages, Quests, Info etc.,
        public static readonly Event<TextEvent, TextEventOptions> OnDisplayUserMessage = new Event<TextEvent, TextEventOptions>();

        // Player specific
        public static readonly Event<bool> OnPlayerIdle = new Event<bool>();
        #endregion

        #region Inventory, Weapons
        public static readonly Event<int> OnWeaponChanged = new Event<int>();
        public static readonly Event<int> OnAmmoChanged = new Event<int>();
        #endregion
    }
}