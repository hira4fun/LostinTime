using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipRotation : MonoBehaviour
{
    // Start is called before the first frame update
    
    Vector3 wRotation = new Vector3(0, 0, 0);
    public ArcController arcController;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float faceDir = arcController.faceDir;

        if(arcController.faceDir == 1){
            wRotation = new Vector3(0, 0, 180);
        }

        if(arcController.faceDir == 2){
            wRotation = new Vector3(0, 0, 0);
        }

        if(arcController.faceDir == 3){
            wRotation = new Vector3(0, 0, 90);
        }

        if(arcController.faceDir == 4){
            wRotation = new Vector3(0, 0, 270);
        }

        transform.rotation = Quaternion.Euler(wRotation);
    }
}