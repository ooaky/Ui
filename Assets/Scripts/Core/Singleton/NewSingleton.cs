using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Singleton {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour // parametro T pode apenas ser um Monobehaivour
     {
        public static T Instance;

        protected virtual void Awake() //roda no momento que o jogo/c�digo inicia
        {
            if (Instance == null)
                Instance = GetComponent<T>(); //a instancia � igual ao script criado
            else
                Destroy(gameObject); //se existe outra instancia (instance � diferente de nulo), destroi a nova instancia
        }

    }
}