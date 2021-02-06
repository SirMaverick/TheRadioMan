using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHeartbeat : MonoBehaviour
{
    // Start is called before the first frame update

    public Vector3 movementSpeed = new Vector3(-3, 0, 0);

    void Start() {
        StartCoroutine(Move());
        print("Start");
    }

    private IEnumerator Move() {
        yield return new WaitForSeconds(0.3f);
        Slide();
    }

    void Slide() {
        Vector3 currentPos = transform.position;
        Vector3 newPos = currentPos + movementSpeed;
        transform.position = newPos;
        StartCoroutine(Move());
    }

    public void RequestDestroy() {
        StopAllCoroutines();
        Selfdestruct();
    }

    private void Selfdestruct() {
        Destroy(gameObject);
    }

}
