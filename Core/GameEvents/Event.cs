// <copyright file="Event.cs">
// Copyright (c) 2021 All Rights Reserved
// </copyright>
// <author>Mikael Fehrm, micke@tempory.org</author>
// <date>08/30/2021 11:39:58 AM </date>
// <summary>Class representing Events of different kinds, withut parameter or with parameters or with parameters and EventOptions</summary>

namespace Assets._Scripts.GameEvents
{
    using System;

    /// <summary>
    /// - Bör främst användas för att kommunicera mellan större system istället för att ha direkta beroenden mellan t.ex Managers. 
    /// 
    /// Custom wrapper för ett spelevent:
    ///  - Fördelen med den här typen av event, (över EventManagerMagicString och EventManagerUnityEvents) är att vi slipper ett dummyobjekt som håller en instans i varje scene.
    /// Och vi behöver inte definiera ett UnityEvent eller ta emot massa tomma Dictionaries när vi lyssnar på eventen.
    ///  - Fördel med hårt typade, ett syfte. MEN en nackdel kan bli att vi skapar väldigt generella event och får "döda" lyssnare, olika objekt som lyssnar på en typ av event men
    /// inte har anledning att agera på eventet. Baserat på typ, EventOptions och andra parametrar.
    ///  - Troligen mer lightweight att använda native "event Action" istället för UnityEvent. 
    ///     Speciellt då vi speccar exakt hur meddelanden ser ut och innehålla endast det som behövs för dess syfte
    ///     
    /// Events speccas i valfri statisk klass/klasser, se Events.cs för exempelkod.
    /// </summary>
    public class Event
    {
        private event Action _action = delegate { };

        public void Invoke() { _action.Invoke(); }

        public void AddListener(Action listener)
        {
            // Safetycheck, vi ville inte ha samma lyssnare flera ggr.
            _action -= listener; // Gör inget om inte lyssnare ej redan prenumererat.

            // Lägg till en subscriber/lyssnare
            _action += listener;
            // Warning: Inte thread-safe
        }

        public void RemoveListener(Action listener)
        {
            _action -= listener;
        }
    }

    /// <summary>
    /// Custom wrapper för ett spelevent
    /// </summary>
    /// <typeparam name="T">Parameter vi vill skicka med av vilken typ som helst</typeparam>
    public class Event<T>
    {
        private event Action<T> _action = delegate { };

        public void Invoke(T param) { _action.Invoke(param); }

        public void AddListener(Action<T> listener) { _action -= listener; _action += listener; }

        public void RemoveListener(Action<T> listener) { _action -= listener; }
    }

    /// <summary>
    /// Custom wrapper för ett spelevent utökat med EventOptions
    /// </summary>
    /// <typeparam name="T">Parameter vi vill skicka med av vilken typ som helst</typeparam>
    /// <typeparam name="IEventOptions">Parameter för options vi vill skicka med som implementerar IEventOptions</typeparam>
    public class Event<T, IEventOptions>
    {
        private event Action<T, IEventOptions> _action = delegate { };

        public void Invoke(T param, IEventOptions options) { _action.Invoke(param, options); }

        public void AddListener(Action<T, IEventOptions> listener) { _action -= listener; _action += listener; }

        public void RemoveListener(Action<T, IEventOptions> listener) { _action -= listener; }
    }
}
