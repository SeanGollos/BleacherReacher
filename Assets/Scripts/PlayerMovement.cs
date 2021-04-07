using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Config params
    [SerializeField] float screenWidthInUnits = 245f;
    [SerializeField] float minX = 4f;
    [SerializeField] float maxX = 240f;
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] AudioClip bounceClip;
    [SerializeField] [Range(0, 1)] float bounceVolume = 0.5f;

    // Update is called once per frame
    void Update()
    {
        //First see if we need to rotate the paddle
        var rotation = Input.GetAxisRaw("Horizontal");
        if(rotation<0)
        {
            if(transform.rotation.z>-15)
                transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
        if (rotation>0)
        {
            if(transform.rotation.z <15)
                transform.Rotate(-Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        //Move the paddle based on the mouse position
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 playerPos = new Vector2(mousePosInUnits, 2);
        playerPos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = playerPos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(bounceClip, Camera.main.transform.position, bounceVolume);
    }
}
