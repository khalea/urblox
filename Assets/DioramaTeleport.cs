using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioramaTeleport : MonoBehaviour
{
    public GameObject button;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        Debug.Log("Something is in here");
        player.transform.localScale -= new Vector3(6F, 6F, 6F);
        player.transform.position = new Vector3(15.56f, 8.77f, 5.15f);
        //button.transform.Translate(Vector3.down); 
        //table.transform.Rotate(new Vector3(0, 5, 0), Space.Self);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
