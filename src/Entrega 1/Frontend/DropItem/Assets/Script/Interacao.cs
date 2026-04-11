using UnityEngine;

public class Interacao : MonoBehaviour
{
    public Transform pontoDaMao; // Onde o item vai ficar grudado
    public float distanciaParaPegar = 3f; // Qual a distância do braço
    private GameObject itemSegurado; // Guarda qual item estamos segurando

    void Update()
    {
        // Se apertar o botão esquerdo do mouse (0) ou a tecla E
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemSegurado == null)
            {
                TentarPegarItem();
            }
            else
            {
                SoltarItem();
            }
        }
    }

    void TentarPegarItem()
    {
        RaycastHit hit;
        // Lança um "raio" invisível do centro da câmera para frente
        if (Physics.Raycast(transform.position, transform.forward, out hit, distanciaParaPegar))
        {
            // Se o raio bater em algo com a Tag "Item"
            if (hit.collider.CompareTag("Item"))
            {
                itemSegurado = hit.collider.gameObject;

                // Desativa a física para ele não cair enquanto seguramos
                itemSegurado.GetComponent<Rigidbody>().isKinematic = true;

                // Gruda o item na nossa mão
                itemSegurado.transform.SetParent(pontoDaMao);
                itemSegurado.transform.localPosition = Vector3.zero;
                itemSegurado.transform.localRotation = Quaternion.identity;
            }
        }
    }

    void SoltarItem()
    {
        // Devolve a física ao objeto
        itemSegurado.GetComponent<Rigidbody>().isKinematic = false;

        // Tira o item de dentro da mão (limpa o "pai")
        itemSegurado.transform.SetParent(null);
        itemSegurado = null;
    }
}
