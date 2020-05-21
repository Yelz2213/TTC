using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public LayerMask whatCanBeClickOn;
    private NavMeshAgent myAgent;

    public Animator m_Animator;
    bool isWalk;
    bool isIdle;
    bool isRunning;
    bool isPlaying;

    AudioSource walk;
    // Start is called before the first frame update
    void Start()
    {
        isWalk = false;
        isIdle = true;
        isRunning = false;


        myAgent = GetComponent<NavMeshAgent>();
        m_Animator = gameObject.GetComponent<Animator>();
        walk = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickOn)) {
                myAgent.SetDestination(hitInfo.point);
            }
        }
        Action();

    }

    public void Action() {
        if (myAgent.velocity != Vector3.zero)
        {
            isWalk = true;
            isRunning = false;
            isIdle = false;

            m_Animator.ResetTrigger("isIdle");
            m_Animator.ResetTrigger("isRunning");
            m_Animator.SetTrigger("isWalk");
            if (isPlaying == false) {
                walk.Play();
                isPlaying = true;
            }


            if (myAgent.remainingDistance >= 8)
            {
                isWalk = false;
                isRunning = true;
                isIdle = false;
                myAgent.speed = 4;
                m_Animator.ResetTrigger("isIdle");
                m_Animator.ResetTrigger("isWalk");
                m_Animator.SetTrigger("isRunning");

            }
            else {
                myAgent.speed = 2;
            }
        } else if (myAgent.velocity == Vector3.zero)
        {
            walk.Stop();
            isPlaying = false;
            isWalk = false;
            isRunning = false;
            isIdle = true;
            m_Animator.ResetTrigger("isWalk");
            m_Animator.ResetTrigger("isRunning");
            m_Animator.SetTrigger("isIdle");
        }
    }

}
