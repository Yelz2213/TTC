using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour
{
    public LayerMask whatCanBeClickOn;
    private NavMeshAgent myAgent;
    public Transform target;

    public Animator m_Animator;
    bool isWalk;
    bool isIdle;
    bool isRunning;
    bool isPlaying;

    public Player player;

    AudioSource walk;

    public UIcontroller uIcontroller;
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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickOn))
                {
                    //Debug.Log(hitInfo.point);
                    myAgent.SetDestination(hitInfo.point);
                }
                if (uIcontroller.isPause = true)
                {
                    uIcontroller.pauseGame();
                }
                RemoveFocus();
            }
        }

        if(target != null)
        {
            //Debug.Log(target.position);
            myAgent.SetDestination(target.position);
            FaceTarget();
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

    public void RemoveFocus()
    {
        if (player.focus != null)
        {
            player.focus.OnDefocused();
        }

        player.focus = null;
        StopFollowingTarget();
    }

    public void FollowTarget (Interactable newTarget)
    {
        myAgent.stoppingDistance = newTarget.radius * .8f;
        myAgent.updateRotation = false;
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        myAgent.stoppingDistance = 0f;
        myAgent.updateRotation = true;
        target = null;
    }

    public void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

    }
}
