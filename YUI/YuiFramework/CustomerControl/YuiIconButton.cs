using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YuiFramework.CustomerControl
{
    public class YuiIconButton : Button
    {

        #region 依赖项属性

        #region 按钮圆角

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(new CornerRadius(3)));

        #endregion

        #region 左边的Icon图标

        public PathGeometry LeftIcon
        {
            get { return (PathGeometry)GetValue(LeftIconProperty); }
            set { SetValue(LeftIconProperty, value); }
        }

        public static readonly DependencyProperty LeftIconProperty =
            DependencyProperty.Register("LeftIcon", typeof(PathGeometry), typeof(YuiIconButton));

        #endregion

        #region 右边的Icon图标

        public PathGeometry RightIcon
        {
            get { return (PathGeometry)GetValue(RightIconProperty); }
            set { SetValue(RightIconProperty, value); }
        }

        public static readonly DependencyProperty RightIconProperty =
            DependencyProperty.Register("RightIcon", typeof(PathGeometry), typeof(YuiIconButton));

        #endregion

        #region 图标的颜色

        public Brush IconColor
        {
            get { return (Brush)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        public static readonly DependencyProperty IconColorProperty =
            DependencyProperty.Register("IconColor", typeof(Brush), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(Brushes.Black));

        #endregion

        #region 鼠标划过背景色

        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(Brushes.AliceBlue));

        #endregion

        #region 鼠标划过前景色

        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(Brushes.Black));

        #endregion

        #region 是否可见

        public Visibility LeftIconVisibility
        {
            get { return (Visibility)GetValue(LeftIconVisibilityProperty); }
            set { SetValue(LeftIconVisibilityProperty, value); }
        }

        public static readonly DependencyProperty LeftIconVisibilityProperty =
            DependencyProperty.Register("LeftIconVisibility", typeof(Visibility), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(Visibility.Visible));

        public Visibility RightIconVisibility
        {
            get { return (Visibility)GetValue(RightIconVisibilityProperty); }
            set { SetValue(RightIconVisibilityProperty, value); }
        }

        public static readonly DependencyProperty RightIconVisibilityProperty =
            DependencyProperty.Register("RightIconVisibility", typeof(Visibility), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(Visibility.Collapsed));


        public Visibility ContentVisibility
        {
            get { return (Visibility)GetValue(ContentVisibilityProperty); }
            set { SetValue(ContentVisibilityProperty, value); }
        }

        public static readonly DependencyProperty ContentVisibilityProperty =
            DependencyProperty.Register("ContentVisibility", typeof(Visibility), typeof(YuiIconButton),
                new FrameworkPropertyMetadata(Visibility.Visible));

        #endregion

        #region 图标大小

        public double IconWidth
        {
            get { return (double)GetValue(IconWidthProperty); }
            set { SetValue(IconWidthProperty, value); }
        }

        public static readonly DependencyProperty IconWidthProperty =
            DependencyProperty.Register("IconWidth", typeof(double), typeof(YuiIconButton), new PropertyMetadata(15.0));

        #endregion

        #region 按钮点击背景色

        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(YuiIconButton),
                new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255, 102, 0))));

        #endregion
        
        #region 几种可供选择的按钮类型

        public YuiIconButtonType ButtonType
        {
            get { return (YuiIconButtonType) GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        public static readonly DependencyProperty ButtonTypeProperty =
            DependencyProperty.Register("ButtonType", typeof (YuiIconButtonType), typeof (YuiIconButton),
                new FrameworkPropertyMetadata(YuiIconButtonType.Default));

        #endregion
        
        #endregion

        #region 静态构造函数

        static YuiIconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(YuiIconButton), new FrameworkPropertyMetadata(typeof(YuiIconButton)));
        }

        #endregion
    }

    public enum YuiIconButtonType
    {
        Custom,
        Default,
        Info,
        Warning,
        Danger,
        Primary
    }
}
