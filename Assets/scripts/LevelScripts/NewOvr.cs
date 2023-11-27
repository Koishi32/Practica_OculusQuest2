using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOvr : MonoBehaviour
{
    //For user movement 
    private CharacterController userCharacter;
    public Vector3 userDirection;
    public float userSpeed;
    private Transform cameraTranform;

    //for user interactions
    public Transform bulletStart;
    public GameObject bullet;
    public float bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        userCharacter = GetComponent<CharacterController>();
        cameraTranform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //For user movement
        Vector2 userControl = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cameraRotation = cameraTranform.eulerAngles.y;
        Vector3 camerarotation = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraTranform.forward;
        userDirection = (camerarotation * Input.GetAxis("Horizontal") + cameraTranform.forward * Input.GetAxis("Vertical")).normalized;
        //userDirection.y = 0f;
        userCharacter.Move(userDirection * Time.deltaTime * userSpeed);

        //for user interactions
        float triggerOculusValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);


        if (Input.GetButtonDown("Fire1") || triggerOculusValue >= 0.5f)
        {
            GameObject newBullet = Instantiate(bullet, bulletStart.transform.position, bulletStart.rotation);
            Rigidbody bulletforce = newBullet.GetComponent<Rigidbody>();
            bulletforce.AddForce(bulletStart.forward * Time.deltaTime * bulletForce, ForceMode.Impulse);
        }


    }
}
