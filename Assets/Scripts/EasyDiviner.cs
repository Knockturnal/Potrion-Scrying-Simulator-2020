using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.IO;

public enum PotionType { Red, White, Blue, Yellow, Pink, Orange, Black };

public class EasyDiviner : MonoBehaviour
{
	[Header("Object References")]
	[SerializeField]
	private TextMeshProUGUI result;

	private string[,] divinationResults;

	private PotionType firstPotion;
	private bool second;



	private void Start()
	{
		#region Potion results

		//Initialize the array. We use a size of 7 because we have 7 different potions (starting at 0)
		divinationResults = new string[7, 7];

		divinationResults[0, 0] = "Red and red";
		divinationResults[0, 1] = "Red and white";
		divinationResults[0, 2] = "Red and blue";
		divinationResults[0, 3] = "Red and yellow";
		divinationResults[0, 4] = "Red and pink";
		divinationResults[0, 5] = "Red and orange";
		divinationResults[0, 6] = "Red and black";

		divinationResults[1, 0] = "White and red";
		divinationResults[1, 1] = "White and white";
		divinationResults[1, 2] = "White and blue";
		divinationResults[1, 3] = "White and yellow";
		divinationResults[1, 4] = "White and pink";
		divinationResults[1, 5] = "White and orange";
		divinationResults[1, 6] = "White and black";

		divinationResults[2, 0] = "Blue and red";
		divinationResults[2, 1] = "Blue and white";
		divinationResults[2, 2] = "Blue and blue";
		divinationResults[2, 3] = "Blue and yellow";
		divinationResults[2, 4] = "Blue and pink";
		divinationResults[2, 5] = "Blue and orange";
		divinationResults[2, 6] = "Blue and black";

		divinationResults[3, 0] = "Yellow and red";
		divinationResults[3, 1] = "Yellow and white";
		divinationResults[3, 2] = "Yellow and blue";
		divinationResults[3, 3] = "Yellow and yellow";
		divinationResults[3, 4] = "Yellow and pink";
		divinationResults[3, 5] = "Yellow and orange";
		divinationResults[3, 6] = "Yellow and black";

		divinationResults[4, 0] = "Pink and red";
		divinationResults[4, 1] = "Pink and white";
		divinationResults[4, 2] = "Pink and blue";
		divinationResults[4, 3] = "Pink and yellow";
		divinationResults[4, 4] = "Pink and pink";
		divinationResults[4, 5] = "Pink and orange";
		divinationResults[4, 6] = "Pink and black";

		divinationResults[5, 0] = "Orange and red";
		divinationResults[5, 1] = "Orange and white";
		divinationResults[5, 2] = "Orange and blue";
		divinationResults[5, 3] = "Orange and yellow";
		divinationResults[5, 4] = "Orange and pink";
		divinationResults[5, 5] = "Orange and orange";
		divinationResults[5, 6] = "Orange and black";

		divinationResults[6, 0] = "Black and red";
		divinationResults[6, 1] = "Black and white";
		divinationResults[6, 2] = "Black and blue";
		divinationResults[6, 3] = "Black and yellow";
		divinationResults[6, 4] = "Black and pink";
		divinationResults[6, 5] = "Black and orange";
		divinationResults[6, 6] = "Black and black";

		//Note that we *could* have done this too
		divinationResults[(int)PotionType.Pink, (int)PotionType.Orange] = "Pink and orange";	//We cast the potion type to an int to set the values in the array
		//I didn't do it like that because I thought it might make the 2-Dimensional array more confusing. We use this method to get the result in the end, however.


		#endregion
	}

	public void PotionSelected(PotionType type)	//This is called from the PotionButton class that sits on the button objects in the scene
	{
		if (second == false)	//We check if this is the first of the two potions we select
		{
			firstPotion = type;	//If it is, we store the value until we select the next potion
			second = true;	//We raise the bool to true so that next time we select a potion we know we have already selected one
		}
		else
		{
			result.text = divinationResults[(int)firstPotion, (int)type]; //We set the result to the corresponding value in our array based on the potions we selected
			second = false;	//Reset the bool that checks if this is the first or second potion
		}
	}

}
