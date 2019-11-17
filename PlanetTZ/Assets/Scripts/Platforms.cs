using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Platforms : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Image>().color = new Color(Random.Range(0,1f), Random.Range(0, 1f), Random.Range(0, 1f));
            MainManager.Instance.ballHit++;
            Debug.Log(MainManager.Instance.ballHit);
        }
    }

}
