using UnityEngine;

public class GeneradorNumeros : MonoBehaviour
{
    [SerializeField] private GameObject prefabNum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("GenerarNumero", 1f, 2f);  
    }
    privatevoid GenerarNumero()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
