namespace SolidPriniciples;

public class AdvancInvoice : Invoice
{
    public override double GetInvoiceDiscount(double amount)
    {
        return base.GetInvoiceDiscount(amount) - 60;
    }
}