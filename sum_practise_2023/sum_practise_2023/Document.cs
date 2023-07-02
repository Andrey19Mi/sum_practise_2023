using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace sum_practise_2023
{
    internal class ConfigException : Exception { }
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
            // enable typing for Label
        }


        // TODO: save and load state from json



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
