using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
    public class ButtonExample : MonoBehaviour
    {
        public HoverButton hoverButton;

        public GameObject prefab;

        public GameObject table;

        private void Start()
        {
            hoverButton.onButtonDown.AddListener(OnButtonDown);
        }

        private void OnButtonDown(Hand hand)
        {
            print("button press!");
            StartCoroutine(Rotate(Vector3.up, 45, 1.0f));
        }

        IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
        {
            Quaternion from = table.transform.rotation;
            Quaternion to = table.transform.rotation;
            to *= Quaternion.Euler(axis * angle);

            float elapsed = 0.0f;
            while (elapsed < duration)
            {
                table.transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            table.transform.rotation = to;
        }

        private IEnumerator DoPlant()
        {
            table.transform.Rotate(new Vector3(0, 5, 0), Space.Self);
            yield return null;
            //GameObject planting = GameObject.Instantiate<GameObject>(prefab);
            //planting.transform.position = this.transform.position;
            //planting.transform.rotation = Quaternion.Euler(0, Random.value * 360f, 0);

            //planting.GetComponentInChildren<MeshRenderer>().material.SetColor("_TintColor", Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f));

            //Rigidbody rigidbody = planting.GetComponent<Rigidbody>();
            //if (rigidbody != null)
            //    rigidbody.isKinematic = true;


            //Vector3 initialScale = Vector3.one * 0.01f;
            //Vector3 targetScale = Vector3.one * (1 + (Random.value * 0.25f));

            //float startTime = Time.time;
            //float overTime = 0.5f;
            //float endTime = startTime + overTime;

            //while (Time.time < endTime)
            //{
            //    planting.transform.localScale = Vector3.Slerp(initialScale, targetScale, (Time.time - startTime) / overTime);
            //    yield return null;
            //}


            //if (rigidbody != null)
            //    rigidbody.isKinematic = false;
        }
    }
}