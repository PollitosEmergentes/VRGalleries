using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator Fade_Transition;
    void FadeInScene(){
        Fade_Transition.Play("FadeIn");
    }
    void FadeOutScene(){
        Fade_Transition.Play("FadeOut");
    }
}
