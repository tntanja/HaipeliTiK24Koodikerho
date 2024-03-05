using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
