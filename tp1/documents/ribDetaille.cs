namespace tp1.banque.documents;
using tp1.banque.documents;
using tp1.banque.clients;

class RibDetaille : Rib
{
    public override Client titulaire { get; }

    public RibDetaille(Client titulaire)
    {
        this.titulaire = titulaire;
    }
}