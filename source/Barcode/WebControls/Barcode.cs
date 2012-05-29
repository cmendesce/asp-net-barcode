using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace WebControls
{
    [ToolboxData("<{0}:Barcode runat=server></{0}:Barcode>")]
    public sealed class Barcode : WebControl
    {
        private const int _defaultHeight = 24;

        [Category("Configuration")]
        [Localizable(true)]
        public BarcodeType Type
        {
            get
            {
                return (BarcodeType)ViewState["Type"];
            }
            set
            {
                ViewState["Type"] = value;
            }
        }

        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Code
        {
            get
            {
                return (String)ViewState["Code"];
            }
            set
            {
                ViewState["Code"] = value;

            }
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="Barcode"/> class.
        /// </summary>
        public Barcode()
        {
            Height = _defaultHeight;
        }

        /// <summary>
        /// Renders the contents.
        /// </summary>
        /// <param name="output">The output.</param>
        protected override void RenderContents(HtmlTextWriter output)
        {
            System.Web.UI.WebControls.Image image = new System.Web.UI.WebControls.Image();
            
            int height = Convert.ToInt32(this.Height.Value);

            image.ImageUrl = string.Format("image.barcode?Type={0}&Code={1}&Height={2}", Type, Code, height);
            
            image.RenderControl(output);
        }
    }
}