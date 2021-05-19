using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanitize : MonoBehaviour
{
    [SerializeField] GameObject spray;
    //[SerializeField] Animation animation;
    [SerializeField] Animator anim;
    bool buttonClicked;
    private void Update()
    {
        Sanitizing();
    }

    private void Start()
    {
        //sprayParticle.SetActive(false);
        //spray.SetActive(false);
    }
    public void Sanitizing()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.gameObject.tag == "SickAffector")
                {
                    Debug.Log("Im being Hit");
                    GameObject sprayThing = Instantiate(spray, hitInfo.transform.position, Quaternion.identity);
                    //Instantiate(anim, hitInfo.transform.position, Quaternion.identity);
                    anim.Play("cleaning");
                    Destroy(sprayThing, 2f);
                    Destroy(hitInfo.transform.gameObject, 2f);
                }
            }
        }
    }
}
