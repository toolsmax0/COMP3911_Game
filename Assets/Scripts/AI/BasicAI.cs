using UnityEngine;
using System.Collections;
public class BasicAI : MonoBehaviour
{
    public Transform target;
    // private Animator animator;
    private Animation animation;
    private int lock1 = 0;
    void Start()
    {
        StartCoroutine(MoveToTarget());
        // animator = GetComponent<Animator>();
        animation = GetComponent<Animation>();
    }


    void Update()
    {
        if (target != null)
        {
            //if distance less than 2m, stop moving

            if (Vector3.Distance(transform.position, target.position) <= 2.01f )
            {
                // Debug.Log("Arrived at target");
                //change animation to idle
                animation.Play("Idle");
                // Debug.Log("Idle");
                if (lock1==0)
                {
                    StartCoroutine(gameObject.GetComponent<Customer>().StartCaptureAfterTime(0f, 4f));
                    lock1++;
                }
                // animator.SetBool("Arrived", true);
                // animator.SetBool("IsMoving", false);
            }
            else
            {
                animation.Play("walk");

                // animator.SetBool("IsMoving", true);
                // animator.SetBool("Arrived", false);
            }
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