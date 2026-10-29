using UnityEngine;
using UnityEngine.InputSystem;
//clase
public class MovementPlayer : MonoBehaviour
{

    public int vida = 3; // vida del jugador
    public float speed = 5f; // velocidad de movimiento del jugador
    private float xmin = -7.5f, xmax = 7.5f; // limites de movimiento del jugador en el eje x

    float direccion = 0f; // direccion del movimiento del jugador, -1 izquierda, 1 derecha


    

    // Update is called once per frame
    void Update()
    {
        //float movement = Input.GetAxis("Horizontal") * speed * Time.deltaTime; // se obtiene el movimiento horizontal del jugador
        //transform.Translate(movement, 0f, 0f); // se mueve el jugador en el eje x

        // sistema input nuevo
        Keyboard teclado = Keyboard.current; // se obtiene el teclado actual
        if(teclado!= null) // si el teclado no es nulo
        {
            if(teclado.aKey.isPressed || teclado.leftArrowKey.isPressed) // si se presiona la tecla A o la flecha izquierda
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime); // se mueve el jugador a la izquierda
            }
            if(teclado.dKey.isPressed || teclado.rightArrowKey.isPressed) // si se presiona la tecla D o la flecha derecha
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime); // se mueve el jugador a la derecha
            }
        }

            Gamepad gamepad = Gamepad.current; // se obtiene el gamepad actual
        if(gamepad != null && gamepad.leftStick.x.ReadValue() > 0.1f) // si el gamepad no es nulo
        {
           
          direccion += gamepad.leftStick.x.ReadValue(); // se mueve el jugador en la direccion del stick izquierdo
          transform.Translate(direccion * speed * Time.deltaTime, 0f, 0f); // se mueve el jugador en el eje x
            
            
        }


            


        Vector2 pos = transform.position; // se obtiene la posicion del jugador
        pos.x = Mathf.Clamp(pos.x, xmin, xmax); // se limita la posicion del jugador en el eje x
        transform.position = pos; // se actualiza la posicion del jugador
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstaculo")) // si el jugador colisiona con un obstaculo
        {
            obstaculo obstaculo = collision.gameObject.GetComponent<obstaculo>(); // se obtiene el componente obstaculo del objeto con el que colisiono
            if (obstaculo != null) // si el objeto con el que colisiono tiene un componente obstaculo
            {
                Debug.Log("vida: " + vida); // se imprime la vida del jugador en la consola
                vida--; // se resta una vida al jugador
                Destroy(collision.gameObject); // se destruye el obstaculo con el que colisiono
                if (vida <= 0) // si la vida del jugador es menor o igual a 0
                {
                    Destroy(gameObject); // se destruye el jugador
                }
            }
        }
    }
}
