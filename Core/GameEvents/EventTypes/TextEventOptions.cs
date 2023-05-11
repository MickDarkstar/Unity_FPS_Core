
// <copyright file="TextEventOptions" company="MickDarkstar">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Mikael Fehrm, micke@tempory.org</author>
// <date>08/30/2021 11:39:58 AM </date>
// <summary>Class representing options for an Event</summary>

namespace Assets._Scripts.GameEvents.GameEventTypes
{
    public class TextEventOptions : IEventOptions
    {
        public float ResetAfterTime;
        public float DelayTime;

        public TextEventOptions(float resetTime = 2f)
        {
            this.ResetAfterTime = resetTime;
        }

        public bool HasValues()
        {
            return ResetAfterTime > 0f || DelayTime > 0f;
        }
    }
}
