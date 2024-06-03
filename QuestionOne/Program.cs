using IronOcr;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

Console.WriteLine("Start Project");


Console.WriteLine("Start Project");

var ocr = new IronTesseract();

using (var ocrInput = new OcrInput())
{
    // Resmin yolu 
    ocrInput.LoadImage(@"..\..\..\assets\images\example2.png");


    var ocrResult = ocr.Read(ocrInput);
    var wordsInLines = ocrResult.Words.GroupBy(w => w.Line)
                              .Select(group => new
                              {
                                  Line = group.Key,
                                  Words = group.Select(w => w.Text).ToList()
                              });
    var jsonResult = JsonConvert.SerializeObject(wordsInLines, Formatting.Indented);

    //var jsonResult = JsonConvert.SerializeObject(new
    //{
    //    Text = ocrResult.Text,
    //    Confidence = ocrResult.Confidence,
    //    Words = ocrResult.Words.Select(word => new
    //    {
    //        Text = word.Text,
    //        X = word.X,
    //        Y = word.Y,
    //        Width = word.Width,
    //        Height = word.Height
    //    })
    //}, Formatting.Indented);

    Console.WriteLine("OCR Sonuçları:");

    Console.WriteLine(jsonResult);

}



