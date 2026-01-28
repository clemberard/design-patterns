namespace tp1.banque.clients;
using tp1.banque.documents;

class ClientProfessionnel: Client
{
    public override string nom { get; }
    public override string prenom { get; }

    public ClientProfessionnel(string nom, string prenom)
    {
        this.nom = nom;
        this.prenom = prenom;
    }

    public override DocumentBanque creerDocumentAttestationCompte()
    {
        return new AttestationCompteSpecifique(this);
    }

    public override DocumentBanque creerDocumentRib()
    {
        return new RibDetaille(this);
    }
}