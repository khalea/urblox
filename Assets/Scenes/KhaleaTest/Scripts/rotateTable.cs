using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rotateTable : MonoBehaviour
{
  public GameObject btn;
  public GameObject table;
  public float speed;

  Collider btnObjCollider;


    // Start is called before the first frame update
    void Start()
    {
      //Fetch the GameObject's Collider (make sure they have a Collider component)
        btnObjCollider = GetComponent<Collider>();
        //Here the GameObject's Collider is not a trigger
        btnObjCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnCollisionEnter(Collision collison) {

      // TODO Animate button to slowly come back to y = 1 after collision enter

      // Button Y goes down by 1
      //btn.transform.Translate(0, -1, 0);

      // Rotate table by 120 deg and then stop
      table.transform.Rotate(new Vector3(0, 120, 0), Space.Self);

      // Button Y goes up by 1
      //btn.transform.Translate(0, 1, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something is in here");
        table.transform.Rotate(new Vector3(0, 120, 0), Space.Self);
    }
}
