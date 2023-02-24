using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int range;

    bool CanShoot = true;
    bool isAimed = false;

    public Vector3 adsPos;
    public Vector3 hipPos;

    public GameObject explosionPrefab;
    public GameObject fpsCam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != hipPos | transform.localPosition != adsPos)
        {
            transform.localPosition = hipPos;
        }
        if (CanShoot && !isAimed && Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = adsPos;
            isAimed = true;
        }
        if (CanShoot && isAimed && !(Input.GetKey(KeyCode.Mouse1)))
        {
            transform.localPosition = hipPos;
            isAimed = true;
        }
        if (CanShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    async void Shoot()
    {
        GetComponentInChildren<ParticleSystem>().Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.name != "Player")
            {
                Instantiate(explosionPrefab, hit.point, hit.transform.rotation);
                await System.Threading.Tasks.Task.Delay(1000);
                Destroy(GameObject.Find("Explosion(Clone)"));
            }
        }


    }
}
