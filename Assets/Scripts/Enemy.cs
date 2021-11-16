using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed, RotationSpeed;
    public Transform[] Points;
    public float MaxHP;

    private float HP;
    private Transform currentPoint;
    private int index;
    private Vector3 direction;
    private ResourceManager rm;

    void Start()
    {
        rm = FindObjectOfType<ResourceManager>();
        index = 0;
        //HP = MaxHP;
        currentPoint = Points[index];
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject);
            HP -= other.GetComponent<Bullet>().Damage;

            if(HP <= 0)
            {
                rm.EnemyKill();

                Destroy(gameObject);
            }
        }

    }

    public int GetPoint()
    {
        return index;
    }

    public void SetHP(float newHP)
    {
        HP = newHP;
    }

    void Update()
    {
        direction = currentPoint.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, Time.deltaTime * RotationSpeed, 0);
        transform.rotation = Quaternion.LookRotation(direction);

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, Time.deltaTime * Speed);

        if(transform.position == currentPoint.position)
        {
            index++;

            if(index >= Points.Length)
            {
                Destroy(gameObject);
                rm.MissEnemy();
            }
            else
            {
                currentPoint = Points[index];
            }

        }
    }
}
