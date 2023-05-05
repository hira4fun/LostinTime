using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingWallTrigger : MonoBehaviour
{
    public GameObject cam;
    public GameObject cat;
    public BoxCollider2D box;
    private int counter = 0;
    [Range(-50f, 50f)] public float camOffset = 10f;
    public Vector2 catOffset;
    [Range(5, 180)] public int countOffset = 10;
    private Vector3 moveCam;
    private Vector3 moveCat;
    private LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        moveCam = new Vector3(0, camOffset, 0);
        moveCat = new Vector3(catOffset.x, catOffset.y, 0);
        layerMask = LayerMask.GetMask("Player");
    }


    // Update is called once per frame
    void Update()
    {
        counter++;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        float catY = cat.transform.position.y;
        float boxY = box.transform.localPosition.y;
        if (catY < boxY && counter >= countOffset && col.CompareTag("Player") || col.CompareTag("Player3"))
        {
            cam.transform.position += moveCam;
            cat.transform.position += new Vector3(moveCat.x, moveCat.y, 0);
            counter = 0;
        }
        else if (catY >= boxY && counter > countOffset && col.CompareTag("Player") || col.CompareTag("Player3"))
        {
            cam.transform.position -= moveCam;
            cat.transform.position -= new Vector3(moveCat.x, moveCat.y, 0);
            counter = 0;
        }
    }
}