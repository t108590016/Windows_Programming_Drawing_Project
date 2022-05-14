using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using homework6;
using Windows.UI.Xaml.Controls;

namespace DrawingApp.PresentationModel
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        bool _isClear = true;
        bool _isEllipse = true;
        bool _isRectangle = true;
        bool _isLine = true;
        public PresentationModel(Model model)
        {
            this._model = model;
        }
        public bool IsClear
        {
            get
            {
                return _isClear;
            }
            set
            {
                _isClear = value;
                Notify(nameof(this.IsClear));
            }
        }

        public bool IsEllipse
        {
            get
            {
                return _isEllipse;
            }
            set
            {
                _isEllipse = value; 
                Notify(nameof(this.IsEllipse));
            }
        }

        public bool IsRectangle
        {
            get
            {
                return _isRectangle;
            }
            set
            {
                _isRectangle = value;
                Notify(nameof(this.IsRectangle));
            }
        }

        public bool IsLine
        {
            get
            {
                return _isLine;
            }
            set
            {
                _isLine = value;
                Notify(nameof(this.IsLine));
            }
        }

        //是否有通知
        private void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
