using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeHitboxInvis : MonoBehaviour
{

    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
