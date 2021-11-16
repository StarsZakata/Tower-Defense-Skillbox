using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float Radius, FireDelay, Damage;
    public LayerMask EnemyLayer;
    public Transform BulletPrefab;

    private float timeToFire;
    private Transform gun, enemy, firePoint;

    void Start()
    {
        timeToFire = FireDelay;
        gun = transform.GetChild(0);
        firePoint = gun.GetChild(0);
    }
    
    void Update()
    {
        if (timeToFire > 0)
            timeToFire -= Time.deltaTime;
        else if (enemy)
            Fire();

        if(enemy)
        {
            Vector3 lookAt = enemy.position;
            lookAt.y = gun.position.y;
            gun.rotation = Quaternion.LookRotation(gun.position - lookAt);

            if (Vector3.Distance(transform.position, enemy.position) > Radius)
                enemy = null;
        }
        else if(enemy == null)
        {
            Collider[] coll = Physics.OverlapSphere(transform.position, Radius, EnemyLayer);

            if (coll.Length > 0)
            {
                int[] enemiesPoints = new int[coll.Length];

                for (int i = 0; i < coll.Length; i++)
                {
                    enemiesPoints[i] = coll[i].GetComponent<Enemy>().GetPoint();
                }

                enemiesPoints = BubbleSort(enemiesPoints);
                
                for (int i = 0; i < coll.Length; i++)
                {
                    if(coll[i].GetComponent<Enemy>().GetPoint() == enemiesPoints[enemiesPoints.Length-1])
                    {
                        enemy = coll[i].transform;
                        break;
                    }
                }
                
            }
                
        }
    }

    void Fire()
    {
        Transform bullet = Instantiate(BulletPrefab, firePoint.position, Quaternion.identity);
        bullet.LookAt(enemy.GetChild(0));
        bullet.GetComponent<Bullet>().Damage = Damage;

        timeToFire = FireDelay;
    }

    //метод обмена элементов
    void Swap(ref int e1,ref int e2)
    {
        int temp = e1;
        e1 = e2;
        e2 = temp;
    }

    //сортировка пузырьком
    int[] BubbleSort(int[] array)
    {
        int len = array.Length;
        for (int i = 1; i < len; i++)
        {
            for (int j = 0; j < len - i; j++)
            {
                if (array[j] > array[j + 1])
                {
                    Swap(ref array[j], ref array[j + 1]);
                }
            }
        }

        return array;
    }
}
