using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using static sum_practise_2023.TextFieldConfig;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Drawing.Text;
/*
using System.Threading.Tasks;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
*/
namespace sum_practise_2023
{
    internal struct DocumentConfig
    {
        public List<Config> elems { get; set; }
        public float height { get; set; }
        public float width { get; set; }
    }
    internal class Document
    {
        // Control wrapper
        // wraps any control for storing such as text boxes or images, so that they can easily all be edited and evoke different events in editor
        public class Component : IDisposable
        {
            public delegate void ControlAction(Control comp);
            public ControlAction EnableEditing; 
            public Control comp;
            protected Document _parent;
            protected bool dragged;
            private int IMLX,IMLY,ICLX,ICLY;

            // takes a control(eg textbox or button or anything else)
            public Component(Control c,Document parent)
            {
                _parent = parent;
                dragged = false;
                // here we can evoke different ivents for the control.
                comp = c;
                _parent._render.Controls.Add(comp);

                EnableEditing += (Control comp) => { _parent.mode = Mode.Edit; };

                //eg here we invoking click event to enable editing
                comp.MouseClick += this.MouseClickEventHandle;

                comp.DoubleClick += this.DoubleClickEventHandle;
                comp.MouseClick += this.MouseDownEventHandle;
                comp.MouseDown += this.MouseDownEventHandle;
                comp.MouseUp += this.MouseUpEventHandle;
                comp.MouseMove += this.MouseMoveEventHandle;
                EnableEditing += TextFieldEditing;
            }


            ~Component()
            {
                Dispose();
            }
            private void DoubleClickEventHandle(object obj, EventArgs e)
            {
            }
            private void MouseClickEventHandle(object obj, MouseEventArgs e)
            {
                // left click in any mode mode will enable controls editing
                if (e.Button == MouseButtons.Left)
                {
                    EnableEditing(comp);
                }
                
            }
            private void MouseDownEventHandle(object obj, MouseEventArgs e)
            {
                if (_parent.mode == Mode.Edit)
                {
                    if (e.Button == MouseButtons.Right)
                    {

                        // enable drag and drop 
                        if (!dragged)
                        {
                            dragged = true;
                            ICLX = comp.Location.X;
                            ICLY = comp.Location.Y;
                            IMLX = Cursor.Position.X;
                            IMLY = Cursor.Position.Y;
                        }

                    }
                }
            }
            private void MouseUpEventHandle(object obj, MouseEventArgs e)
            {
                if(e.Button == MouseButtons.Right)
                {
                    // disable drag and drop
                    dragged = false;
                }
            }
            private void MouseMoveEventHandle(object obj, MouseEventArgs e)
            {
                // drag and drop
                if (dragged)
                {
                    var newLoc = new Point(
                        ICLX + Cursor.Position.X - IMLX,
                        ICLY + Cursor.Position.Y - IMLY
                        );
                    comp.Location = newLoc;
                }
            }

            public void Dispose()
            {
                _parent._render.Controls.Remove(comp);
                ((IDisposable)comp).Dispose();
            }

            // this needs to be overwritten
            //abstract public object Parameters{get;set;}
        }
        private System.Windows.Forms.Panel _render;
        private List<Component> _components;
        public List<Component> Components
        {
            get { return _components; }
            set { _components = value; }
        }
        public Document(System.Windows.Forms.Panel render_surface)
        {
            
            _render = render_surface;
            _render.AutoSize = false;
            _render.AutoScroll = false;
            _render.HorizontalScroll.Enabled = false;
            _render.VerticalScroll.Enabled = false;
            _components = new List<Component>();

            _render.MouseClick += this.MouseClickEventHandle;
            mode = Mode.Edit;
            
            _render.Invalidate();
            //t.EnableEditing;


        }

        private void MouseClickEventHandle(object obj,MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && mode == Mode.Add)
            {
                switch (addMode)
                {
                    default:
                        break;
                    case AddMode.TextField:
                        
                        _components.Add(NewTextField(e.Location));
                        break;
                }
            }
        }
        
        private Component NewTextField(Point position)
        {
            Label lb = new Label();
            lb.Text = "Text";
            lb.BackColor = Color.Transparent;
            lb.Location = position;
            lb.AutoSize = true;
            Component cp = new Component(lb, this);
            return cp;
        }

        private static void TextFieldEditing(Control ctl)
        {
            // TODO: enable typing for Label
            // that can be achieved by spawning a textbox somewhere, that will update text of label, and despawn it when it loses focus or escaped pressed.
            Form1.StartEditing(ctl as Label);
        }


        // Save and load state from json

        public PointF getDPI()
        {
            Graphics g = _render.CreateGraphics();
            PointF dpi = new PointF();
            try { dpi.X = g.DpiX; dpi.Y = g.DpiY; }
            catch { throw new Exception("Fatal error: couldn't get dpi"); }
            finally { g.Dispose(); }
            return dpi;
        }

