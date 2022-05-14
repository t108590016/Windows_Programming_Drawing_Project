using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Model : INotifyPropertyChanged
    {
        public event ModelChangedEventHandler _modelChanged;
        public event PropertyChangedEventHandler PropertyChanged;
        public delegate void ModelChangedEventHandler();
        const string LINE = "Line";
        const string RECTANGLE = "Rectangle";
        const string ELLIPSE = "Ellipse";
        const string PATH = @"108590016.txt";
        const string SELECTED = "SELECTED: ";
        const string ENTER = "\n";
        const char LEFT = '(';
        const char RIGHT = ')';
        const char COMMA = ',';
        CommandManager _commandManager = new CommandManager();
        bool _isPressed = false;
        Shapes _shapes = new Shapes();
        Shape _shape;
        Point _firstPoint = new Point();
        string _selectedDetail = "";
        ShapeFactory _factory = new ShapeFactory();
        ShapeFactory.ShapeType _type = ShapeFactory.ShapeType.None;
        IState _state = new PointerState();
        int _index = -1;
        Point _chosenFirstPoint = new Point();
        public string SelectedDetail
        {
            get
            {
                return _selectedDetail;
            }
            set
            {
                if (value != "")
                    _selectedDetail = SELECTED + value;
                else
                    _selectedDetail = "";
                Notify(nameof(SelectedDetail));
            }
        }

        public ShapeFactory.ShapeType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                if (value == ShapeFactory.ShapeType.None)
                    _state = new PointerState();
                else if (value == ShapeFactory.ShapeType.Line)
                    _state = new DrawLineState();
                else
                    _state = new DrawingState();
            }
        }

        //寫檔
        public void WriteFile()
        {
            File.Delete(PATH);
            string text = "";
            foreach (Shape shape in _shapes.GetShapes())
            {
                text += shape.ToString() + ENTER;
            }
            File.WriteAllText(PATH, text);
        }

        //讀檔
        public void ReadFile()
        {
            _shapes.Clear();
            string[] result = File.ReadAllLines(PATH);
            foreach (string text in result)
            {
                LoadShape(text);
            }
        }

        //載入圖形
        public void LoadShape(string text)
        {
            string[] stringArray = text.Split(new string[] { LEFT.ToString() }, StringSplitOptions.RemoveEmptyEntries);
            if (stringArray[0] == LINE)
                Type = ShapeFactory.ShapeType.Line;
            else if (stringArray[0] == RECTANGLE)
                Type = ShapeFactory.ShapeType.Rectangle;
            else if (stringArray[0] == ELLIPSE)
                Type = ShapeFactory.ShapeType.Ellipse;
            string[] pointArray = stringArray[1].Trim(LEFT).Trim(RIGHT).Split(new string[] { COMMA.ToString() }, StringSplitOptions.RemoveEmptyEntries);
            this.PressPointer(new Point(Int32.Parse(pointArray[0]), Int32.Parse(pointArray[1])));
            this.ReleasePointer(new Point(Int32.Parse(pointArray[1 + 1]), Int32.Parse(pointArray[1 + 1 + 1])));
            NotifyModelChanged();
        }

        //是否有通知
        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        //選擇圖案
        public void ChooseShape(Point point)
        {
            SelectedDetail = _shapes.ChooseShape(point);
            _index = _shapes.FindShape(point);
            if (_index != -1)
            {            
                _shape = _shapes.IndexAt(_index);
                _chosenFirstPoint = new Point(_shape.FirstPoint);
            }
            NotifyModelChanged();
        }

        //按下滑鼠
        public void PressPointer(Point point)
        {
            if (point.IsValid())
            {
                SelectedDetail = "";
                _firstPoint = new Point(point);
                _shapes.CancelChosen();
                _state.PressPointer(point, this);
                _isPressed = true;
            }
        }

        //取消
        public void ExecuteCommand()
        {
            _commandManager.Execute(new DrawCommand(this, _shape));
        }

        //取消
        public void ExecuteMoveCommand()
        {
            if (_shape != null && !_shape.FirstPoint.Equals(_chosenFirstPoint))
                _commandManager.Execute(new MoveCommand(this, _shape, _shape.FirstPoint, _chosenFirstPoint));
        }

        //移動圖形
        public void MoveShape(Point point)
        {
            _index = _shapes.FindShape(point);
            _shapes.MoveShapeByOffset(_index, new Point(point.GetDifferenceX(_firstPoint), point.GetDifferenceY(_firstPoint)));
            _firstPoint = new Point(point);
        }

        //移動圖形
        public void MoveShape(Shape shape, Point point)
        {
            shape.MoveShape(point);
        }

        //設定_shape的第二點
        public void SetSecondPoint(Point point)
        {
            if (_shape != null)
                _shape.SecondPoint = new Point(point);
        }

        //滑鼠移動
        public void MovePointer(Point point)
        {
            if (_isPressed)
                _state.MovePointer(point, this);
            NotifyModelChanged();
        }

        //畫線
        public void CreateLine(Point point) 
        {
            if (!_shapes.IsShapeNull(_firstPoint) && !_shapes.IsShapeNull(point))
            {
                _shape = new Line(_shapes.GetShape(_firstPoint), _shapes.GetShape(point));
                _commandManager.Execute(new DrawCommand(this, _shape));
                Type = ShapeFactory.ShapeType.None;
            }
        }

        //draw shape
        public void CreateShape(Point point)
        {
            _shape = _factory.CreateShape(Type);
            _shape.FirstPoint = new Point(this._firstPoint);
            _shape.SecondPoint = new Point(point);
        }

        //滑鼠放開
        public void ReleasePointer(Point point)
        {
            if (_isPressed)
                _state.ReleasePointer(point, this);             
            NotifyModelChanged();
            _shape = null;
            _isPressed = false;
        }

        //清除所有圖案
        public void Clear()
        {
            _isPressed = false;
            SelectedDetail = "";
            _shapes.CancelChosen();
            _shapes.Clear();
            _commandManager.Clear();
            NotifyModelChanged();
        }

        //繪製圖形
        public void DrawShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        //刪除圖形
        public void DeleteShape()
        {
            _shapes.RemoveTheLastItem();
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            _shapes.Draw(graphics);
            if (_isPressed && _shape != null)
                _shape.Draw(graphics);
        }

        //當model有改變時
        public void NotifyModelChanged()
        {
            if (_modelChanged != null)
                _modelChanged();
        }

        public Shape GetShape
        {
            get
            {
                return _shape;
            }
        }

        public Shapes GetShapes
        {
            get
            {
                return _shapes;
            }
        }

        //回到上一步
        public void Undo()
        {
            SelectedDetail = "";
            _shapes.CancelChosen();
            _commandManager.Undo();
            NotifyModelChanged();
        }

        //回到下一步
        public void Redo()
        {
            SelectedDetail = "";
            _shapes.CancelChosen();
            _commandManager.Redo();
            NotifyModelChanged();
        }

        public bool IsRedoEnabled
        {
            get
            {
                return _commandManager.IsRedoEnabled;
            }
        }

        public bool IsUndoEnabled
        {
            get
            {
                return _commandManager.IsUndoEnabled;
            }
        }
    }
}
