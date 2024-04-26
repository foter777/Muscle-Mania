using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyControls : MonoBehaviour
{
    public float lifetime;
    // Start is called before the first frame update
    private void Awake() {
        Destroy(gameObject,lifetime);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
