using UnityEngine;





public class generador : MonoBehaviour
{

    private float intervalomax; // intervalo de tiempo entre cada generacion de enemigo
    
    private float intervalomin; // intervalo de tiempo entre cada generacion de enemigo

    public GameObject[] obtaculos; // array de enemigos que se pueden generar

    private float timer = 0f; // temporizador para controlar el intervalo de generacion
    private float nexIntervalPrefab;// donde se generaran los enemigos


    public enum Dificultad // enum para definir la dificultad del juego va fuera de la clase generador para que pueda ser accedida desde el inspector de Unity
    {
        facil,
        normal,
        dificil
    }
    
    
    

    public Dificultad dificultad= Dificultad.normal;// variable para definir la dificultad del juego desde el inspector de Unity
    // serializeField permite que la variable sea privada pero aun asi pueda ser modificada desde el inspector de Unity




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        
       

        switch (dificultad) // se define la dificultad del juego
        {
            case Dificultad.facil:
                intervalomin = 1f;
                intervalomax = 2f;
                break;
            case Dificultad.normal:
                intervalomin = 0.5f;
                intervalomax = 1.5f;
                break;
            case Dificultad.dificil:
                intervalomin = 0.2f;
                intervalomax = 1f;
                break;
        }



         nexIntervalPrefab=Random.Range(intervalomin, intervalomax); // se genera un intervalo aleatorio entre el minimo y el maximo para la generacion de enemigos



    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime; // se incrementa el temporizador con el tiempo transcurrido desde el ultimo frame
        if (timer >= nexIntervalPrefab) // si el temporizador supera el intervalo de generacion
        {

            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f)
                                                , Random.Range(10f, 10f)
                                                , 0f); // se genera una posicion aleatoria para cada enemigo
            

            int indice = Random.Range(0, obtaculos.Length);
            Debug.Log($"Índice elegido: {indice}");
            Instantiate(obtaculos[indice], randomPosition, Quaternion.identity);
            Debug.Log($"{obtaculos[indice].name}");
            timer = 0f; // se reinicia el temporizador
            nexIntervalPrefab = Random.Range(intervalomin, intervalomax); // se genera un nuevo intervalo aleatorio
            
            
        }


        




        

        

        
    }

    
}
