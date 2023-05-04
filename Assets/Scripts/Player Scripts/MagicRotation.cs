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
            Debug.Log("hitbox facing north");
        }

        if(wizController.faceDir == 2){
            mRotation = new Vector3(0, 0, 0);
            Debug.Log("hitbox facing south");
        }

        if(wizController.faceDir == 3){
            mRotation = new Vector3(0, 0, 90);
            Debug.Log("hitbox facing east");
        }

        if(wizController.faceDir == 4){
            mRotation = new Vector3(0, 0, 270);
            Debug.Log("hitbox facing west");
        }

        transform.rotation = Quaternion.Euler(mRotation);
    }
}
