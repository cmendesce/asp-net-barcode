using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebControls
{
    /// <summary>
    /// HttpHandler usado para tratar as requisições para a url no padrão (*.barcode)
    /// </summary>
    public sealed class BarcodeHandler : IHttpHandler
    {
        #region IHttpHandler Members

        /// <summary>
        /// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"/> instance.
        /// </summary>
        /// <returns>true if the <see cref="T:System.Web.IHttpHandler"/> instance is reusable; otherwise, false.</returns>
        public bool IsReusable
        {
            get { return false; }
        }

        /// <summary>
        /// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"/> interface.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpContext"/> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request["Type"];
            string code = context.Request["Code"];
            string height = context.Request["Height"];

            BarcodeType barcodeType;

            if (Enum.TryParse<BarcodeType>(type, out barcodeType) || 
                !string.IsNullOrEmpty(code) || 
                !string.IsNullOrEmpty(height))
            {
                context.Response.ContentType = "image/gif";

                var adapter = new BarcodeAdapter(barcodeType);
                var bytes = adapter.GetBarcodeBytes(code, Convert.ToInt32(height));

                context.Response.BinaryWrite(bytes);
                context.Response.Flush();
            }            
        }

        #endregion
    }
}