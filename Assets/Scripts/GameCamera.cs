using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Game").GetComponent<Game>().Camera=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveTo(Vector3 position)
    {
        this.gameObject.transform.position = position;
    }
    public void MoveTo(GameObject position)
    {
        this.gameObject.transform.position = position.transform.position;
    }
}
