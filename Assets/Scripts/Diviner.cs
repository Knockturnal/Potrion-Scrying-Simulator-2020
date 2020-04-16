using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System.IO;

public enum PotionType {Red, White, Blue, Green, Pink, Orange, Black};

[ExecuteAlways]
public class Diviner : MonoBehaviour
{
	public static Diviner myDiviner;
	[SerializeField]
	private List<DivinationResult> divinationResults;
	[SerializeField]
	private TextMeshProUGUI result;

	private PotionType firstPotion;
	private bool second;
	private string CSVContent;

	private void Awake()
	{
		myDiviner = this;
	}

	private void Update()
	{
		if (!Application.isPlaying)
		{
			divinationResults = new List<DivinationResult>();
			ParseResultsCSV();
		}
	}

	public void PotionSelected(PotionType type) 
	{
		if(second == false) 
		{
			firstPotion = type;
			second = true;
		}
		else
		{
			List<DivinationResult> firstMatch = divinationResults.FindAll(toCheck => toCheck.first == firstPotion);
			DivinationResult secondMatch = firstMatch.Find(toCheck => toCheck.second == type);
			result.text = secondMatch.result;
			second = false;
		}
	}

	private void ParseResultsCSV()
	{
		CSVContent = File.ReadAllText(Application.streamingAssetsPath + "/results.csv");
		string[] lines = CSVContent.Split('\n');
		for (int i = 1; i < lines.Length; i++)
		{
			string[] columns = SplitCsvLine(lines[i]);

			for (int j = 1; j < columns.Length - 1; j++)
			{
				DivinationResult currentResult = new DivinationResult();
				currentResult.first = (PotionType)(j - 1);
				currentResult.second = (PotionType)(i - 1);
				currentResult.result = columns[j];
				divinationResults.Add(currentResult);
			}
		}
	}

	/// <summary>
	/// Function for parsing a single line of CSV data
	/// </summary>
	public static string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)",
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
				select m.Groups[1].Value).ToArray();
	}
}

[System.Serializable]
public struct DivinationResult 
{
	public PotionType first;
	public PotionType second;
	[Multiline]
	public string result;
}