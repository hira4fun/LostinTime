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
        }

        if(caveController.faceDir == 2){
            cRotation = new Vector3(0, 0, 0);
        }

        if(caveController.faceDir == 3){
            cRotation = new Vector3(0, 0, 90);
        }

        if(caveController.faceDir == 4){
            cRotation = new Vector3(0, 0, 270);
        }

        transform.rotation = Quaternion.Euler(cRotation);
    }
}