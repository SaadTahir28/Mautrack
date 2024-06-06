using UnityEngine;

namespace PolySpatial.Template
{
    public class TagSearch : MonoBehaviour
    {
        public string[] tagsToSearch;

        void Start()
        {
            // Busca objetos con las etiquetas especificadas
            foreach (string tag in tagsToSearch)
            {
                GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject obj in taggedObjects)
                {
                    Debug.Log(obj.name + " tiene la etiqueta " + tag);
                }
            }
        }

        public void DisableObjectsWithTag()
        {
            foreach (string tag in tagsToSearch)
            {
                GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
                foreach (GameObject obj in taggedObjects)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
}
