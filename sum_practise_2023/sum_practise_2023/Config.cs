using System;
using System.Drawing;
using System.Text.Json.Serialization;
using System.Windows.Forms;
/*
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
*/
namespace sum_practise_2023
{
    internal class ConfigException : Exception {}

    // this one was just for testing, don't ever uncomment this one.
    // if you made a new type of config add it below
    //[JsonDerivedType(typeof(Config), typeDiscriminator: "base")]
    // you have to add for each new config a new derived type and descriminator here

    // !!!! Do not derive classes from each other even if they are similar, all classes should be derrived only from Config
    // and there must be methods Construct aand Deconstruct redefined
    // !!! Also note that those classes must not be generic, that will break serialization too, be careful with that
    // actually you may try but youll have to provide a JsonDerived type specification as shown above to every type that you use it with
    // eg if you use MyGenericConfig type with parameters string and int you should specify:
    // [JsonDerivedType(typeof(MyGenericConfig<int>), typeDiscriminator: "GenericConfigInt")]
    // [JsonDerivedType(typeof(MyGenericConfig<string>), typeDiscriminator: "GenericConfigString")]
    internal interface Config : JsonSL.ITypeDiscriminator
    {
        //Deconstruct takes a non serializable control, checks its type and stores all of the data to be serialized in fields of its class
        void Deconstruct(System.Windows.Forms.Control ctl);
        // Constructs returns a control of a known type with all serializable data set to a control
        System.Windows.Forms.Control Construct();
    }
    internal class TextFieldConfig : Config
    {
        public string TypeDiscriminator => nameof(TextFieldConfig);
        public string FamilyName { get; set; }
        public float Size { get; set; }
        public FontStyle Style { get; set; }
        public string Text { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public void Deconstruct(System.Windows.Forms.Control ctl)
        {
            if (ctl is System.Windows.Forms.Label && ctl != null) {
                this.Text = ctl.Text;
                this.X = ctl.Location.X;
                this.Y = ctl.Location.Y;
                this.FamilyName = ctl.Font.FontFamily.Name;
                this.Size  = ctl.Font.Size;
                this.Style = ctl.Font.Style;
            }
            else
            {
                throw new ConfigException();
            }
        }
        public Control Construct()
        {
            if ( this.Text == null || this.FamilyName == null ) {
                throw new ConfigException();
            }
            Control lb = new Label();
            lb.Text = Text;
            lb.Location = new Point(X,Y);
            // this one might throw an
            lb.Font = new Font(FamilyName, Size, Style);
            return lb;
        }
    }
    
}
