using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum steeringBehaviors
{
    Seek, Flee, Arrive, None
}

public class Kinematic : MonoBehaviour
{

    public Vector3 linearVelocity;
    public float angularVelocity; //In degrees
    public Kinematic myBoi;

    public steeringBehaviors choiceOfBehavior;

    // Update is called once per frame
    void Update()
    {
        switch (choiceOfBehavior)
        {
            case steeringBehaviors.None:
                ResetOrientation();
                break;
            default:
                MainSteeringBehaviors();
                break;
        }
    }


    void MainSteeringBehaviors()
    {
        ResetOrientation();

        switch (choiceOfBehavior)
        {
            case steeringBehaviors.Seek:
                Seek seek = new Seek();
                seek.selectedBoi = this;
                seek.myBoi = myBoi;
                SteeringOutput seeking = seek.getSteering();
                if (seeking != null)
                {
                    linearVelocity += seeking.linearVelocity * Time.deltaTime;
                    angularVelocity += seeking.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Flee:
                Flee flee = new Flee();
                flee.selectedBoi = this;
                flee.myBoi = myBoi;
                SteeringOutput fleeing = flee.getSteering();
                if (fleeing != null)
                {
                    linearVelocity += fleeing.linearVelocity * Time.deltaTime;
                    angularVelocity += fleeing.angularVelocity * Time.deltaTime;
                }
                break;
            case steeringBehaviors.Arrive:
                Arrive arrive = new Arrive();
                arrive.selectedBoi = this;
                arrive.myBoi = myBoi;
                SteeringOutput arriving = arrive.getSteering();
                if (arriving != null)
                {
                    linearVelocity += arriving.linearVelocity * Time.deltaTime;
                    angularVelocity += arriving.angularVelocity * Time.deltaTime;
                }
                break;
        }

    }

    void ResetOrientation()
    {
        //Update position and rotation
        transform.position += linearVelocity * Time.deltaTime;
        Vector3 angularVelocityIncrement = new Vector3(0, angularVelocity * Time.deltaTime, 0);
        transform.eulerAngles += angularVelocityIncrement;
    }

}