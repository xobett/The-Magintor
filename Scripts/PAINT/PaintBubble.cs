using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBubble : MonoBehaviour
{

    public bool purplePaint;
    public bool greenPaint;
    public bool bluePaint;
    public bool redPaint;

    void Update()
    {
        BubblePaintCheck();
    }

    private void BubblePaintCheck()
    {
        if (purplePaint)
        {
            this.tag = "Purple Bubble";
        }
        else if (greenPaint)
        {
            this.tag = "Green Bubble";
        }
        else if (bluePaint)
        {
            this.tag = "Blue Bubble";
        }
        else if (redPaint)
        {
            this.tag = "Red Bubble";
        }
        else
        {
            this.tag = "Plain Bubble";
        }
    }
}
