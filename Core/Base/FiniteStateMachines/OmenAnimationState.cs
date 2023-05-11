/*===============================================================
 *Copyright(C) 2022 by Jamback All rights reserved. 
 *FileName:              OmenAnimationState.cs 
 *Author:                BjazzZ
 *Version:               1.0 
 *UnityVersion：         2021.3.14f1 
 *Date:                  2022-12-07 
 *Description:           
 *History:               
================================================================*/

using System;
using UnityEngine;

namespace Assets._Scripts.Core.FiniteStateMachines
{
    public abstract class OmenAnimationState : Behaviour
    {
        protected string animationName;
        protected Animator animator;
        protected float timer;
        protected float animationDuration;

        public OmenAnimationState(Animator animator)
        {
            this.animator = animator ?? throw new ArgumentNullException(nameof(animator));
        }

        public OmenAnimationState(Animator animator, string animationName)
        {
            this.animator = animator ?? throw new ArgumentNullException(nameof(animator));
            this.animationName = animationName ?? throw new ArgumentNullException(nameof(animationName));
            this.animationDuration = this.GetAnimationDuration(animationName);

            //if (this.animationDuration == 0f)
            //    Debug.LogWarning($"{animationDuration}s duration for: {animationName}, on Animator:{animator.runtimeAnimatorController.name}");
        }

        public void Play(string animation)
        {
            this.animator.Play(animation);
        }

        public void Crossfade(string animation, float fadeTime = 0.2f)
        {
            this.animator.CrossFade(animation, fadeTime, 0);
        }

        protected void PlayAnimation()
        {
            this.animator.Play(animationName);
        }

        protected void StopAnimation()
        {
            this.animator.StopPlayback();
        }

        protected float GetAnimationDuration(string animationName)
        {
            float returnValue = 0f;
            AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

            foreach (AnimationClip clip in clips)
            {
                if (clip.name == animationName)
                    returnValue = clip.length;
            }

            return returnValue;
        }

        protected void ResetTimer()
        {
            timer = 0f;
        }
    }
}
