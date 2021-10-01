using System;
using System.IO;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;

using PdfSharpCore.Fonts;

using Xamarin.Essentials;

using MigraDocCore.Rendering;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Shapes;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.DocumentObjectModel.MigraDoc.DocumentObjectModel.Shapes;

using PDFDemo.Models;
using PDFDemo.Helpers;
using PDFDemo.Interfaces;

namespace PDFDemo.PDFReports
{
    public class ProductsReport
    {
        private Document document;
        private List<Product> items;

        public ProductsReport(List<Product> items)
        {
            GlobalFontSettings.FontResolver = new GenericFontResolver();
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            this.items = items;
        }

        public async Task CreateReport()
        {
            CreateDocument();
            SetStyles();

            AddHeader();
            AddContent();
            AddFooter();

            await SaveShowPDF();
        }

        private void CreateDocument()
        {
            document = new Document();
            document.Info.Title = "Product Catalog 2021 - Tech Solutions, Inc.";
            document.Info.Subject = "We present you the Product Catalog for this year.";
            document.Info.Author = "Luis Beltran";
            document.Info.Keywords = "Products";
        }

        private void SetStyles()
        {
            // Modifying default style
            Style style = document.Styles["Normal"];
            style.Font.Name = "OpenSans";
            style.Font.Color = Colors.Black;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.PageBreakBefore = false;

            // Header style
            style = document.Styles[StyleNames.Header];
            style.Font.Name = "OpenSans";
            style.Font.Size = 18;
            style.Font.Color = Colors.Black;
            style.Font.Bold = true;
            style.Font.Underline = Underline.Single;
            style.ParagraphFormat.Alignment = ParagraphAlignment.Center;

            // Footer style
            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Right);

            // Modifying predefined style: HeadingN (where N goes from 1 to 9)
            style = document.Styles["Heading1"];
            style.Font.Name = "OpenSans"; // Can be changed (don't forget to add and register the Fonts!)
            style.Font.Size = 14;
            style.Font.Bold = true;
            style.Font.Italic = false;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Color = Colors.CadetBlue;
            style.ParagraphFormat.SpaceAfter = "1cm";

            // Modifying predefined style: Heading2
            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = false;
            style.Font.Italic = true;
            style.Font.Color = Colors.DeepSkyBlue;
            style.ParagraphFormat.Shading.Color = Colors.White;
            style.ParagraphFormat.Borders.Width = 0;
            style.ParagraphFormat.SpaceAfter = 3;
            style.ParagraphFormat.SpaceBefore = 3;

            // Adding new style
            style = document.Styles.AddStyle("MyParagraphStyle", "Normal");
            style.Font.Size = 10;
            style.Font.Color = Colors.Blue;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles.AddStyle("MyTableStyle", "Normal");
            style.Font.Size = 9;
            style.Font.Color = Colors.SlateBlue;
        }

        private void AddHeader()
        {
            var section = document.AddSection();

            var config = section.PageSetup;
            config.Orientation = Orientation.Portrait;
            config.TopMargin = "3cm";
            config.LeftMargin = 15;
            config.BottomMargin = "3cm";
            config.RightMargin = 15;
            config.PageFormat = PageFormat.A4;
            config.OddAndEvenPagesHeaderFooter = true;
            config.StartingNumber = 1;

            var oddHeader = section.Headers.Primary;

            var content = new Paragraph();
            content.AddText("\tProduct Catalog 2021 - Tech Solutions Inc\t");
            oddHeader.Add(content);
            oddHeader.AddTable();

            var headerForEvenPages = section.Headers.EvenPage;
            headerForEvenPages.AddParagraph("Product Catalog 2021");
            headerForEvenPages.AddTable();
        }

        void AddContent()
        {
            AddText1();
            AddImage("comunidad.jpg");
            AddText2();
            AddTable();
        }

        private void AddFooter()
        {
            var content = new Paragraph();
            content.AddText(" Page ");
            content.AddPageField();
            content.AddText(" of ");
            content.AddNumPagesField();

            var section = document.LastSection;
            section.Footers.Primary.Add(content);

            var contentForEvenPages = content.Clone();
            contentForEvenPages.AddTab();
            contentForEvenPages.AddText("\tDate: ");
            //contenidoPar.AddDateField("dddd, dd \"de\" MMMM \"de\" yyyy HH:mm:ss tt");
            contentForEvenPages.AddDateField("dddd, MMMM dd, yyyy HH:mm:ss tt");

            section.Footers.EvenPage.Add(contentForEvenPages);
        }

