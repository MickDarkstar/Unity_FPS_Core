/*===============================================================
 *Copyright(C) 2022 by  Jamback All rights reserved. 
 *FileName:             GameStateManager.cs 
 *Author:               BjazzZ
 *Version:              1.0 
 *UnityVersion：        2021.3.2f1 
 *Date:                 2022-05-21 
 *Description:          
 *History:              
================================================================*/

using Assets._Scripts.GameEvents;

namespace Assets._Scripts.Core
{
    public class GameStateManager : Singleton<GameStateManager> // Todo: behöver det ens vara en singelton? Flytta till gameevents
    {
        public GameState CurrentGameState { get; private set; }

        public void SetGameState(GameState newGameState)
        {
            if (newGameState == CurrentGameState)
                return;

            CurrentGameState = newGameState;
            Events.OnGameStateChanged.Invoke(newGameState);
        }
    }
}
