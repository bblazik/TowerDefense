using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 7f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {

        if(target == null) // Destroy if enemy disapers. To change.
        {
            Destroy(gameObject);
            return;
        }

        var dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            //Hit
            HitTarget();
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World );

    }

    private void HitTarget()
    {
        Destroy(gameObject);
        Destroy(target.gameObject);
        Debug.Log("Hit");
    }

}
