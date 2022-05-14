using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using homework6;

namespace DrawingForm.PresentationModel
{
    public class PresentationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Model _model;
        bool _isClear = true;
        bool _isEllipse = true;
        bool _isRectangle = true;
        bool _isLine = true;
        String _selectedItem = "";
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

        public string SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                Notify(nameof(this._selectedItem));
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
