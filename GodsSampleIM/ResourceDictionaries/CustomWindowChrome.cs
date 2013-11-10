using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

namespace GodsSampleIM
{
    public partial class CustomWindowChrome : ResourceDictionary
    {
        public CustomWindowChrome()
        {
            InitializeComponent();
        }

        [Flags]
        private enum ResizeType
        {
            None = 0,
            Top = 1,
            Bottom = 2,
            Left = 4,
            Right = 8
        }

        private ResizeType _resizeType = ResizeType.None;
        private Rect _originalWindowRect;

        private Window GetWindow(object sender)
        {
            return ((FrameworkElement) sender).TemplatedParent as Window;
        }

        private void mainPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var win = GetWindow(sender);
            if (win != null)
            {
                win.DragMove();
            }
            e.Handled = true;
        }

        private void buttonClose_OnClick(object sender, RoutedEventArgs e)
        {
            var win = GetWindow(sender);
            if (win != null)
            {
                win.Close();
            }
        }


        private void InitiateResize(object sender, MouseButtonEventArgs e, ResizeType resizeType)
        {
            var rect = sender as Rectangle;
            if (rect != null)
            {
                _resizeType = resizeType;

                Window win = GetWindow(sender);
                _originalWindowRect = new Rect(win.Left, win.Top, win.Width, win.Height);
                rect.CaptureMouse();
            }

            // 务必设置已处理。否则在调用mainPanel_MouseLeftButtonDown中会处理DragMove
            // Drag会导致之后相应鼠标移动事件时无法获取鼠标位置
            e.Handled = true;
        }

        private void window_resize(object sender, MouseEventArgs e)
        {
            var rect = sender as Rectangle;
            if (rect == null)
            {
                return;
            }
            var win = rect.TemplatedParent as Window;

            if (win != null && _resizeType != ResizeType.None)
            {
                if ((_resizeType & ResizeType.Bottom) == ResizeType.Bottom)
                {
                    double height = e.GetPosition(win).Y + 5;
                    if (height > 0) win.Height = height;
                }
                else if ((_resizeType & ResizeType.Top) == ResizeType.Top)
                {
                    Point ptScreen = win.PointToScreen(e.GetPosition(win));
                    double newTop = Math.Min(_originalWindowRect.Bottom - win.MinHeight, ptScreen.Y);
                    win.Top = newTop;
                    win.Height = _originalWindowRect.Bottom - newTop;
                }

                if ((_resizeType & ResizeType.Right) == ResizeType.Right)
                {
                    double width = e.GetPosition(win).X + 5;
                    if (width > 0) win.Width = width;
                }
                else if ((_resizeType & ResizeType.Left) == ResizeType.Left)
                {
                    Point ptScreen = win.PointToScreen(e.GetPosition(win));
                    double newLeft = Math.Min(_originalWindowRect.Right - win.MinWidth, ptScreen.X);
                    win.Left = newLeft;
                    win.Width = _originalWindowRect.Right - newLeft;
                }
            }
            e.Handled = true;
        }

        private void window_endResize(object sender, MouseButtonEventArgs e)
        {
            _resizeType = ResizeType.None;

            var rect = sender as Rectangle;
            if (rect != null)
            {
                rect.ReleaseMouseCapture();
            }
            e.Handled = true;
        }

        private void window_top_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Top);
        }

        private void window_bottom_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Bottom);
        }

        private void window_left_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Left);
        }

        private void window_right_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Right);
        }

        private void window_topLeft_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Top | ResizeType.Left);
        }

        private void window_bottomRight_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Bottom | ResizeType.Right);
        }

        private void window_topRight_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Top | ResizeType.Right);
        }

        private void window_bottomLeft_resize(object sender, MouseButtonEventArgs e)
        {
            InitiateResize(sender, e, ResizeType.Bottom | ResizeType.Left);
        }
    }
}
