using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TextWithCaptionControl
{
    using System.Drawing;
    using System.Web.UI.HtmlControls;

    public enum Align
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public enum Separator
    {
        Dot,
        Comma,
        Colon,
        Semicolon
    }

    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TextWithCaptionControl runat=server></{0}:TextWithCaptionControl>")]
    public class TextWithCaptionControl : WebControl
    {
        private TextBox _text = new TextBox();
        private Label _caption = new Label();
        private Align _alignment = Align.Left;
        private Separator _separator = Separator.Colon;

        private string _color;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
            if (Caption == "")
            {
                Text = "";
            }
        }


        public string Text
        {
            get
            {
                return _text.Text;
            }
 
            set
            {
                _text.Text = value;
            }
        }

        public string Caption
        {
            get
            {
                return _caption.Text;
            }

            set
            {
                _caption.Text = value;
            }
        }

        public Align Alignment
        {
            get
            {
                return _alignment;
            }
            set
            {
                _alignment = value;
            }
        }

        public Separator Separator
        {
            get
            {
                return _separator;
            }
            set
            {
                _separator = value;
            }
        }

        public string TextColor
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        protected override void AddAttributesToRender(HtmlTextWriter output)
        {
            output.AddAttribute(HtmlTextWriterAttribute.Value, Text);
            output.AddAttribute(HtmlTextWriterAttribute.Value, Caption);

            base.AddAttributesToRender(output);
        }

        private void AddColor(HtmlTextWriter writer, Control control)
        {
            writer.Write(String.Format("<font color=\"{0}\">", _color));
            control.RenderControl(writer);
            writer.Write("</font>");
        }
        private void RenderControl(HtmlTextWriter writer, Control control)
        {
            this.AddColor(writer, control);
            switch (_separator)
            {
               case Separator.Colon:
                    {
                        writer.Write(":");
                        break;
                    }     
                case Separator.Comma:
                    {
                        writer.Write(",");
                        break;
                    }
                case Separator.Dot:
                    {
                        writer.Write(".");
                        break;
                    }
                case Separator.Semicolon:
                    {
                        writer.Write(";");
                        break;                      
                    }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (_alignment == Align.Left)
            {
                this.RenderControl(writer,_caption);
                this.AddColor(writer, _text);
            }
            else if (_alignment == Align.Right)
            {
                RenderControl(writer, _text);
                this.AddColor(writer, _caption);
            }
            else if (_alignment == Align.Top)
            {
                writer.Write("<div style=\"display: float;\">");
                writer.Write("<div>");
                RenderControl(writer, _caption);
                writer.Write("</div>");
                writer.Write("<div>");
                this.AddColor(writer, _text);
                writer.Write("</div>");
                writer.Write("</div>");
            }
            else
            {
                writer.Write("<div style=\"display: float;\">");
                writer.Write("<div>");
                RenderControl(writer, _text);
                writer.Write("</div>");
                writer.Write("<div>");
                this.AddColor(writer, _caption);
                writer.Write("</div>");
                writer.Write("</div>");
            }

            this.RenderChildren(writer);
        }

    }
}
