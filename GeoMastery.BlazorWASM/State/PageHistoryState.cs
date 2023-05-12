namespace GeoMastery.BlazorWASM.State;

public class PageHistoryState
{
    private Stack<string> previousPages;

    public PageHistoryState()
    {
        previousPages = new Stack<string>();
    }
    public void AddPageToHistory(string pageName)
    {
        previousPages.Push(pageName);
    }
    public void RemovePageFromHistory()
    {
        previousPages.Pop();
    }

    public string GetGoBackPage()
    {
        if (previousPages.Count > 1)
        {
            // You add a page on initialization, so you need to return the 2nd from the last
            return previousPages.Peek();
        }

        // Can't go back because you didn't navigate enough
        return previousPages.FirstOrDefault();
    }

    public bool CanGoBack()
    {
        return previousPages.Count > 1;
    }
}