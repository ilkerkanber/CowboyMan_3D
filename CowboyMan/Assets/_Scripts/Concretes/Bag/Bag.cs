using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{   
    [SerializeField] GameObject Storage;
    [SerializeField] List<GameObject> Mines;
    Stack<GameObject> bag;
    void Awake()
    {
        bag = new Stack<GameObject>();
    }
    //Çantamıza nesne ekliyor.
    public void AddObject(GameObject obj) 
    {
        ResetBagStack();

        obj.SetActive(true);
        bag.Push(obj);
        Instantiate(bag.Peek(), Storage.transform.position, obj.transform.rotation, Storage.transform);
        InBagObject();
    }
    //Çantamızda ne var ise BagState i değiştiriyor.
   public void InBagObject()
    {
        switch(bag.Peek().tag)
        {
            case "Gem":
                PlayerManager.SetBagState("Gem");
                break;

            case "Obelisk":
                PlayerManager.SetBagState("Obelisk");
                break;
        }
    }
    //Çantamızı temizliyor.
   public void ResetBagStack()
    {
        if (bag.Count == 1)
        {
            bag.Pop();
            Destroy(Storage.transform.GetChild(0).gameObject);
        }
    }

 
    
}
