using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public GlitchEffect effect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            effect.enabled = true;
        
    }
}
