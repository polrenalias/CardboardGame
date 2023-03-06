using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scrolls the texture of the slide
public class TexScroller : MonoBehaviour
{
    float scrollSpeed = -.5f;
    float offset;
    float rotate;
 
    void Update (){
        offset+= (Time.deltaTime*scrollSpeed)/10.0f;
        GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", new Vector2(0f,offset));
    }
}
