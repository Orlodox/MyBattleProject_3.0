using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignedBall : MonoBehaviour {

    public static Transform thisTrans;
    
    void Awake () {
        thisTrans = transform;
	}
	
    void SetImageOfBall ()
    {
        gameObject.GetComponent<UnityEngine.UI.Image>().sprite = Resources.Load<Sprite>("Ball_3_HP");
        if (Main.currentDesignedBall.Contains("Blue"))
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
        else
            gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.white;
    }

    public static void SetCurrentExtensions ()
    {
        int warrior;

        if (thisTrans.FindChild("SquareExt"))
        {
            GameObject ext = thisTrans.FindChild("SquareExt").gameObject; 
            warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString())-1;
            if (Main.currentDesignedBall.Contains("White"))
                warrior += 3;
            Main.extensions[warrior, 0] = (ext.transform.localPosition * (Main.radOfWarrior / Main.radOfDesBall));
            Main.extensions[warrior, 0].z = -0.1f;
         // Debug.Log(string.Format("{0} : {1} [{2} {3} {4}]", Main.currentDesignedBall, ext.transform.name, Main.extensions[warrior, 0].x, Main.extensions[warrior, 0].y, Main.extensions[warrior, 0].z));
        }
        else
        if (Main.currentDesignedBall != null)
        {
                warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString()) - 1;
            if (Main.currentDesignedBall.Contains("White"))
                warrior += 3;
            Main.extensions[warrior, 0].z = 0f; // if z==0 then extension is absent, but if z==0.1f then extension is present
        }

        if (thisTrans.FindChild("TriangleExt"))
        {
            GameObject ext = thisTrans.FindChild("TriangleExt").gameObject;
            warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString()) - 1;
            if (Main.currentDesignedBall.Contains("White"))
                warrior += 3;
            Main.extensions[warrior, 1] = (ext.transform.localPosition * (Main.radOfWarrior / Main.radOfDesBall));
            Main.extensions[warrior, 1].z = -0.1f;
         // Debug.Log(string.Format("{0} : {1} [{2} {3} {4}]", Main.currentDesignedBall, ext.transform.name, Main.extensions[warrior, 1].x, Main.extensions[warrior, 1].y, Main.extensions[warrior, 1].z));
        }
        else if (Main.currentDesignedBall != null)
        {
            warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString()) - 1;
            if (Main.currentDesignedBall.Contains("White"))
                warrior += 3;
            Main.extensions[warrior, 1].z = 0f; // if z==0 then extension is absent, but if z==0.1f then extension is present
        }

        if (thisTrans.FindChild("StarExt"))
        {
            GameObject ext = thisTrans.FindChild("StarExt").gameObject;
            warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString()) - 1;
            if (Main.currentDesignedBall.Contains("White"))
                warrior += 3;
            Main.extensions[warrior, 2] = (ext.transform.localPosition * (Main.radOfWarrior / Main.radOfDesBall));
            Main.extensions[warrior, 2].z = -0.1f;
         // Debug.Log(string.Format("{0} : {1} [{2} {3} {4}]", Main.currentDesignedBall, ext.transform.name, Main.extensions[warrior, 2].x, Main.extensions[warrior, 2].y, Main.extensions[warrior, 2].z));
        }
        else if(Main.currentDesignedBall != null)
        {
            warrior = int.Parse(Main.currentDesignedBall[Main.currentDesignedBall.IndexOf("(") + 1].ToString()) - 1;
            if (Main.currentDesignedBall.Contains("White"))
                warrior += 3;
            Main.extensions[warrior, 2].z = 0f; // if z==0 then extension is absent, but if z==0.1f then extension is present
        }
    }
}
