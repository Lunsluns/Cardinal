using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour
{
    //public Vector3 rockScaling;public Vector3 treeScaling;
    public Camera cam;
    public GameObject player;
    public LayerMask mask;
    public UnityEngine.UI.Button truth;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = cam.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, ray.origin, 1000f, mask.value);
        Debug.DrawLine(transform.position, ray.origin, Color.green);

        truth.transform.position = new Vector3(ray.origin.x, ray.origin.y, 0f);
        if (hit.collider != null)
        {
            if(hit.collider.tag == "Tree" || hit.collider.tag == "Rock")
            {
                truth.image.color = Color.green;
            }
            else
            {
                truth.image.color = Color.red;
            }
        }
        else
        {
            truth.image.color = Color.red;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                switch (hit.collider.tag)
                {
                    case "Tree":
                        if (hit.collider.GetComponent<Rigidbody2D>().transform.localScale.x <= 3f)
                        {
                            hit.collider.GetComponent<Rigidbody2D>().transform.localScale *= 1.5f;
                        }
                        break;
                    case "Rock":
                        if (hit.collider.GetComponent<Rigidbody2D>().transform.localScale.x <= 3f)
                        {
                            hit.collider.GetComponent<Rigidbody2D>().transform.localScale *= 1.5f;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                switch (hit.collider.tag)
                {
                    case "Tree":
                        if (hit.collider.GetComponent<Rigidbody2D>().transform.localScale.x >= .333f)
                        {
                            hit.collider.GetComponent<Rigidbody2D>().transform.localScale *= .666f;
                        }
                        break;
                    case "Rock":
                        if (hit.collider.GetComponent<Rigidbody2D>().transform.localScale.x >= .333f)
                        {
                            hit.collider.GetComponent<Rigidbody2D>().transform.localScale *= .666f;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
