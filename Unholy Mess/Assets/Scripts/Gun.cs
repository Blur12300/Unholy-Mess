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

    float n = 0;

    // Update is called once per frame
    void Update()
    {
        if (transform.localPosition != hipPos && transform.localPosition != adsPos)
        {
            transform.localPosition = hipPos;
        }

        if (!isAimed && Input.GetKey(KeyCode.Mouse1))
        {
            transform.localPosition = adsPos;
            isAimed = true;
        }
        if (isAimed && !(Input.GetKey(KeyCode.Mouse1)))
        {
            transform.localPosition = hipPos;
            isAimed = false;
        }
        if (CanShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    async void Shoot()
    {
        CanShoot = false;
        GetComponentInChildren<ParticleSystem>().Play();

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.name != "Player")
            {
                Instantiate(explosionPrefab, hit.point, hit.transform.rotation);

                await System.Threading.Tasks.Task.Delay(500);
                Destroy(GameObject.Find("Explosion(Clone)"));
                CanShoot = true;
                await System.Threading.Tasks.Task.Delay(500);
                Destroy(GameObject.Find("Explosion(Clone)"));
            }
        }
    }
}
