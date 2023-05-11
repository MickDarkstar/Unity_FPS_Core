/*===============================================================
 *FileName:              StateMachine.cs 
 *Author:                BjazzZ 
 *Version:               1.2 
 *UnityVersion:          2021.3.14f1 
 *Date:                  2023-01-10 
 *Description:           Cred to Jason Weimann, an adaption of: https://www.youtube.com/watch?v=V75hgcsCGOM
 *History:               Added method AbortCurrentState
================================================================*/

using System;
using System.Collections.Generic;

//#pragma warning disable IDE0090 // Use 'new(...)'
namespace Assets._Scripts.Core.FiniteStateMachines
{
    public class StateMachine
    {
        private IState _currentState;
        private readonly Dictionary<Type, List<Transition>> _transitions = new();
        private List<Transition> _currentTransitions = new();
        private readonly List<Transition> _anyTransitions = new();
        private static readonly List<Transition> EmptyTransitions = new(0);

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);

            _currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == _currentState)
                return;

            _currentState?.OnExit();
            _currentState = state;

            _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
                _currentTransitions = EmptyTransitions;

            _currentState.OnEnter();
        }

        public void AddTransition(IState to, IState from, Func<bool> predicate)
        {
            if(_transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _transitions[from.GetType()] = transitions;
            }

            transitions.Add(new Transition(to, predicate));
        }

        public void AddAnyTransition(IState state, Func<bool> predicate)
        {
            _anyTransitions.Add(new Transition(state, predicate));
        }

        public void AbortCurrentState()
        {
            _currentState?.Abort();
        }

        private Transition GetTransition()
        {
            foreach (var transition in _anyTransitions)
                if (transition.Condition())
                    return transition;

            foreach (var transition in _currentTransitions)
                if (transition.Condition())
                    return transition;

            return null;
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                this.To = to;
                this.Condition = condition;
            }
        }
    }
}
