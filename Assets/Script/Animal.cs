using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] GameManager gm;
    [SerializeField] int lifepoints;
    bool cont = true;
    int Contador = 1;
    int Reserva2;
    int Reserva;
    float tiempo = 0;
    float Limitime = 5;
  

   
    float minX, maxX, maxY, minY;

    // Start is called before the first frame update
    void Start()
    {
        Reserva2 = Contador;
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaSupIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
        maxY = esquinaSupDer.y;
        minY = esquinaSupIzq.y;
        Reserva = lifepoints;
    }

    // Update is called once per frame
    void Update()
    {
        if(cont==true)
        {
            power();
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
     private void power()
    {
        if (Input.GetKeyDown(KeyCode.X) && Time.unscaledTime >= tiempo)
        {
            Time.timeScale = 0.5f;
           //lifepoints = 1;
            tiempo = Time.unscaledTime + Limitime;
            Reserva = lifepoints;
            lifepoints = 1;
            Reserva2 = Reserva2 + 1;
        }
        if (tiempo <= Time.unscaledTime)
        {
            Time.timeScale = 1f;
            lifepoints = Reserva;
            if (Reserva2 == 4)
            {
                cont = false;
            }
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
