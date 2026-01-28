namespace tp1.banque.documents;
using tp1.banque.documents;
using tp1.banque.clients;

class RibSimplifie : Rib
{
    public override Client titulaire { get; }

    public RibSimplifie(Client titulaire)
    {
        this.titulaire = titulaire;
    }
}