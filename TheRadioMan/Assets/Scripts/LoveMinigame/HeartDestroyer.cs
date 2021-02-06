using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDestroyer : MonoBehaviour
{
    public HeartManager manager;
    private List<GameObject> hearts = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {List<GameObject> destroyedHearts = new List<GameObject>();
        foreach(GameObject h in hearts) {
            if(h.transform.position.x <= transform.position.x){
                print(h.transform.position); 
                destroyedHearts.Add(h);
            }
        }

        foreach(GameObject h in destroyedHearts) {
            DestroyHeart(h);
        }
    }

    public void SetHeartList(List<GameObject> heartList) {
        hearts = heartList;
    }

    private void DestroyHeart(GameObject _heart) {
        manager.RequestDestroy(_heart);
    }
}
