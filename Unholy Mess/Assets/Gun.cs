using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    bool CanShoot = true;
    bool isAimed = false;

    public Vector3 adsPos;
    public Vector3 hipPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAimed && !CanShoot && Input.GetKey(KeyCode.Mouse1))
        {
            transform.position = adsPos;
            isAimed = true;
        }
        if (CanShoot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        
    }
}
