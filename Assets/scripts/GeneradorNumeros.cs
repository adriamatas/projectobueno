using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;
    private Vector2 minPantalla, maxPantalla;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        InvokeRepeating("GenerarNumero", 1f, 2f);  
    }
    private void GenerarNumero()
    {
        GameObject numero = Instantiate(prefabNum);


        numero.transform.position = new Vector2(Random.Range(minPantalla.x, maxPantalla.x) , maxPantalla.y);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
