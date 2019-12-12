using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform player;
    public int height;

    private Camera cam;


    private void Start()
    {
        cam = GetComponent<Camera>();
    }


    void Update()
    {
        transform.position = Vector3.Lerp(
            transform.position, 
            new Vector3(player.position.x, player.position.y + height, player.position.z - height/2),
            5 * Time.deltaTime);

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && cam.fieldOfView > 50) // forward
        {
            cam.fieldOfView -= 4;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f && cam.fieldOfView < 70) // backwards
        {
            cam.fieldOfView += 4;
        }
    }
}
