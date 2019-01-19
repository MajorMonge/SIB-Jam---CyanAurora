using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    private Transform target;
    private EnemyFrigateAI thisAI;

    private float shootCooldown;

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

        ShootIfPossible();
    }

    private void Move()
    {
        Transform t = thisAI.transform;

        Quaternion to = Quaternion.Euler(0, 0, Vector3.SignedAngle(Vector3.up, target.position - t.position, Vector3.forward));

        t.rotation = Quaternion.Lerp(t.rotation, to, thisAI.RotationLerpSpeed);

        t.position += t.up * Time.deltaTime * thisAI.ChaseSpeed;
    }

    private void ShootIfPossible()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
            return;
        }

        Transform t = thisAI.transform;

        RaycastHit2D[] rhs = Physics2D.RaycastAll(t.position, t.up);

        if (rhs != null)
        {
            RaycastHit2D player = System.Array.Find(rhs, x => x.transform.CompareTag("Player"));

            if (player)
            {
                Bullet bullet = ObjectPool.Instances["Bullet"].GetObject().GetComponent<Bullet>();

                BulletData bd = thisAI.BulletData;
                bd.direction = thisAI.transform.up;

                bullet.transform.position = thisAI.transform.position;
                bullet.SetupAndActivate(thisAI.GetComponent<EnemyFrigate>(), bd);
                shootCooldown = 1 / thisAI.FireRate;
            }
        }


    }
}
