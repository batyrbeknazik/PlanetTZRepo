using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public PhysicsMaterial2D bouncy;
    // Start is called before the first frame update
    void Start()
    {
        

       
        
        Debug.Log(bouncy.bounciness);

        //Debug.Log(MainManager.Instance.earth_script_obj.gravity);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var mouseDir = mousePos - gameObject.transform.position;
            mouseDir.z = 0.0f;
            mouseDir = mouseDir.normalized;

            gameObject.GetComponent<Rigidbody2D>().AddForce(mouseDir*500);
            //Debug.Log(gameObject.transform.position);
            //Debug.Log(Input.mousePosition);
        }
    }

    

    
}
