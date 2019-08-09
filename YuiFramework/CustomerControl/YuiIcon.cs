using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YuiFramework.CustomerControl
{

    /// <summary>
    /// 这是一个只有图标的控件
    /// </summary>
    public class YuiIcon : Button
    {
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }
        
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(YuiIcon), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(100, 100, 100))));

        public Brush MouseOverBorderBrush
        {
            get { return (Brush)GetValue(MouseOverBorderBrushProperty); }
            set { SetValue(MouseOverBorderBrushProperty, value); }
        }
        
        public static readonly DependencyProperty MouseOverBorderBrushProperty =
            DependencyProperty.Register("MouseOverBorderBrush", typeof(Brush), typeof(YuiIcon), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(200, 200, 200))));

        public PathGeometry PathData
        {
            get { return (PathGeometry)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }
        
        public static readonly DependencyProperty PathDataProperty =
            DependencyProperty.Register("PathData", typeof(PathGeometry), typeof(YuiIcon), new FrameworkPropertyMetadata(null));

        public double PathWidth
        {
            get { return (double)GetValue(PathWidthProperty); }
            set { SetValue(PathWidthProperty, value); }
        }
        
        public static readonly DependencyProperty PathWidthProperty =
            DependencyProperty.Register("PathWidth", typeof(double), typeof(YuiIcon), new FrameworkPropertyMetadata(7.0));

        public string PathToolTip
        {
            get { return (string)GetValue(PathToolTipProperty); }
            set { SetValue(PathToolTipProperty, value); }
        }
        
        public static readonly DependencyProperty PathToolTipProperty =
            DependencyProperty.Register("PathToolTip", typeof(string), typeof(YuiIcon), new FrameworkPropertyMetadata(null));




        public Brush PathColor
        {
            get { return (Brush)GetValue(PathColorProperty); }
            set { SetValue(PathColorProperty, value); }
        }
        
        public static readonly DependencyProperty PathColorProperty =
            DependencyProperty.Register("PathColor", typeof(Brush), typeof(YuiIcon), new FrameworkPropertyMetadata(Brushes.White));



        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(YuiIcon));

        static YuiIcon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(YuiIcon), new FrameworkPropertyMetadata(typeof(YuiIcon)));
        }
    }
}
