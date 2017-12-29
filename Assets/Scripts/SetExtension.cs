using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class SetExtension : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public GameObject cell;
    private Transform desBall;
    Camera c;

    void Start()
    {
        cell = transform.parent.gameObject;
        desBall = GameObject.Find("DesignedBall").transform;
        c =  Camera.main;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Main.currentDesignedBall != null)
        {
            transform.SetParent(desBall);
            transform.position = c.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, 5f));
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Math.Sqrt(Math.Pow(transform.localPosition.x, 2) + Math.Pow(transform.localPosition.y, 2)) > Main.radOfDesBall)
        {
            transform.SetParent(cell.transform);
            transform.position = transform.parent.position;
        }
    }
}