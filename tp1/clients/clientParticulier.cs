namespace tp1.banque.clients;
using tp1.banque.documents;

class ClientParticulier : Client
{
    public override string nom { get; }
    public override string prenom { get; }

    public ClientParticulier(string nom, string prenom)
    {
        this.nom = nom;
        this.prenom = prenom;
    }

    public override DocumentBanque creerDocumentAttestationCompte()
    {
        return new AttestationCompteStandarisee(this);
    }
        
    public override DocumentBanque creerDocumentRib()
    {
        return new RibSimplifie(this);
    }
}