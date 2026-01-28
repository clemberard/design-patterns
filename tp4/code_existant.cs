// Interface existante utilisée par le système
public interface IPaymentService
{
    bool ProcessPayment(decimal amount, string currency);
    bool RefundPayment(string transactionId, decimal amount);
    string GetTransactionStatus(string transactionId);
}

// Service de paiement actuel (fonctionne correctement)
public class InternalPaymentService : IPaymentService
{
    public bool ProcessPayment(decimal amount, string currency)
    {
        Console.WriteLine($"Paiement interne: {amount} {currency}");
        return true;
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        Console.WriteLine($"Remboursement interne: {transactionId} - {amount}");
        return true;
    }

    public string GetTransactionStatus(string transactionId)
    {
        return "Completed";
    }
}

public class PaymentProAdapter : IPaymentService
{
    private readonly PaymentPro _paymentPro;

    public PaymentProAdapter(PaymentPro paymentPro)
    {
        _paymentPro = paymentPro;
    }

    public bool ProcessPayment(decimal amount, string currency)
    {
        int currencyCode = CurrencyToCode(currency);
        string reference = _paymentPro.ExecuterTransaction((double)amount, currencyCode);
        return !string.IsNullOrEmpty(reference);
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        return _paymentPro.AnnulerTransaction(transactionId);
    }

    public string GetTransactionStatus(string transactionId)
    {
        int status = _paymentPro.ObtenirEtat(transactionId);
        return status switch
        {
            0 => "En cours",
            1 => "Validé",
            2 => "Échoué",
            _ => "Inconnu" // Si on enlève cette ligne, on obtient un warning de compilation
        };
    }

    private int CurrencyToCode(string currency)
    {
        return currency.ToUpper() switch
        {
            "EUR" => 1,
            "USD" => 2,
            "GBP" => 3,
            _ => 0 // Si on enlève cette ligne, on obtient un warning de compilation
        };
    }
}

// Nouveau service externe à intégrer (NE PAS MODIFIER)
public class PaymentPro
{
    public string ExecuterTransaction(double montant, int codeDevise)
    {
        Console.WriteLine($"PaymentPro: Transaction de {montant} avec devise code {codeDevise}");
        return Guid.NewGuid().ToString();
    }

    public bool AnnulerTransaction(string reference)
    {
        Console.WriteLine($"PaymentPro: Annulation de {reference}");
        return true;
    }

    public int ObtenirEtat(string reference)
    {
        // 0=En cours, 1=Validé, 2=Échoué
        return 1;
    }
}

namespace Tp4
{
    public class PaymentDemo
    {
        public static void Run()
        {
            IPaymentService service = new InternalPaymentService();
            ProcessOrder(service, 99.99m);

            // TODO: Comment utiliser PaymentPro ici sans modifier ProcessOrder ?
            PaymentPro paymentPro = new PaymentPro();
            ProcessOrder(new PaymentProAdapter(paymentPro), 149.99m);
        }

        static void ProcessOrder(IPaymentService paymentService, decimal total)
        {
            bool success = paymentService.ProcessPayment(total, "EUR");
            if (success)
            {
                Console.WriteLine("Commande traitée avec succès");
            }
        }
    }
}
