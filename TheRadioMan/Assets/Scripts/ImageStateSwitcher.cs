using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageStateSwitcher : MonoBehaviour
{

    public ImageState currentState = null;
    public List<ImageState> states = new List<ImageState>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ 
            if(currentState != states[0]) {
                currentState.Deactivate();
                states[0].Activate();
                currentState = states[0];
            } else if(currentState != states[1]) {
                currentState.Deactivate();
                states[1].Activate();
                currentState = states[1];
            }
        }

        if(Input.GetKeyDown(KeyCode.Z)) {
            currentState.Deactivate();
            states[1].Activate();
            currentState = states[1];
        }
    }
}
