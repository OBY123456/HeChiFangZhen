using UnityEngine;

public static class ExtensionMethods
{
    public static void Open(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public static void Hide(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}
