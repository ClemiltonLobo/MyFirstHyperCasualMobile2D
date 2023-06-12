using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD
    }

    public void Play(AnimationType type)
    {
        foreach(var animation  in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }
    public void Update()
    {
     if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            Play(AnimationType.RUN);
        }
     else if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            Play(AnimationType.DEAD);
        }
     else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Play(AnimationType.IDLE);
        }
    }
}
[System.Serializable]

public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
}
