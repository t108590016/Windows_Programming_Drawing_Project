using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework6
{
    public class Shapes
    {
        const string LINE = "Line";
        List<Shape> _shapes;
        public Shapes()
        {
            _shapes = new List<Shape>();
        }

        //加入shape
        public void Add(Shape shape)
        {
            this._shapes.Add(shape);
        }

        //清除
        public void Clear()
        {
            this._shapes.Clear();
        }

        //回傳指定index的shape
        public Shape IndexAt(int index)
        {
            if (index != -1)
                return _shapes[index];
            return null;
        }

        //回傳_shapes
        public List<Shape> GetShapes()
        {
            return _shapes;
        }

        //回傳count
        public int GetCount()
        {
            return _shapes.Count();
        }

        //設定IsChosen
        public void SetChosen(int index, bool status)
        {
            if (index != -1)
                _shapes[index].IsChosen = status;
        }

        //尋找shape
        public int FindShape(Point point)
        {
            for (int i = _shapes.Count() - 1; i >= 0; i--)
                if (_shapes[i].IsInShape(point))
                    return i;
            return -1;
        }

        //尋找shape
        public Shape GetShape(Point point)
        {
            for (int i = _shapes.Count() - 1; i >= 0; i--)
                if (_shapes[i].IsInShape(point))
                    return _shapes[i];
            return null;
        }

        //轉換成string
        public string GetString(int index)
        {
            if (index != -1)
                return _shapes[index].ToString();
            return "";
        }

        //取消選取
        public void CancelChosen()
        {
            foreach (Shape shape in _shapes)
            {
                shape.IsChosen = false;
            }
        }

        //刪除最後一個元素
        public void RemoveTheLastItem()
        {
            this._shapes.RemoveAt(GetCount() - 1);
        }

        //draw
        public void Draw(IGraphics graphics)
        {
            foreach (Shape shape in _shapes)
                if (shape.IsLine)
                    shape.Draw(graphics);
            foreach (Shape shape in _shapes)
                if (!shape.IsLine)
                    shape.Draw(graphics);
        }

        //選擇圖案
        public string ChooseShape(Point point)
        {
            int index = this.FindShape(new Point(point));
            if (index != -1 && this.IndexAt(index).ShapeName != LINE)
                this.SetChosen(index, true);
            return this.GetString(index);
        }

        //回傳是不是null
        public bool IsShapeNull(Point point)
        {
            int index = this.FindShape(point);
            return this.IndexAt(index) == null;
        }

        //移動圖形
        public void MoveShapeByOffset(int index, Point point)
        {
            if (index > -1)
                _shapes[index].MoveShapeByOffset(point);
        }
    }
}
