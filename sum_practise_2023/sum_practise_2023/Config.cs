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

    // интерфейс хэлпер для сериализации и десериализации обхектов
    internal interface Config : JsonSL.ITypeDiscriminator
    {
        // Обертывает несериализуемый контрол и сохраняет в поля конфига все необходимые данные для его последующей реконструкции
        void Deconstruct(System.Windows.Forms.Control ctl,PointF dpi);
        // возвращает контрол известного внутри него типа на основе конфига
        System.Windows.Forms.Control Construct(PointF dpi);
    }
    // реализация хэлпера для текстовых полей
    internal class TextFieldConfig : Config
    {
        // дискриминатор позволяет десериализатору узнавать каким из дочерних типов является этот объект, при помощи его мы можем хранить объекты разных дочерних типов в одном массиве
        // и сериализовать / десериализовать их с сохранением типов
        public string TypeDiscriminator => nameof(TextFieldConfig);
        public string FamilyName { get; set; }
        public float Size { get; set; }
        public FontStyle Style { get; set; }
        public string Text { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        
        // это не должно быть здесь, но у нас было мало времени
        public string FontFilePath { get; internal set; }

        public void Deconstruct(System.Windows.Forms.Control ctl, PointF dpi)
        {
            if (ctl is System.Windows.Forms.Label && ctl != null) {
                this.Text = ctl.Text;
                // размер в пунктах, положение конвертируется в дюймы для того что бы положение и размеры документа были одинаковыми независимо от устройства
                this.X = ((float)ctl.Location.X)/dpi.X;
                this.Y = ((float)ctl.Location.Y)/dpi.Y;
                this.FamilyName = ctl.Font.FontFamily.Name;
                this.Size  = ctl.Font.SizeInPoints;
                this.Style = ctl.Font.Style;
            }
            else
            {
                throw new ConfigException();
            }
        }
        public Control Construct(PointF dpi)
        {
            if ( this.Text == null || this.FamilyName == null ) {
                throw new ConfigException();
            }
            Control lb = new Label();
            lb.Text = Text;
            // конвертируем дюймы в пиксели
            lb.Location = new Point((int)(X*dpi.X),(int)(Y*dpi.Y));
            lb.AutoSize = true;
            lb.Margin = new Padding(0);
            // this one might throw an
            lb.Font = new Font(FamilyName, Size, Style,GraphicsUnit.Point);
            return lb;
        }
    }
    
}
