using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        if (etiqueta == "animal")
        {
            Destroy(this.gameObject);

        }
        if (etiqueta=="piso")
        {
            Destroy(this.gameObject);
        }*/ 
        GameObject objeto = collision.gameObject;
        string etiqueta = objeto.tag;
        Destroy(this.gameObject);

    }

}
