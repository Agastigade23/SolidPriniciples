
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolidPriniciples.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OCPController : ControllerBase
{

    [HttpGet]
    public IActionResult GetCalculateValue()
    {
        string output="";

        Invoice FInvoice = new FinalInvoice();
        double FInvoiceAmount = FInvoice.GetInvoiceDiscount(10000);

        Invoice PInvoice = new ProposedInvoice();
        double PInvoiceAmount = PInvoice.GetInvoiceDiscount(10000);

        Invoice RInvoice = new RecurringInvoice();
        double RInvoiceAmount = RInvoice.GetInvoiceDiscount(10000);

        Invoice AInvoice = new AdvancInvoice();
        double AInvoiceAmount = AInvoice.GetInvoiceDiscount(10000);

        output="Final Invoive = " + FInvoiceAmount + " Proposed Invoive = " + PInvoiceAmount + " Recurring Invoive = " + RInvoiceAmount + " Advance Invoice =" + AInvoiceAmount;
        return Ok(output);
    }
}