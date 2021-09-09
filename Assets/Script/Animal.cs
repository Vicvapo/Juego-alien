using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] int lifepoints;
    int Contador = 3;
    int Reserva;
    float tiempo = 5f;
   
    float minX, maxX;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
        Reserva = lifepoints;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.captureDeltaTime;
        if(Contador>= 1)
        {
            if(Input.GetKeyDown(KeyCode.X))
            {
                Time.timeScale = 0.5f;
                lifepoints = 1;
            }
            if(tiempo <=0)
            {
                Time.timeScale = 1f;
                Contador--;
                tiempo = 5f;
                lifepoints = Reserva;
            }
        }
      
        if(movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);

        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);

        }
        if (transform.position.x >= maxX)
        {
            movingRight = false;

        }
        else if( transform.position.x <= minX)
        {
            movingRight = true;
        }
          
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject objeto = collision.gameObject;
         string etiqueta = objeto.tag;
        if(etiqueta== "disparo")
        {
            lifepoints--;
            if(lifepoints==0)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).numeroanimales();
                Destroy(this.gameObject);

            }

        }
    }
}
