using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class SkillLevel : MonoBehaviour
{
    public static int skillLvl;
    public Text lvlTxt;

    // Start is called before the first frame update
    void Start()
    {
        skillLvl = 0;
    }

    public void Increase()
    {
        if (skillLvl < 3)
        {
            skillLvl++;
            lvlTxt.text = skillLvl.ToString();
        }
    }

    public void Decrease()
    {
        if (skillLvl > 0)
        {
            skillLvl--;
            lvlTxt.text = skillLvl.ToString();
        }
    }


}
