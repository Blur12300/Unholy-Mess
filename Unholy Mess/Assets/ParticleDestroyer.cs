using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroyer : MonoBehaviour
{
    // Update is called once per frame
    async void Update()
    {
        await System.Threading.Tasks.Task.Delay(1000);
        Destroy(gameObject);
    }
}
