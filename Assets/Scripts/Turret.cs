using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Turret : MonoBehaviour
{
    private string enemyTag = "Enemy";
    private List<GameObject> enemies = new List<GameObject>();

    [Header("Atributes")]
    public float range = 10f;
    public float rotationSpeed = 1f;
    public float fireRate = 0.15f;
    private float fireCountdown = 0f;

    [Header("Properties")]
    public GameObject BulletPrefab;
    public GameObject target;
    public Transform firePoint;
    

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //if enemy in range rotate and shoot
        fireCountdown -= Time.deltaTime;
        if (target == null)
            return;

        TargetLockOn();

        if(fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / fireRate;
        }
    }

    void TargetLockOn() 
    {
        //rotate - Target lock on
        var direction = transform.position - target.transform.position;
        var lookRotation = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void UpdateTarget()
    {
        enemies = GameObject.FindGameObjectsWithTag(enemyTag).ToList();
        enemies.RemoveAll(enemy => enemy == null || !enemy.activeSelf);

        if (enemies.Count > 0)
        {
            var zxc = Vector3.Distance(transform.position, enemies[0].transform.position);
            target = enemies.Find(enemy => Vector3.Distance(transform.position, enemy.transform.position) < range);
            //Enemy in range
            //var x = Vector3.Distance(target.transform.position, transform.position);
            //if (x > range )
            //    target = null;
        }
        else
            target = null;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Fire() // !
    {
        var bullet = Instantiate(BulletPrefab, transform.position, transform.rotation).GetComponent<Bullet>();
        
        if(bullet != null)
            bullet.Seek(target.transform);
    }
}
