using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubRotation : MonoBehaviour
{
    // Start is called before the first frame update
    
    Vector3 cRotation = new Vector3(0, 0, 0);
    public CaveController caveController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float faceDir = caveController.faceDir;

        if(caveController.faceDir == 1){
            cRotation = new Vector3(0, 0, 180);
            Debug.Log("hitbox facing north");
        }

        if(caveController.faceDir == 2){
            cRotation = new Vector3(0, 0, 0);
            Debug.Log("hitbox facing south");
        }

        if(caveController.faceDir == 3){
            cRotation = new Vector3(0, 0, 90);
            Debug.Log("hitbox facing east");
        }

        if(caveController.faceDir == 4){
            cRotation = new Vector3(0, 0, 270);
            Debug.Log("hitbox facing west");
        }

        transform.rotation = Quaternion.Euler(cRotation);
    }
}