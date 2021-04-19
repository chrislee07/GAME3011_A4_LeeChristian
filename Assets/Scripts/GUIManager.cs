using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;

    public GameObject gameOverPanel;
    public GameObject grid;
    public GameObject winPanel;

    public Text TimeTxt;

    public static float startTime = 60;
    private float currTime = 0;


    // Start is called before the first frame update
    void Awake()
    {
        instance = GetComponent<GUIManager>();
        if (SkillLevel.skillLvl >= 2)
        {
            currTime = 80;
        }
        else
            currTime = startTime;
    }

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currTime > 0)
        {
            currTime -= 1 * Time.deltaTime;
            TimeTxt.text = "Time:  " + currTime.ToString("0");
            if(GridManager.cleared == true)
            {
                currTime = 99;
                winPanel.SetActive(true);
                grid.SetActive(false);
            }
        }
        else if(currTime <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        GameManager.instance.gameOver = true;

        gameOverPanel.SetActive(true);
        grid.SetActive(false);
    }

    public void Restart()
    {
        GridManager.cleared = false;
        winPanel.SetActive(false);
        grid.SetActive(true);
    }

}
