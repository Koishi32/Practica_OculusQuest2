using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class DrunkBehaviour : MonoBehaviour
{
    Animator Animator;
    NavMeshAgent myNavMeshAgent;
    public Transform Player;
    Vector3 Destination;
    float lastVel;
    public int vida;
    // Start is called before the first frame update
    void Start()
    {
        
        Animator = this.gameObject.GetComponent<Animator>();
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        Animator.SetBool("IsRuning", true);
        //myNavMeshAgent.destination=(Player.transform.position);
        Destination = myNavMeshAgent.destination;
        lastVel = myNavMeshAgent.speed;
        vida = 5;
    }

    private void Update()
    {
        //myNavMeshAgent.SetDestination(Player.transform.position);
        if (Vector3.Distance(Destination, Player.position) > 1.0f)
        {
            Destination = Player.position;
            myNavMeshAgent.destination = Destination;
        }
        if (vida < 1) {
            Animator.SetTrigger("Death");
            myNavMeshAgent.speed = 0;
        }
    }

    public void Death_Drunk() {
        Destroy(this.gameObject);
    }
    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerHit");
            Animator.SetTrigger("Punch");
            // Animator.SetBool("IsRuning", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Animator.ResetTrigger("Punch");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("PlayerHit");
            Animator.SetTrigger("Punch");
           // Animator.SetBool("IsRuning", false);
        }
        
        else if (other.tag == "Projectile")
        {
            Debug.Log("Hit"+myNavMeshAgent.speed);
            Animator.SetTrigger("Pain");
            vida--;
            //lastVel=(myNavMeshAgent.speed);
            myNavMeshAgent.speed = 0;
            //Animator.SetBool("IsRuning", false);
        }
    }

    public void ResumeRuning() {
        
        Debug.Log("Reset runing"+lastVel);
        //Animator.SetBool("IsRuning", true);
        myNavMeshAgent.speed = lastVel;
    }
    /*
    public void OnPointerClick()
    {
        if (bullet!= null) {
            Debug.Log("Log");
            Rigidbody clone;
            clone = Instantiate(bullet, Player.position, Player.rotation);
            clone.velocity = Player.TransformDirection(Player.forward * 10);
            Destroy(clone.gameObject,3.0f);
        }
    }
#if UNITY_EDITOR
    private void OnMouseDown()
    {
        if (bullet != null)
        {
            Debug.Log("Log");
            Rigidbody clone;
            clone = Instantiate(bullet, Player.position, Player.rotation);
            clone.velocity = Player.TransformDirection(Player.forward * 1.5f);
            Destroy(clone.gameObject,1.5f);
        }
    }
#endif
    */
}
