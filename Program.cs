using tp1.banque.clients;
using tp1.banque.documents;
using tp2;
using tp3.logger;

class Program
{
    static void Main(string[] args)
    {
        Program p = new Program();
        // p.SingletonExample();
        // p.FactoryExample();
        // p.BuilderExample();
        // p.Tp1Banque();
         p.Tp3Logger();
    }

    private void SingletonExample()
    {
        liassesVierge instance1 = liassesVierge.getInstance("Example");
        liassesVierge instance2 = liassesVierge.getInstance("Example");

        if (instance1.nom == instance2.nom)
        {
            System.Console.WriteLine("Both instances are the same.");
        }
        else
        {
            System.Console.WriteLine("Instances are different.");
        }
    }

    private void FactoryExample()
    {
        Client clientComptant = new ClientComptant();
        Commande commandeComptant = clientComptant.nouvelleCommande(500);

        Client clientCredit = new ClientCredit();
        Commande commandeCredit = clientCredit.nouvelleCommande(500);

        commandeComptant.valider();
        commandeComptant.payer();
    }

    private void BuilderExample()
    {
        SqlQueryBuilder queryBuilder = new SqlQueryBuilder();
        string query = queryBuilder
            .Select("Name", "Age")
            .From("Users")
            .Join("INNER JOIN Orders ON Users.Id = Orders.UserId")
            .Where("Age > 18", "Age < 30")
            .Build();

        System.Console.WriteLine(query);
    }

    private void Tp1Banque()
    {
        ClientParticulier clientParticulier = new ClientParticulier("Doe", "John");
        ClientProfessionnel clientEntreprise = new ClientProfessionnel("Acme Corp", "Alice");
        DocumentBanque documentParticulier = clientParticulier.genererDocumentAttestationCompte();
        DocumentBanque documentParticulierRib = clientParticulier.genererDocumentRib();
        DocumentBanque documentEntreprise = clientEntreprise.genererDocumentAttestationCompte();
        DocumentBanque documentEntrepriseRib = clientEntreprise.genererDocumentRib();
        System.Console.WriteLine($"Document for {clientParticulier.nom} {clientParticulier.prenom} generated: {documentParticulier.GetType().Name}");
        System.Console.WriteLine($"RIB for {clientParticulier.nom} {clientParticulier.prenom} generated: {documentParticulierRib.GetType().Name}");
        System.Console.WriteLine($"Document for {clientEntreprise.nom} {clientEntreprise.prenom} generated: {documentEntreprise.GetType().Name}");
        System.Console.WriteLine($"RIB for {clientEntreprise.nom} {clientEntreprise.prenom} generated: {documentEntrepriseRib.GetType().Name}");
    }

    private void Tp3Logger()
    {
        var notifCommande = new LoggerCommande();
        notifCommande.EnvoyerParEmail("Votre commande est confirmée");
        notifCommande.EnvoyerParSMS("Votre commande est expédiée");
        
        var notifLivraison = new LoggerLivraison();
        notifLivraison.EnvoyerParSMS("Votre colis est en route");
        notifLivraison.EnvoyerParPush("Votre colis a été livré");
        
        var notifSupport = new LoggerSupport();
        notifSupport.EnvoyerParPush("Un agent va vous contacter");
        notifSupport.EnvoyerParEmail("Votre ticket de support a été créé");
    }
}
