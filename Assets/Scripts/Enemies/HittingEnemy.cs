using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HittingEnemy : Enemy
{
    [SerializeField] float speed = 3.5f;
    [SerializeField] float nextWaypointDistance = 1.3f;
    [SerializeField] Transform target;
    [SerializeField] bool isReversed = true;
    Path path;
    int currentWaypoint = 0;
    Seeker seeker;
    Rigidbody2D rb2d;
    bool isMoving = true;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        seeker = GetComponent<Seeker>();
        rb2d = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0, .5f);        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 || !isMoving)
        {
            CancelInvoke();
            return;
        }
        if (path == null)
            return;
        if (currentWaypoint >= path.vectorPath.Count)
            return;
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb2d.position).normalized;
        if (direction.x < 0)
            transform.localScale = new Vector3(isReversed ? 2 : -2, 2, 2);
        else if (direction.x > 0)
            transform.localScale = new Vector3(isReversed ? -2 : 2, 2, 2);
        transform.Translate(direction * speed * Time.deltaTime);
        animator.SetFloat("Speed", direction.magnitude * speed);
        float distance = Vector2.Distance(rb2d.position, path.vectorPath[currentWaypoint]);
        if (distance < nextWaypointDistance)
            currentWaypoint++;
    }

    void UpdatePath()
    {
        if (seeker.IsDone() && target != null)
            seeker.StartPath(rb2d.position, (Vector2)target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
