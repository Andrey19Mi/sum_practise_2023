using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using iTextSharp;
using static sum_practise_2023.TextFieldConfig;
using iTextSharp.text.pdf;
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

    internal class Document
    {
        // Control wrapper
        // wraps any control for storing such as text boxes or images, so that they can easily all be edited and evoke different events in editor
        public class Component
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
            }


            ~Component()
            {
                //_parent._render.Controls.Remove(comp);
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
                if (e.Button == MouseButtons.Right)
                {
                    if (_parent.mode == Mode.Edit)
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
            _render.AutoScroll = true;
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
            Component cp = new Component(lb, this);
            cp.EnableEditing += TextFieldEditing;
            return cp;
        }
        private void TextFieldEditing(Control ctl)
        {
            // TODO: enable typing for Label
            // that can be achieved by spawning a textbox somewhere, that will update text of label, and despawn it when it loses focus or escaped pressed.
        }

        public void ConvertPanelToPDF(Panel panel, string filePath)
        {
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();
            using (Bitmap bitmap = new Bitmap(panel.Width, panel.Height))
            {
                panel.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
                using (MemoryStream stream = new MemoryStream())
                {
                    bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                    byte[] imageBytes = stream.ToArray();
                    iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(imageBytes);
                    doc.Add(pdfImage);
                }
            }
            doc.Close();
        }

        // Save and load state from json

        public void SaveComponentsToJson(string SavePath)
        {
            // need to save size w/h and etc
            // create a helper container that will be serialized
            List<Config> cfg = new List<Config>();
            foreach(var ctl in Components)
            {
                TextFieldConfig c = new TextFieldConfig();
                try
                {
                    if (ctl.comp is Label)
                    {
                        c.Deconstruct(ctl.comp);
                    }
                }catch
                {
                    throw new Exception("Сomponent deconstruction error");
                }
                cfg.Add(c);
            }
            try
            {
                File.WriteAllText(SavePath, JsonSL.Serialize(cfg));
            } catch
            {
                throw new Exception("Writing to the file error");
            }
            
        }
        public void LoadComponentsFromJson(string LoadPath)
        {
            // TODO: same here, rethrow an exception with more vivid discription that the file is'nt in the right format
            // fix an error of loading - throws an exception for some reason idk why yet
            // TODO: check if file exists and handle exceptions
            string jsonString;
            List<Config> configs;

            try
            {
                jsonString = File.ReadAllText(LoadPath);
            } catch
            {
                throw new Exception("File reading error");
            }

            try
            {
                configs = JsonSL.Deserialize<List<Config>>(jsonString);
            } catch
            {
                throw new Exception("File deserialize error");
            }
            
            foreach (var config in configs)
            {
                if (config is TextFieldConfig)
                {
                    try
                    {
                        Components.Add(new Component(new ComponentWrapper(config as TextFieldConfig).Comp, this));
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
        public System.Drawing.Size Size{
            get{
                return _render.Size;
            }
            private set
            {
                _render.Size = value;
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
