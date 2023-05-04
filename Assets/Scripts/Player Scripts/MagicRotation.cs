using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicRotation : MonoBehaviour
{
    // Start is called before the first frame update
    
    Vector3 mRotation = new Vector3(0, 0, 0);
    public WizController wizController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float faceDir = wizController.faceDir;

        if(wizController.faceDir == 1){
            mRotation = new Vector3(0, 0, 180);
        }

        if(wizController.faceDir == 2){
            mRotation = new Vector3(0, 0, 0);
        }

        if(wizController.faceDir == 3){
            mRotation = new Vector3(0, 0, 90);
        }

        if(wizController.faceDir == 4){
            mRotation = new Vector3(0, 0, 270);
        }

        transform.rotation = Quaternion.Euler(mRotation);
    }
}
