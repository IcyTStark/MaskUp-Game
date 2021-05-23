using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sanitize : MonoBehaviour
{
    [SerializeField] GameObject spray;
    [SerializeField] GameObject particleSpawn;
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
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.tag == "SickAffector")
                {
                    GameObject sprayThing = Instantiate(spray, hit.transform.position, Quaternion.identity);
                    GameObject particleToClean = Instantiate(particleSpawn, hit.transform.position, Quaternion.identity);
                    Destroy(sprayThing, 2f);
                    Destroy(particleToClean, 4f);
                    Destroy(hit.transform.gameObject, 2f);
                }
            }
        }
    }
}
