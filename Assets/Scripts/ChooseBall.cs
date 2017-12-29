using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseBall : MonoBehaviour
{
    GameObject panelOfExt;
    GameObject desBall;
    GameObject squareExt, triangleExt, starExt;
    GameObject squareCell, triangleCell, starCell;

    private void Start()
    {
        desBall = transform.parent.Find("DesignedBall").gameObject;

        panelOfExt = transform.parent.parent.Find("Extensions").gameObject;

        squareCell = panelOfExt.transform.Find("SquareCell").gameObject;
        triangleCell = panelOfExt.transform.Find("TriangleCell").gameObject;
        starCell = panelOfExt.transform.Find("StarCell").gameObject;

        squareExt =squareCell.transform.Find("SquareExt").gameObject;
        triangleExt = triangleCell.transform.Find("TriangleExt").gameObject;
        starExt = starCell.transform.Find("StarExt").gameObject;
    }

    public void OnClick()
    {
        if (Main.currentDesignedBall == null)
        {
            Main.currentDesignedBall = gameObject.name;
            desBall.SendMessage("SetImageOfBall");
        }
        else
        {
            DesignedBall.SetCurrentExtensions();
            Main.currentDesignedBall = gameObject.name;
            desBall.SendMessage("SetImageOfBall");
            ShowExtensionsOnDesBall();
        }

    }

    public void ShowExtensionsOnDesBall()
    {
        int warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString()) - 1;
        if (Main.currentDesignedBall.Contains("White"))
            warrior += 3;
        GameObject ext, extCell;
        for (int i = 0; i < 3; i++)
        {
            switch (i)
            {
                case 0:
                    ext = squareExt;
                    extCell = squareCell;
                    break;
                case 1:
                    ext = triangleExt;
                    extCell = triangleCell;
                    break;
                case 2:
                    ext = starExt;
                    extCell = starCell;
                    break;
                default:
                    ext = null;
                    extCell = null;
                    break;
            }
            if (Main.extensions[warrior, i].z < 0f)
            {
                ext.transform.SetParent(desBall.transform);
                ext.transform.localPosition = (Main.extensions[warrior, i] * (Main.radOfDesBall / Main.radOfWarrior));
            }
            else
            {
                ext.transform.SetParent(extCell.transform);
                ext.transform.position = extCell.transform.position;
            }

        }
    }
}
