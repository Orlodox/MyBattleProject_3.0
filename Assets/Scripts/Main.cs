using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public static Vector3[,] extensions = new Vector3[6, 3];
    // [0, ] - BlueWarrior (1), [1, ] - BlueWarrior (2), [2, ] - BlueWarrior (3), [3, ] - WhiteWarrior (1) ... [ ,0] - Square, [ ,1] - Triangle, [ ,2] - Star
    public static string currentDesignedBall;
    public static float radOfDesBall = 145f;
    public static float radOfWarrior = 2.6f;

    BlueBall bball;
    WhiteBall wball;
    GameObject panel;
    Square square;
    Triangle triangle;
    Star star;
    int jiEst = 0;

    void Awake()
    {
        bball = Resources.Load<BlueBall>("BlueWarrior");
        wball = Resources.Load<WhiteBall>("WhiteWarrior");
        panel = transform.Find("Panel").gameObject;
        square = Resources.Load<Square>("Square");
        triangle = Resources.Load<Triangle>("Triangle");
        star = Resources.Load<Star>("Star");
    }

    public void GoClick()
    {
        DesignedBall.SetCurrentExtensions();
        panel.transform.parent.gameObject.SetActive(false);
        CreateWarriors();
    }

    public void CreateWarriors()
    {
        BlueBall bball_1 = Instantiate(bball, new Vector3(-6.5f, 3.5f, 0f), Quaternion.identity) as BlueBall;
        BlueBall bball_2 = Instantiate(bball, new Vector3(-3f, 0f, 0f), Quaternion.identity) as BlueBall;
        BlueBall bball_3 = Instantiate(bball, new Vector3(-6.5f, -3.5f, 0f), Quaternion.identity) as BlueBall;

        WhiteBall wball_1 = Instantiate(wball, new Vector3(6.5f, 3.5f, 0f), Quaternion.identity) as WhiteBall;
        WhiteBall wball_2 = Instantiate(wball, new Vector3(3f, 0f, 0f), Quaternion.identity) as WhiteBall;
        WhiteBall wball_3 = Instantiate(wball, new Vector3(6.5f, -3.5f, 0f), Quaternion.identity) as WhiteBall;

        foreach (var warrior in new GameObject[] { bball_1.gameObject, bball_2.gameObject, bball_3.gameObject, wball_1.gameObject, wball_2.gameObject, wball_3.gameObject })
        {
            AddExtensions(warrior);
            jiEst++;
            jiEst = jiEst % 3;
        }
    }

    public void AddExtensions(GameObject warrior)
    {
        int numberOfWarrior = jiEst;
        if (warrior.name.Contains("White")) numberOfWarrior += 3;

        for (int i = 0; i < 3; i++)
            if (extensions[numberOfWarrior, i].z < 0f)
                switch (i)
                {
                    case 0:
                        Square newSquare = Instantiate(square, extensions[numberOfWarrior, i], Quaternion.identity);
                        newSquare.transform.parent = warrior.transform;
                        newSquare.transform.localPosition = extensions[numberOfWarrior, i];
                        newSquare.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                        break;
                    case 1:
                        Triangle newTriangle = Instantiate(triangle, extensions[numberOfWarrior, i], Quaternion.identity);
                        newTriangle.transform.parent = warrior.transform;
                        newTriangle.transform.localPosition = extensions[numberOfWarrior, i];
                        newTriangle.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                        break;
                    case 2:
                        Star newStar = Instantiate(star, extensions[numberOfWarrior, i], Quaternion.identity);
                        newStar.transform.parent = warrior.transform;
                        newStar.transform.localPosition = extensions[numberOfWarrior, i];
                        newStar.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
                        break;
                    default: break;
                }
    }
}

