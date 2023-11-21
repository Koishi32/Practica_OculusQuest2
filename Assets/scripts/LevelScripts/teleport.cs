using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleport : MonoBehaviour
{
    public Transform Player_position;
    float OffsetY, ballOffSet;
    RaycastHit hit;
    public Camera Mycamera;
    Ray ray;
    public Rigidbody bullet;
    float timeBetweenShots,timeSinceShot;
    bool IsShot;
    float timeBetweenTeleport, timeSinceTeleport;
    bool IsTeleported;
    // Start is called before the first frame update
    private void Start()
    {
        OffsetY = 1.5f;
        ballOffSet=1.5f;
        IsShot = false;
        timeBetweenShots = 0.5f;
        timeBetweenTeleport = 0.5f;
        IsTeleported = false;
    }

    void Update()
    {
        if (Input.touchCount > 0) {
            ray = Mycamera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Ground" && !IsTeleported)
            {
                IsTeleported = true;
                Debug.Log(hit.transform.gameObject.name + " _Pos: " + hit.point);
                Player_position.position = hit.point + (OffsetY * Vector3.up);
            }
            else if (Physics.Raycast(ray, out hit) && hit.transform.tag == "Enemy") {
                if (bullet != null && !IsShot)
                {
                    IsShot = true;
                    Debug.Log("Shot");
                    Rigidbody clone;
                    clone = Instantiate(bullet, Player_position.position + (Player_position.forward*ballOffSet) , Player_position.rotation);
                    clone.velocity = (hit.transform.position-Player_position.position ).normalized * 10;
                    Destroy(clone.gameObject, 3.0f);
                }
            }
        }

        if (IsShot) {
            timeSinceShot += Time.deltaTime;
            if (timeSinceShot > timeBetweenShots) {
                IsShot = false;
                timeSinceShot = 0;
            }
        }
        if (IsTeleported)
        {
            timeSinceTeleport += Time.deltaTime;
            if (timeSinceTeleport > timeBetweenTeleport)
            {
                IsTeleported = false;
                timeSinceTeleport = 0;
            }
        }


    }
    
}
