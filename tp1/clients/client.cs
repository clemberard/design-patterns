namespace tp1.banque.clients;

using System.Reflection.Metadata;
using tp1.banque.documents;

abstract class Client
{
    public abstract string nom { get; }
    public abstract string prenom { get; }

    public Client()
    {
    }

    public DocumentBanque genererDocumentAttestationCompte()
    {
        return creerDocumentAttestationCompte();
    }

    public DocumentBanque genererDocumentRib()
    {
        return creerDocumentRib();
    }

    public abstract DocumentBanque creerDocumentAttestationCompte();
    public abstract DocumentBanque creerDocumentRib();
}