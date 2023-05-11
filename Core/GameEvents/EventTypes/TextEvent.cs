// <copyright file="TextEvent" company="MickDarkstar">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Mikael Fehrm, micke@tempory.org</author>
// <date>08/30/2021 11:39:58 AM </date>
// <summary>Class representing an TextEvent</summary>

namespace Assets._Scripts.GameEvents.GameEventTypes
{
    using UnityEngine;

    public class TextEvent
    {
        public string Text;
        public Color Color;

        public TextEvent(string text)
        {
            this.Text = text;
        }

        public TextEvent(string text, Color color)
        {
            this.Text = text;
            this.Color = color;
        }
    }
}