        public DocumentConfig getConfig()
        {
            DocumentConfig ret = new DocumentConfig();
            ret.elems = new List<Config>();
            // create a helper container that will be serialized
            foreach (var ctl in Components)
            {
                try
                {
                    Config c;
                    if (ctl.comp is Label)
                    {
                        c = new TextFieldConfig();
                        c.Deconstruct(ctl.comp);
                    }// to ensure that we can easily add configs of other types, 
                    else
                    {
                        throw new Exception();
                    }
                    ret.elems.Add(c);
                }
                catch
                {
                    throw new Exception("Сomponent deconstruction error");
                }
            }
            ret.width = Size.X; ret.height = Size.Y;
            return ret;
        }

        public void SaveComponentsToJson(string SavePath)
        {
            var cfg = getConfig();
            try
            {
                File.WriteAllText(SavePath, JsonSL.Serialize(cfg));
            } catch
            {
                throw new Exception("Writing to the file error");
            }
            
        }
        public static string GetFileName(string directoryPath, string name)
        {
           
            foreach (string filePath in Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories))
            {
                if ( filePath.Split('.')[1] == "ttf" || filePath.Split('.')[1] == "TTF")
                {
                    using (var fontCollection = new System.Drawing.Text.PrivateFontCollection())
                    {
                        fontCollection.AddFontFile(filePath);
                        if (fontCollection.Families[0].Name == name)
                        {
                            return filePath;
                        }
                    }
                }
            }
            return null;
            
        }

        public void SaveComponentsToPDF(string SavePath)
        {
            
            var cfg = getConfig();
            FileStream fs = new FileStream(SavePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
            iTextSharp.text.Document saveFile = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(cfg.width*72, cfg.height*72), 0, 0, 0, 0);

            var writer = PdfWriter.GetInstance(saveFile, fs);
            saveFile.Open();
            writer.Open();
            var cb = writer.DirectContentUnder;
            foreach (var comp in cfg.elems)
            {
                if (comp is TextFieldConfig)
                {
                    var tfc = (TextFieldConfig)comp;
                    var ft = new System.Drawing.Font(new FontFamily(tfc.FamilyName), tfc.Size);
                    tfc.FontFilePath = GetFileName("C:/Windows/Fonts", ft.FontFamily.Name);
                    BaseFont baseFont = BaseFont.CreateFont(tfc.FontFilePath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    cb.BeginText();
                    cb.SetFontAndSize(baseFont, tfc.Size);
                    cb.ShowTextAligned(PdfContentByte.ALIGN_LEFT, tfc.Text, tfc.X*0.72f, cfg.height * 72 - tfc.Size - tfc.Y * 0.72f, 0);
                    cb.EndText();
                }
            }
            
            saveFile.Close();
                
        }

        public void DeleteComponents()
        {
            
            foreach (var comp in Components)
            {
                comp.Dispose();
            }
            Components.Clear();
        }
        public void LoadComponentsFromJson(string LoadPath)
        {
            // TODO: same here, rethrow an exception with more vivid discription that the file is'nt in the right format
            // fix an error of loading - throws an exception for some reason idk why yet
            // TODO: check if file exists and handle exceptions
            string jsonString;
            DocumentConfig cfg;

            try
            {
                jsonString = File.ReadAllText(LoadPath);
            } catch
            {
                throw new Exception("File reading error");
            }
            try
            {
                cfg = JsonSL.Deserialize<DocumentConfig>(jsonString);
            } catch
            {
                throw new Exception("File deserialize error");
            }
            DeleteComponents();
            Size = new PointF(cfg.width, cfg.height);
            foreach (var config in cfg.elems)
            {
                if (config is TextFieldConfig)
                {
                    try
                    {
                        Components.Add(new Component(config.Construct(), this));
                    } catch
                    {
                        throw new Exception("New component add error");
                    }
                    
                }
            }
            // also we should catch that exception in the form and give user a notice that the file is corrupted or is not in the right format
        }


        // clip size of drawing area - the size of document
        // TODO: research if there is any other way of setting clip to a panel
        // because currently its an integer, but many sizes of documents might lend non integer values.
        private PointF _size= new PointF();
        public PointF Size{
            get { return _size; }
            set { 
                _size = value;
                var dpi = getDPI();
                _render.MaximumSize = new Size((int)(_size.X * dpi.X), (int)(_size.Y * dpi.Y));
                _render.Size = _render.MaximumSize;
            }
        }
        
        // there are 3 modes
        // Add - adds controls on click
        // Edit - enables editing and interactions with elements.
        // View - allows to scrol form with mouse
        public enum Mode
        {
            Edit,
            Add,
            View
        }
        private Mode _mode;
        public enum AddMode
        {
            TextField
        }
        public AddMode addMode;
        public Mode mode
        {
            get
            {
                return _mode;
            } 
            set
            {
                _mode = value;
                switch (_mode)
                {
                    case Mode.Edit:
                        _render.Cursor = Cursors.Default;
                        break;
                    case Mode.Add:
                        _render.Cursor = Cursors.Cross;
                        break;
                    case Mode.View:
                        _render.Cursor = Cursors.Hand;
                        break;
                    default:
                        _render.Cursor = Cursors.Default;
                        break;
                }
            }
        }

        

    }
}
