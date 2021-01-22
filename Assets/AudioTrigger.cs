using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    AudioSource selenaVoice;

    // Start is called before the first frame update
    void Start()
    {
        selenaVoice = GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        selenaVoice.Play();
    }


    private void OnTriggerExit(Collider other)
    {
        selenaVoice.Stop();
    }
}
