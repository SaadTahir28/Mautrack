using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_panel : MonoBehaviour
{
    Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Método para reproducir la animación
    public void PlayAnimationClip()
    {
        anim[anim.clip.name].speed = 1;
        anim[anim.clip.name].time = 0;
        anim.Play();
    }

    // Método para detener la animación
    public void StopAnimationClip()
    {
        anim[anim.clip.name].speed = -1;
        anim[anim.clip.name].time = anim[anim.clip.name].length;
        anim.Play();
    }
}
