using Spire.Pdf;
using Spire.Pdf.Security;
using Spire.Pdf.Widget;
using System.Security.Cryptography.X509Certificates;

string filename = @"C:\Users\sokfi\OneDrive\Dzieło sztuki\SQL Zajecia\Lab 4\LabPDFVal\LabPDFVal\LabPDFVal\podpis1.pdf";
//string filename = @"C:\Users\sokfi\OneDrive\Dzieło sztuki\SQL Zajecia\Lab 4\LabPDFVal\LabPDFVal\LabPDFVal\podpis2.pdf";
//string filename = @"C:\Users\sokfi\OneDrive\Dzieło sztuki\SQL Zajecia\Lab 4\LabPDFVal\LabPDFVal\LabPDFVal\brakpodp.pdf";

List<PdfSignature> signatures = new List<PdfSignature>();
PdfDocument doc = new PdfDocument(filename);
PdfFormWidget form = (PdfFormWidget)doc.Form;


    if (form == null)
    {
        Console.WriteLine("PLIK NIE POSIADA PODPISU!");
    }
    else
    {

    for (int i = 0; i < form.FieldsWidget.Count; ++i)

    {
        PdfSignatureFieldWidget? field = form.FieldsWidget[i] as PdfSignatureFieldWidget;

        if (field != null && field.Signature != null)

        {
            PdfSignature signature = field.Signature;
            signatures.Add(signature);
            PdfSignature signatureOne = signatures[0];
            X509Certificate2 certificate = signatureOne.Certificate as X509Certificate2;

            string subject = certificate.Subject;
            DateTime validStart = certificate.NotBefore;
            DateTime validEnd = certificate.NotAfter;

            Console.WriteLine("PLIK POSIADA PODPIS!\n============================================");
            Console.WriteLine("Info - " + subject);
            Console.WriteLine("Data podpisu - " + validStart);
            Console.WriteLine("Data wygasniecia podpisu - " + validEnd + "\n============================================");
        }
    }
}

// dotnet add package FreeSpire.PDF --version 8.2.0