using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    GameObject parent;
    public string tagOfBullet = "Bullet";
    public string tagOfLocator = "Locator";
    public string tagOfAlly;


    void Awake () {
        parent = transform.parent.gameObject;
    }

    void SetTagOfAlly(string name)
    {
        tagOfAlly = name;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MonoBehaviour unit = collider.GetComponent<MonoBehaviour>();
        if (unit && unit.tag == tagOfBullet)
            ReceiveDamage();
    }

    private void ReceiveDamage()
    {
        parent.SendMessage("ReceiveDamage");
    }
}
