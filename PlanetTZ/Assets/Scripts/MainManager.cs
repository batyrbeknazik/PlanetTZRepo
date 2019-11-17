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

    public GameObject ball;
    public GameObject panel;

    public GameObject playCanvas;
    public GameObject menuCanvas;

    private static MainManager _instance;

    public Text ballHitText;

    public int ballHit = 0;


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
        ballHitText.text = "BallHit: " + ballHit.ToString();


    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            menuCanvas.SetActive(true);
            playCanvas.SetActive(false);
            ballHitText.text = "BallHit: "+ballHit.ToString();
            ball.transform.position = new Vector3(-4f, 0f,0f);
        }


    }
    public void ChangeScene(string planet)
    {
        Planet planeta = new Planet();
        //Moon moon = new Moon();
        //Jupiter jupiter = new Jupiter();
        //Debug.Log("load scene");

        //void SceneLoadedEvent(Scene scene, LoadSceneMode mode)
        //{

        //}
        menuCanvas.SetActive(false);
        playCanvas.SetActive(true);
        switch (planet)
        {
            case "earth":
                planeta.ChangeDecoration(earth_script_obj, panel, ball);
                //gameController.Instance.Init(earth_script_obj.skycolor,earth_script_obj.gravity);

                break;
            case "moon":
                //planeta.ChangeDecoration(moon_script_obj, panel, ball);
                planeta.ChangeDecoration(moon_script_obj, panel, ball);

                break;
            case "jupiter":
                //planeta.ChangeDecoration(jupiter_script_obj, panel, ball);
                planeta.ChangeDecoration(jupiter_script_obj, panel, ball);

                break;


        }
        //SceneManager.sceneLoaded += SceneLoadedEvent;
        //SceneManager.LoadScene("PlanetScene");
        //SceneManager.sceneLoaded -= SceneLoadedEvent;
        //Debug.Log("123");
        
        
    }

}

interface IPlanet
{
    float gravity { get; set; }
    Sprite skycolor { get; set; }

    void ChangeDecoration(PlanetScriptableObjectScript planet, GameObject backgroundColor, GameObject ball);


}
class Planet : IPlanet
{
    

    public float gravity { get; set; }
    public Sprite skycolor { get; set; }
    
    public void ChangeDecoration(PlanetScriptableObjectScript planet,GameObject backgroundColor,GameObject ball)
    {
        gravity = planet.gravity;
        skycolor = planet.skycolor;
        backgroundColor.GetComponent<Image>().sprite = skycolor;

        ball.GetComponent<Ball>().bouncy.bounciness = gravity/10f;
        Debug.Log(gravity);
    }

    
}

//class Moon : IPlanet
//{


//    public float gravity { get; set; }
//    public Sprite skycolor { get; set; }
//    public void ChangeDecoration(PlanetScriptableObjectScript planet, GameObject backgroundColor, GameObject ball)
//    {
//        gravity = planet.gravity;
//        skycolor = planet.skycolor;
//        backgroundColor.GetComponent<Image>().sprite = skycolor;
//        ball.GetComponent<Ball>().bouncy.bounciness = gravity;
//        //Debug.Log(gravity);
//    }


//}

//class Jupiter : IPlanet
//{


//    public float gravity { get; set; }
//    public Sprite skycolor { get; set; }
//    public void ChangeDecoration(PlanetScriptableObjectScript planet, GameObject backgroundColor, GameObject ball)
//    {
//        gravity = planet.gravity;
//        skycolor = planet.skycolor;
//        backgroundColor.GetComponent<Image>().sprite = skycolor;
//        ball.GetComponent<Ball>().bouncy.bounciness = gravity;
//        //Debug.Log(gravity);
//    }


//}