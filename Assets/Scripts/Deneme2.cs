using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme2 : MonoBehaviour
{
    public GlitchEffect effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        effect.enabled = false;

    }
}
