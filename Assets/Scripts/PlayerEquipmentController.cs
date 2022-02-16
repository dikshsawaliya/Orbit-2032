using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipmentController : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    [SerializeField] private Transform inventoryUIParent;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory.InitInventory(this);
        inventory.OpenInventoryUI();
    }

    public Transform GetUIParent()
    {
        return inventoryUIParent;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
