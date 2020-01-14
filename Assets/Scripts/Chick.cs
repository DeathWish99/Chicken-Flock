using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour
{
    Animator anim = new Animator();
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
}
