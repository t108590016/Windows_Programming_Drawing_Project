using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingForm.PresentationModel;
using homework6;
using GoogleDriveUploader.GoogleDrive;
using System.IO;

namespace DrawingForm
{
    public partial class Form1 : Form
    {
        const string PATH = @"108590016.txt";
        const string DOWNLOAD_PATH = @"./";
        const string APPLICATION_NAME = "DrawAnywhere";
        const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
        const string CANVAS = "_canvas";
        const string ENABLE = "Enabled";
        const string TEXT = "Text";
        const string UNDO = "Undo";
        const string REDO = "Redo";
        Model _model = new Model();
        PresentationModel.PresentationModel _presentationModel;
        Panel _canvas = new DoubleBufferedPanel();
        ToolStripButton _undo;
        ToolStripButton _redo;
        GoogleDriveService _service;
        public Form1()
        {
            _presentationModel = new PresentationModel.PresentationModel(_model);
            InitializeComponent();
            InitializeCanvas();
            InitializeToolStrip();
            InitializeBindings();
            _clear.Click += HandleClearButtonClick;
            _ellipse.Click += HandleEllipseButtonClick;
            _rectangle.Click += HandleRectangleButtonClick;
            _model._modelChanged += HandleModelChanged;
            _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME);

        }

        //按下Save
        private void ClickSaveButtonAsync(object sender, EventArgs e)
        {
            CheckSaveForm checkSaveForm = new CheckSaveForm();
            checkSaveForm.ShowDialog();
            if (checkSaveForm.DialogResult == DialogResult.OK)
            {
                Task.Run(() => { _model.WriteFile();
                    List<Google.Apis.Drive.v2.Data.File> fileList = _service.ListRootFileAndFolder();
                    Google.Apis.Drive.v2.Data.File foundFile = fileList.Find(
                        item =>
                        {
                            return item.Title == PATH;
                        }
                    );
                    _service.DeleteFile(foundFile.Id);
                    const string CONTENT_TYPE = "text/strings";
                    _service.UploadFile(PATH, CONTENT_TYPE);
                });
            }
        }

        //按下Load
        private void ClickLoadButton(object sender, EventArgs e)
        {
            List<Google.Apis.Drive.v2.Data.File> root = _service.ListRootFileAndFolder();
            foreach (Google.Apis.Drive.v2.Data.File file in root)
                if (file.Title == PATH)
                    _service.DownloadFile(file, DOWNLOAD_PATH);
            _model.ReadFile();
        }

        //初始化binding
        public void InitializeBindings()
        {
            _clear.DataBindings.Add(ENABLE, this._presentationModel, nameof(PresentationModel.PresentationModel.IsClear));
            _ellipse.DataBindings.Add(ENABLE, this._presentationModel, nameof(PresentationModel.PresentationModel.IsEllipse));
            _rectangle.DataBindings.Add(ENABLE, this._presentationModel, nameof(PresentationModel.PresentationModel.IsRectangle));
            _line.DataBindings.Add(ENABLE, this._presentationModel, nameof(PresentationModel.PresentationModel.IsLine));
            _selectedDetail.DataBindings.Add(TEXT, this._model, nameof(_model.SelectedDetail));
        }

        //初始化canvas
        public void InitializeCanvas()
        {
            _canvas.Name = CANVAS;
            _canvas.Dock = DockStyle.Fill;
            _canvas.BackColor = System.Drawing.Color.LightYellow;
            _canvas.MouseDown += HandleCanvasPressed;
            _canvas.MouseUp += HandleCanvasReleased;
            _canvas.MouseMove += HandleCanvasMoved;
            _canvas.Paint += HandleCanvasPaint;
            Controls.Add(_canvas);
        }

        //初始化ToolStrip
        public void InitializeToolStrip()
        {
            ToolStrip toolStrip = new ToolStrip();
            toolStrip.Parent = this;
            _undo = new ToolStripButton(UNDO, null, UndoHandler);
            _undo.Enabled = false;
            toolStrip.Items.Add(_undo);
            _redo = new ToolStripButton(REDO, null, RedoHandler);
            _redo.Enabled = false;
            toolStrip.Items.Add(_redo);
        }

        //按下_clear
        public void HandleClearButtonClick(object sender, System.EventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.None;
            _model.Clear();
            _presentationModel.IsClear = true;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = true;
            RefreshForm();
        }

        //按下_rectangular
        public void HandleRectangleButtonClick(object sender, System.EventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.Rectangle;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = false;
            _presentationModel.IsLine = true;
        }

        //按下_ellipse
        public void HandleEllipseButtonClick(object sender, System.EventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.Ellipse;
            _presentationModel.IsEllipse = false;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = true;
        }

        //按下_line
        private void HandleLineButtonClick(object sender, EventArgs e)
        {
            _model.Type = ShapeFactory.ShapeType.Line;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = false;
        }

        //當按下滑鼠
        public void HandleCanvasPressed(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.PressPointer(new homework6.Point(e.X, e.Y));
            RefreshForm();
        }

        //當放開滑鼠
        public void HandleCanvasReleased(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.ReleasePointer(new homework6.Point(e.X, e.Y));
            _presentationModel.IsClear = true;
            _presentationModel.IsEllipse = true;
            _presentationModel.IsRectangle = true;
            _presentationModel.IsLine = _model.Type != ShapeFactory.ShapeType.Line;
            //_model.Type = ShapeFactory.ShapeType.None;
            RefreshForm();
        }

        //當滑鼠移動
        public void HandleCanvasMoved(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            _model.MovePointer(new homework6.Point(e.X, e.Y));
            RefreshForm();
        }

        //畫圖
        public void HandleCanvasPaint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            _model.Draw(new WindowsFormsGraphicsAdaptor(e.Graphics));
        }

        //當model改變時
        public void HandleModelChanged()
        {
            Invalidate(true);
        }

        //上一步
        void UndoHandler(Object sender, EventArgs e)
        {
            _model.Undo();
            RefreshForm();
        }

        //下一步
        void RedoHandler(Object sender, EventArgs e)
        {
            _model.Redo();
            RefreshForm();
        }

        //刷新頁面
        void RefreshForm()
        {
            _redo.Enabled = _model.IsRedoEnabled;
            _undo.Enabled = _model.IsUndoEnabled;
            Invalidate();
        }
    }
}
