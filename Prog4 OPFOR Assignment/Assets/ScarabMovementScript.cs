using UnityEngine;

public class ScarabMovementScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 destination;
    [SerializeField] private AnimationCurve verticalMoveSpeedCurve;
    [SerializeField] private bool isAscending = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 currentSpeed = new Vector3();

        RaycastHit forwardHit;
        
        Debug.DrawLine(transform.position, transform.forward * 5 + transform.position);
        if(Physics.Raycast(transform.position, transform.forward, out forwardHit, 5f))
        {

            currentSpeed.y = verticalMoveSpeedCurve.Evaluate(forwardHit.distance);
            currentSpeed.x = verticalMoveSpeedCurve.Evaluate(5 - forwardHit.distance);
            isAscending = true;

        }
        else
        {

            currentSpeed.x = verticalMoveSpeedCurve.Evaluate(5);
            isAscending = false;

        }

        if(!isAscending) { 
        
            if(transform.position.y > -1)
            {

                currentSpeed.y = -.25f;

            }
        
        }

        transform.position = currentSpeed;

    }

}
