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
    /// - B�r fr�mst anv�ndas f�r att kommunicera mellan st�rre system ist�llet f�r att ha direkta beroenden mellan t.ex Managers. 
    /// 
    /// Custom wrapper f�r ett spelevent:
    ///  - F�rdelen med den h�r typen av event, (�ver EventManagerMagicString och EventManagerUnityEvents) �r att vi slipper ett dummyobjekt som h�ller en instans i varje scene.
    /// Och vi beh�ver inte definiera ett UnityEvent eller ta emot massa tomma Dictionaries n�r vi lyssnar p� eventen.
    ///  - F�rdel med h�rt typade, ett syfte. MEN en nackdel kan bli att vi skapar v�ldigt generella event och f�r "d�da" lyssnare, olika objekt som lyssnar p� en typ av event men
    /// inte har anledning att agera p� eventet. Baserat p� typ, EventOptions och andra parametrar.
    ///  - Troligen mer lightweight att anv�nda native "event Action" ist�llet f�r UnityEvent. 
    ///     Speciellt d� vi speccar exakt hur meddelanden ser ut och inneh�lla endast det som beh�vs f�r dess syfte
    ///     
    /// Events speccas i valfri statisk klass/klasser, se Events.cs f�r exempelkod.
    /// </summary>
    public class Event
    {
        private event Action _action = delegate { };

        public void Invoke() { _action.Invoke(); }

        public void AddListener(Action listener)
        {
            // Safetycheck, vi ville inte ha samma lyssnare flera ggr.
            _action -= listener; // G�r inget om inte lyssnare ej redan prenumererat.

            // L�gg till en subscriber/lyssnare
            _action += listener;
            // Warning: Inte thread-safe
        }

        public void RemoveListener(Action listener)
        {
            _action -= listener;
        }
    }

    /// <summary>
    /// Custom wrapper f�r ett spelevent
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
    /// Custom wrapper f�r ett spelevent ut�kat med EventOptions
    /// </summary>
    /// <typeparam name="T">Parameter vi vill skicka med av vilken typ som helst</typeparam>
    /// <typeparam name="IEventOptions">Parameter f�r options vi vill skicka med som implementerar IEventOptions</typeparam>
    public class Event<T, IEventOptions>
    {
        private event Action<T, IEventOptions> _action = delegate { };

        public void Invoke(T param, IEventOptions options) { _action.Invoke(param, options); }

        public void AddListener(Action<T, IEventOptions> listener) { _action -= listener; _action += listener; }

        public void RemoveListener(Action<T, IEventOptions> listener) { _action -= listener; }
    }
}
