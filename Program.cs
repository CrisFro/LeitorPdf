using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;

namespace LeitorPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ExtraiTextoPdf("teste.pdf"));
            Console.ReadKey();
        }

        static string ExtraiTextoPdf(string nomeDoArquivo)
        {
            string result = null; //string de retorno
            PdfReader pdfReader = new PdfReader(nomeDoArquivo);
            PdfDocument pdfDoc = new PdfDocument(pdfReader);
            for(int page = 1; page <= pdfDoc.GetNumberOfPages(); page++) //lendo o pdf e utilizando o for, pois ele pode conter várias páginas
            {
                ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy(); //tratando a iteração
                string conteudo = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);
                result += conteudo;
            } 
            pdfDoc.Close();
            pdfReader.Close();
            return result;
        }
    }
}