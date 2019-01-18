using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : State
{
    private EnemyFrigateAI thisAI;
    private bool isTurning = false;

    private Quaternion newRotation;

    public override void OnFinish(StateMachine sm)
    {
    }

    public override void OnStart(StateMachine sm)
    {
        if (sm is EnemyFrigateAI)
        {
            thisAI = sm as EnemyFrigateAI;
        }
    }

    public override void OnUpdate(StateMachine sm)
    {
        if (thisAI == null) return;

        Transform t = thisAI.transform;

        RaycastHit2D rh = Physics2D.Raycast(t.position, t.up, 5, LayerMask.GetMask("Obstacles"));
        Debug.DrawLine(t.position, t.position + (t.up * 5), Color.green);

        if (rh && rh.collider.CompareTag("Obstacle") && !isTurning)
        {
            isTurning = true;

            float angle = Random.Range(20f, 60f);
            angle *= Mathf.Sign(Random.value - 0.5f);

            newRotation = Quaternion.Euler(0, 0, t.rotation.eulerAngles.z + angle);
        }

        RaycastHit2D[] rhs = Physics2D.CircleCastAll(t.position, thisAI.SightRadius, Vector2.zero);

        if (rhs != null)
        {
            RaycastHit2D rhPlayer = System.Array.Find(rhs, x => x.collider.CompareTag("Player"));

            if (rhPlayer)
            {
                thisAI.ChangeState(new ChasingState(rhPlayer.transform));
            }
        }

        Move();
    }

    private void Move()
    {
        Transform t = thisAI.transform;

        if (isTurning)
        {
            Turn();
        }

        t.position += t.up * Time.deltaTime * thisAI.PatrolSpeed;
    }

    private void Turn()
    {
        thisAI.transform.rotation = Quaternion.Lerp(thisAI.transform.rotation, newRotation, thisAI.RotationLerpSpeed);

        if (Mathf.Abs(Quaternion.Angle(thisAI.transform.rotation, newRotation)) < 0.1) isTurning = false;
    }

    
}
