using UnityEngine;

public class obstaculo : MonoBehaviour
{

    public float fallSpeed = 5f; // velocidad de caida del obstaculo
    public float destroyHeight = -10f; // altura a la que se destruye el obstaculo

    public generador generador; // referencia al script generador para poder modificar la velocidad de caida de los enemigos

void Start()
    {
        generador = FindFirstObjectByType<generador>(); // se busca el script generador en la escena
        switch (generador.dificultad) // se define la dificultad del juego
        {
            case generador.Dificultad.facil:
                fallSpeed = 5f;
                break;
            case generador.Dificultad.normal:
                fallSpeed = 10f;
                break;
            case generador.Dificultad.dificil:
                fallSpeed = 15f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime); // se mueve el obstaculo hacia abajo a la velocidad especificada
        if (transform.position.y < destroyHeight) // si el obstaculo ha caido por debajo de la altura especificada
        {
            Destroy(gameObject); // se destruye el obstaculo
        }
    }
}