        private void AddText1()
        {
            var text = "At Tech Solutions Inc, it is our top priority to bring only products of the highest quality to our customers. Products always pass a strict quality control process before they are delivered to you. We put ourselves in the customer's shoes, and only want to offer products that will make our clients happy.";
            var section = document.LastSection;
            var mainParagraph = section.AddParagraph(text, "Heading1");
            mainParagraph.AddLineBreak();

            text = "All components of Tech Solutions Inc sample products have undergone strict laboratory tests for lead, nickel and cadmium content. A world-leading inspection, testing, and certification company has conducted these testsm and as you can see below, our products have passed with perfect note.";
            section.AddParagraph(text, "Heading2");
        }

        private void AddImage(string archivo)
        {
            var paragraph = document.LastSection.AddParagraph();
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            var iimage = Xamarin.Forms.DependencyService.Get<IImage>();
            var path = iimage.Prefix + archivo;

            if (!iimage.Extension)
                path = Path.GetFileNameWithoutExtension(path);

            ImageSource.ImageSourceImpl = iimage.Implementation;
            var logo = ImageSource.FromFile(path);
            var image = paragraph.AddImage(logo);

            image.LineFormat = new LineFormat() { Color = Colors.DarkGreen };
            image.LockAspectRatio = true;
            image.Width = "2.5cm";
        }

        private void AddText2()
        {
            var seccion = document.LastSection;

            var texto = "We recommend customers to purchase products only from reliable sources where products have been tested, and only when the lead, nickel and cadmium content have passed the laboratory tests. Your health is important.";
            var parrafo = seccion.AddParagraph(texto, "MyParagraphStyle");

            texto = "\nWearing products that are not tested, or have failed to meet regulatory standards may bring harm to your health and skin";
            parrafo = seccion.AddParagraph(texto, "MyParagraphStyle");
            parrafo.AddLineBreak();
        }

        private void AddTable()
        {
            var titles = new string[] { "Product", "Name", "Price" };
            var borderColor = new Color(81, 125, 192);

            var section = document.LastSection;

            var table = section.AddTable();
            table.Style = "MyTableStyle";
            table.Borders.Color = borderColor;
            table.Borders.Visible = true;
            table.Borders.Width = 0.75;
            table.Rows.LeftIndent = 5;

            var column = table.AddColumn("5cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("10cm");
            column.Format.Alignment = ParagraphAlignment.Left;

            column = table.AddColumn("4cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            table.Rows.HeightRule = RowHeightRule.Exactly;
            table.Rows.Height = "1cm";

            var headerRow = table.AddRow();
            headerRow.HeadingFormat = true;
            headerRow.Format.Alignment = ParagraphAlignment.Center;
            headerRow.Format.Font.Bold = true;

            for (int i = 0; i < titles.Length; i++)
            {
                headerRow.Cells[i].AddParagraph(titles[i]);
                headerRow.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                headerRow.Cells[i].VerticalAlignment = VerticalAlignment.Center;
                headerRow.Shading.Color = Colors.PaleGoldenrod;
                headerRow.Borders.Width = 1;
            }

            foreach (var item in items)
            {
                var rowItem = table.AddRow();
                rowItem.TopPadding = 1.5;
                rowItem.Borders.Left.Width = 0.25;

                var titleCell = rowItem.Cells[0];
                titleCell.AddParagraph(item.Id.ToString());

                var cellAutor = rowItem.Cells[1];
                cellAutor.AddParagraph(item.Name);

                var cellFecha = rowItem.Cells[2];
                cellFecha.AddParagraph(item.OriginalPrice.ToString("C2"));
            }

            var row = table.AddRow();
            row.Borders.Visible = false;
        }

        private async Task SaveShowPDF()
        {
            var file = Xamarin.Forms.DependencyService.Get<IFile>();
            var fileName = $"{Guid.NewGuid()}.pdf";
            var filePath = await file.GetLocalPath(fileName);

            PdfDocumentRenderer printer = new PdfDocumentRenderer();
            printer.Document = document;
            printer.RenderDocument();
            printer.PdfDocument.Save(filePath);

            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(filePath)
            });
        }
    }
}
