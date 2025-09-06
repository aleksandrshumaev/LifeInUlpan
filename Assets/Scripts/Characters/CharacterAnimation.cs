using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;
    List<AnimationClip> _animations = new List<AnimationClip>();
    // Start is called before the first frame update
    void Start()
    {
       
        GetAninmationList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GetAninmationList()
    {
        _animator = GetComponent<Animator>();
        foreach (AnimationClip clip in _animator.runtimeAnimatorController.animationClips)
        {
            _animations.Add(clip);
        }
    }
    AnimationClip GetAnimationFromName(string animationName)
    {
        foreach(AnimationClip clip in _animations)
        {
            if(clip.name == animationName)
            {
                return clip;
            }
        }
        return null;
    }
    public void RefreshAnimation(int animationFaceDirection, string animationStanding, string animationActivity)
    {
        var animationToPlay = animationStanding + animationActivity  + animationFaceDirection;
        if(_animations.Contains(GetAnimationFromName(animationToPlay)))
        {
            _animator.Play(animationToPlay,0);
        }
        Debug.Log(animationToPlay);
    }
}
