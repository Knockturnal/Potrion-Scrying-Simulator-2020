using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionButton : MonoBehaviour
{
	[SerializeField]
	private PotionType type;

	public void IWasClicked() 
	{
		Diviner.myDiviner.PotionSelected(type);
	}
}
