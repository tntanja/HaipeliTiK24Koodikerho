using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;
    public GameObject bulletPrefab;
    public int poolSize = 20;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool() {
        for (int i = 0; i < poolSize; i++){
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.SetActive(false);
            bulletPool.Enqueue(newBullet);
        }
    }
}
