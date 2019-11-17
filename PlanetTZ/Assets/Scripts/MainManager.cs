using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

    public PlanetScriptableObjectScript earth_script_obj;
    public PlanetScriptableObjectScript moon_script_obj;
    public PlanetScriptableObjectScript jupiter_script_obj;

    protected GameObject panel;
    protected GameObject ball;


    private static MainManager _instance;

    public static MainManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MainManager();
            }
            return _instance;
        }
    }


    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }
    public void ChangeScene(string planet)
    {
        Earth earth = new Earth();
        //Moon moon = new Moon();
        //Jupiter jupiter = new Jupiter();
        panel = GameObject.Find("Canvas/Panel");
        ball = GameObject.Find("Canvas/Panel/ball");

        SceneManager.LoadScene("PlanetScene");
        switch (planet)
        {
            case "earth":
                earth.ChangeDecoration(earth_script_obj,panel,ball);
                break;
            //case "moon":
            //    moon.ChangeDecoration(moon_script_obj);
            //    break;
            //case "jupiter":
            //    jupiter.ChangeDecoration(jupiter_script_obj);
            //    break;


        }
        
    }

}

interface IPlanet
{
    float gravity { get; set; }
    Sprite skycolor { get; set; }

    void ChangeDecoration(PlanetScriptableObjectScript planet, GameObject backgroundColor, GameObject ball);


}
class Earth : IPlanet
{
    

    public float gravity { get; set; }
    public Sprite skycolor { get; set; }
    
    public void ChangeDecoration(PlanetScriptableObjectScript planet,GameObject backgroundColor,GameObject ball)
    {
        gravity = planet.gravity;
        skycolor = planet.skycolor;
        backgroundColor.GetComponent<Image>().sprite = skycolor;
        ball.GetComponent<Ball>().bouncy.bounciness = gravity;
        //Debug.Log(gravity);
    }

    
}

//class Moon : IPlanet
//{


//    public float gravity { get; set; }
//    public Sprite skycolor { get; set; }
//    public void ChangeDecoration(PlanetScriptableObjectScript planet)
//    {
//        gravity = planet.gravity;
//        skycolor = planet.skycolor;
//        Debug.Log(gravity);
//    }


//}

//class Jupiter : IPlanet
//{


//    public float gravity { get; set; }
//    public Sprite skycolor { get; set; }
//    public void ChangeDecoration(PlanetScriptableObjectScript planet)
//    {
//        gravity = planet.gravity;
//        skycolor = planet.skycolor;
//        Debug.Log(gravity);
//    }


//}