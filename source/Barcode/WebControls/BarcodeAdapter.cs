using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;

namespace WebControls
{
    /// <summary>
    /// Faz a interface entre as classes de Barcode da biblioteca do iTextSharp
    /// </summary>
    internal sealed class BarcodeAdapter
    {
        /// <summary>
        /// Barcode básico
        /// </summary>
        private iTextSharp.text.pdf.Barcode _barcode;

        /// <summary>
        /// Tipo do barcode
        /// </summary>
        private BarcodeType _type;

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BarcodeAdapter"/>.
        /// </summary>
        /// <param name="type">Tipo do barcode.</param>
        internal BarcodeAdapter(BarcodeType type)
        {
            _type = type;
            ResolveBarcodeType();
        }

        /// <summary>
        /// Retorna os bytes da imagem gerada pelo iTextSharp
        /// </summary>
        /// <param name="code">Código do barcode</param>
        /// <param name="height">Altura do barcode</param>
        /// <returns>Array de bytes com os dados da imagem</returns>
        internal byte[] GetBarcodeBytes(string code, int height)
        {
            try
            {
                _barcode.Code = code;
                _barcode.BarHeight = height;

                var image = _barcode.CreateDrawingImage(Color.Black, Color.White);

                var ms = new MemoryStream();
                image.Save(ms, ImageFormat.Gif);

                return ms.ToArray();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(string.Concat("Ocorreu um problema no momento de gerar o Código de Barra.", ex.Message));
            }
        }

        /// <summary>
        /// Decide qual tipo de barcode deve ser utilizado atraves do BarcodeType
        /// </summary>
        private void ResolveBarcodeType()
        {
            switch (_type)
            {
                case BarcodeType.Code128:
                    {
                        _barcode = new Barcode128();
                    }
                    break;
                case BarcodeType.Code39:
                    {
                        _barcode = new Barcode39();
                    }
                    break;
                case BarcodeType.EAN:
                    {
                        _barcode = new BarcodeEAN();
                    }
                    break;
            }
        }
    }
}