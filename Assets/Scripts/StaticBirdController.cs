using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBirdController : MonoBehaviour
{
    GameObject nectar;

    // Start is called before the first frame update
    void Start()
    {
        float ShortestDistance = 100f;

        GameObject[] TempNectars = GameObject.FindGameObjectsWithTag("Nectar");

        foreach (GameObject gameobject in TempNectars)
        {
            float distance = Vector3.Distance(gameobject.transform.position, transform.position);

            if (distance < ShortestDistance)
            {
                ShortestDistance = distance;
                nectar = gameobject;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (nectar) {
            transform.RotateAround(nectar.transform.position, new Vector3(0f, -1f, 0f), 100 * Time.deltaTime);
        }
        else
        {
            transform.position += (transform.forward * Time.deltaTime * 7.5f);
            transform.Translate(transform.up * Time.deltaTime * 2.5f);
        }
    }
}
