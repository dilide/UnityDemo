using UnityEngine;
using System.Collections;

public interface ISheep
{
	void Talk(string auPath);
	bool isTalking();
	void SetBubbleContent(string text, int fontsize);
}