public class liassesVierge
{
    public string nom { get; set; }

    public liassesVierge(string nomDoc)
    {
        nom = nomDoc;
    }

    public static liassesVierge getInstance(string nomDoc)
    {
        // Singleton logic here (not implemented in this snippet)
        return new liassesVierge(nomDoc);
    }
}
