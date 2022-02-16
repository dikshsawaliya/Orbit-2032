using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Item")]

public class InventoryItem : ScriptableObject
{
   [SerializeField] private GameObject itemPrefab;
   [SerializeField] private Sprite itemSprite;
   [SerializeField] private string itemName;
   [SerializeField] private Vector3 itemLocalPosition;
   [SerializeField] private Vector3 itemLocalRotation;

   public Sprite GetSprite()
   {
      return itemSprite;
   }

   public string GetName()
   {
      return itemName;
   }

   public GameObject GetPrefab()
   {
      return itemPrefab;
   }

   public Vector3 GetLocalPosition()
   {
      return itemLocalPosition;
   }

   public Quaternion GetlocalRotation()
   {
      return Quaternion.Euler(itemLocalRotation);
   }
   

}
