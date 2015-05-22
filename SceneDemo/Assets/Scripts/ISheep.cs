using UnityEngine;
using System.Collections;

public interface ISheep
{
	void Talk(bool isTalking);
	bool isTalking();
	void SetBubbleVisible(bool visible);
	void SetBubbleContent(string text);
}