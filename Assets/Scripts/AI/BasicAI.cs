using UnityEngine;
using System.Collections;
public class BasicAI : MonoBehaviour
{
    public Transform target;
    // private Animator animator;
    public float stopDist = 0.5f;
    private Animation animation;
    private int lock1 = 0;

    private GameObject player;
    void Start()
    {
        StartCoroutine(MoveToTarget());
        // animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    enum State
    {
        idle, move
    }

    private State crtState = State.move;

    void Update()
    {
        if (target != null)
        {

            if (Vector3.Distance(transform.position, target.position) <= stopDist + 0.01f)
            {
                crtState = State.idle;
                // Debug.Log("Arrived at target");
                //change animation to idle
                animation.Play("Idle");
                // Debug.Log("Idle");

                // animator.SetBool("Arrived", true);
                // animator.SetBool("IsMoving", false);
            }
            else
            {
                crtState = State.move;
                animation.Play("walk");
                // animator.SetBool("IsMoving", true);
                // animator.SetBool("Arrived", false);
            }
        }
        if (crtState == State.idle)
        {
            if (lock1 == 0)
            {
                StartCoroutine(gameObject.GetComponent<Customer>().StartCaptureAfterTime(0f, 4f));
                lock1++;
            }
            // face the player
            transform.LookAt(player.transform);
        }
    }



    IEnumerator MoveToTarget()
    {
        while (true)
        {
            if (target != null)
            {
                this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().destination = target.position;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }
}