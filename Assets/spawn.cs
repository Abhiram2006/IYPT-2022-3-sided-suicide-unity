using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject die;
    public int no_of_die;
    public float velocity;
    public float w;
    public float time;
    public float ratio=1;
    int num = 0;
    bool j = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(die.GetComponent<MeshRenderer>().bounds.size);
        die.transform.localScale = new Vector3(die.transform.localScale.x, (die.transform.localScale.y * die.GetComponent<MeshRenderer>().bounds.size.x*ratio) / die.GetComponent<MeshRenderer>().bounds.size.y, die.transform.localScale.z);
        for (int i=0; i < no_of_die; i++)
        {
            sp();

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= time&(!j))
        {
            foreach (Transform die_c in gameObject.GetComponentInChildren<Transform>())
            {
                num += measure(die_c);
            }
            Debug.Log(num); Debug.Log((num*1.0)/no_of_die);
            j = true;
        }
    }
    void sp()
    {
        GameObject c_die = Instantiate(die,transform);
        c_die.transform.position = transform.position;
        c_die.GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*w;
        c_die.GetComponent<Rigidbody>().velocity = Random.insideUnitSphere*velocity;
    }
    public int measure(Transform obj)
    {
        float a = Vector3.Angle(Vector3.up, obj.transform.up);
        if (a < 45||a>135)
        {
            return 0;
        }
        else
        {
            return 1;

        }
    }
}
