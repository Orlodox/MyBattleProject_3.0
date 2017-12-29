using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locator : MonoBehaviour {

    GameObject parent;
    CircleCollider2D parentCircleCollider2D;
    Vector2 enemy;
    Collider2D[] collidersNearParent;
    Vector2[] pointOfBulletSpawn_directionOfShoot = new Vector2[2];
    string tagOfBullet = "Bullet";
    string tagOfLocator = "Locator";
    string tagOfBody = "Body";
    string tagOfAlly;

    void Awake () {
        parent = transform.parent.gameObject;
        parentCircleCollider2D = parent.GetComponent<CircleCollider2D>();
    }

    void SetTagOfAlly(string name)
    {
        tagOfAlly = name;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MonoBehaviour unit = collider.GetComponent<MonoBehaviour>();
        if (unit && unit.tag != tagOfBullet && !unit.tag.Contains(tagOfAlly) && !unit.tag.Contains(tagOfLocator) && unit.tag!=tagOfBody)
        {
            enemy.x = unit.transform.position.x;
            enemy.y = unit.transform.position.y;
            InvokeRepeating("Attack", 0f, 0.5f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        MonoBehaviour unit = collision.GetComponent<MonoBehaviour>();
        if (unit && unit.tag != tagOfBullet && !unit.tag.Contains(tagOfAlly) && !unit.tag.Contains(tagOfLocator) && unit.tag != tagOfBody)
        {
            enemy.x = unit.transform.position.x;
            enemy.y = unit.transform.position.y;
        }
        }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MonoBehaviour unit = collision.GetComponent<MonoBehaviour>();
        if (unit && unit.tag != tagOfBullet && !unit.tag.Contains(tagOfAlly) && !unit.tag.Contains(tagOfLocator))
            CancelInvoke("Attack");
    }

    private void Attack ()
    {
        pointOfBulletSpawn_directionOfShoot[0] = PointOfBulletSpawn();
        pointOfBulletSpawn_directionOfShoot[1] = DirectionOfShoot();
        if (!ShotWasFired())
            parent.SendMessage("Shoot", pointOfBulletSpawn_directionOfShoot);
    }

    private bool ShotWasFired()
    {
        collidersNearParent = Physics2D.OverlapCircleAll(transform.position, parentCircleCollider2D.bounds.extents.x * 1.2f);
        foreach (var item in collidersNearParent)
            if (item.tag == tagOfBullet && (Vector2)item.transform.position == pointOfBulletSpawn_directionOfShoot[0])
                return true;
        return false;
    }

    private Vector2 DirectionOfShoot()
    {
        Vector2 shootDirection;
        shootDirection = enemy - (Vector2)transform.position;
        shootDirection = shootDirection.normalized;
        return shootDirection;
    }

    private Vector2 RotationOfPoint(Vector2 point, Vector2 centre, float angle)
    {
        Vector2 resultPoint;
        resultPoint.x = centre.x + (point.x - centre.x) * Mathf.Cos(angle) - (point.y - centre.y) * Mathf.Sin(angle);
        resultPoint.y = centre.y + (point.y - centre.y) * Mathf.Cos(angle) + (point.x - centre.x) * Mathf.Sin(angle);
        return resultPoint;
    }

    private float AngleBetweenVectors(Vector2 v1, Vector2 v2)
    {
        float ang = Vector2.Angle(v1, v2);
        Vector3 cross = Vector3.Cross(v1, v2);
        if (cross.z < 0) ang = 360 - ang;
        ang *= Mathf.Deg2Rad;
        return ang;
    }

    private Vector2 PointOfBulletSpawn()
    {
        float angleRotatioin = AngleBetweenVectors(new Vector2(1.0f, 0.0f), DirectionOfShoot());
        Vector2 currentPoint = new Vector2(transform.position.x + parentCircleCollider2D.bounds.extents.x * 1.2f, transform.position.y);
        Vector2 pointOfBulletSpawn = RotationOfPoint(currentPoint, transform.position, angleRotatioin);
        return pointOfBulletSpawn;
    }



}
