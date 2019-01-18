using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    private Transform target;
    private EnemyFrigateAI thisAI;

    public ChasingState(Transform target)
    {
        this.target = target;
    }

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

        if (!target.gameObject.activeInHierarchy) thisAI.ChangeState(new PatrollingState());

        Move();
    }

    private void Move()
    {
        Transform t = thisAI.transform;

        Quaternion to = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, target.position - t.position, Vector3.forward));

        t.rotation = Quaternion.Lerp(t.rotation, to, thisAI.RotationLerpSpeed);

        t.position += t.up * Time.deltaTime * thisAI.ChaseSpeed;
    }
}
