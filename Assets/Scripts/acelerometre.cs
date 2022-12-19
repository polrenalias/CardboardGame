using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acelerometre : MonoBehaviour
{
    
    public bool camina=false;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float f =Input.acceleration.z;
        if (f>0.3f || f<-0.3f)
                {
                  camina=true;
                }
                else
                {
                    camina=false;
                }
    }

    private void OnGUI() {
         GUILayout.Label(Input.acceleration.x.ToString());
          GUILayout.Label(Input.acceleration.y.ToString());
           GUILayout.Label(Input.acceleration.z.ToString());
        GUILayout.Label(camina.ToString());


    }
}
