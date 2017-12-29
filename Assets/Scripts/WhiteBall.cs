using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class WhiteBall : MonoBehaviour
{
    int hp = 3;
    float speed = 4.5F;
    string tagOfAlly = "White";

    SpriteRenderer spriteRend;
    Sprite[] spritesOfHP = new Sprite[3];
    Bullet bullet;
    GameObject locator;
    GameObject body;

    void Awake()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(RandomStartDirection());
        bullet = Resources.Load<Bullet>("Bullet");
        SetSpritesOfHP();

        locator = transform.Find("Locator").gameObject;
        locator.SendMessage("SetTagOfAlly", tagOfAlly);

        body = transform.Find("Body").gameObject;
        body.SendMessage("SetTagOfAlly", tagOfAlly);
    }

    Vector2 RandomStartDirection()
    {
        float randomAngle = Random.Range(0, 2 * Mathf.PI);
        Vector2 randomDirection = RotationOfPoint(new Vector2(1.0f, 0.0f), new Vector2(0.0f, 0.0f), randomAngle);
        randomDirection *= speed;
        return randomDirection;
    }

    Vector2 RotationOfPoint(Vector2 point, Vector2 centre, float angle)
    {
        Vector2 resultPoint;
        resultPoint.x = centre.x + (point.x - centre.x) * Mathf.Cos(angle) - (point.y - centre.y) * Mathf.Sin(angle);
        resultPoint.y = centre.y + (point.y - centre.y) * Mathf.Cos(angle) + (point.x - centre.x) * Mathf.Sin(angle);
        return resultPoint;
    }

    void Shoot(Vector2[] pointOfBulletSpawn_directionOfShoot) // [0] = pointOfBulletSpawn, [1] = directionOfShoot
    {
        Bullet newBullet = Instantiate(bullet, pointOfBulletSpawn_directionOfShoot[0], bullet.transform.rotation) as Bullet;
        newBullet.parent = gameObject;
        newBullet.Fire(pointOfBulletSpawn_directionOfShoot[1]);
    }

    public void ReceiveDamage()
    {
        hp--;
        //Debug.Log("White get damage: " + hp.ToString());
        if (hp > 0) spriteRend.sprite = spritesOfHP[hp - 1];
        else
            Destroy(gameObject);
    }

    void SetSpritesOfHP()
    {
        spriteRend = GetComponent<SpriteRenderer>();
       
        spritesOfHP[0] = Resources.Load<Sprite>("Ball_1_HP");
        spritesOfHP[1] = Resources.Load<Sprite>("Ball_2_HP");
        spritesOfHP[2] = Resources.Load<Sprite>("Ball_3_HP");

        spriteRend.sprite = spritesOfHP[2];
        spriteRend.color = Color.white;
    }
}