using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionButton : MonoBehaviour
{
	[SerializeField]
	private PotionType type;

	[SerializeField]
	private EasyDiviner diviner;
	public void IWasClicked() 
	{
		diviner.PotionSelected(type);
	}
}
