using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameModeState : MonoBehaviour
{
   public void UpdateStateFromUI()
   {
        FindObjectOfType<GameMode>().UpdateStateFromUI();
   }
}
