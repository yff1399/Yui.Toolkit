using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YuiFramework.CustomerControl
{
    public class WcButton : Button
    {
        /// <summary>
        /// 按钮的角半径
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(WcButton));

        #region path相关属性

        /// <summary>
        /// 按钮的path路径
        /// </summary>
        public PathGeometry PathData
        {
            get { return (PathGeometry)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }

        public static readonly DependencyProperty PathDataProperty =
            DependencyProperty.Register("PathData", typeof(PathGeometry), typeof(WcButton));

        /// <summary>
        /// 按钮的path宽度
        /// </summary>
        public double PathWidth
        {
            get { return (double)GetValue(PathWidthProperty); }
            set { SetValue(PathWidthProperty, value); }
        }

        public static readonly DependencyProperty PathWidthProperty =
            DependencyProperty.Register("PathWidth", typeof(double), typeof(WcButton));

        #endregion

        #region 阴影相关属性

        ///// <summary>
        ///// 阴影的模糊效果的半径
        ///// </summary>
        //public double ShadowBlurRadius
        //{
        //    get { return (double)GetValue(ShadowBlurRadiusProperty); }
        //    set { SetValue(ShadowBlurRadiusProperty, value); }
        //}

        //public static readonly DependencyProperty ShadowBlurRadiusProperty =
        //    DependencyProperty.Register("BlurRadius", typeof(double), typeof(WcButton), new FrameworkPropertyMetadata(7.0));

        ///// <summary>
        ///// 投影的方向
        ///// </summary>
        //public double ShadowDirection
        //{
        //    get { return (double)GetValue(ShadowDirectionProperty); }
        //    set { SetValue(ShadowDirectionProperty, value); }
        //}

        //public static readonly DependencyProperty ShadowDirectionProperty =
        //    DependencyProperty.Register("Direction", typeof(double), typeof(WcButton), new FrameworkPropertyMetadata(0.0));

        ///// <summary>
        ///// 投影的不透明度
        ///// </summary>
        //public double ShadowOpacity
        //{
        //    get { return (double)GetValue(ShadowOpacityProperty); }
        //    set { SetValue(ShadowOpacityProperty, value); }
        //}

        //public static readonly DependencyProperty ShadowOpacityProperty =
        //    DependencyProperty.Register("ShadowOpacity", typeof(double), typeof(WcButton), new FrameworkPropertyMetadata(1.0));

        /// <summary>
        /// 阴影颜色
        /// </summary>
        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly DependencyProperty ShadowColorProperty =
            DependencyProperty.Register("ShadowColor", typeof(Color), typeof(WcButton));

        ///// <summary>
        ///// 投影距纹理下方的距离
        ///// </summary>
        //public double ShadowDepth
        //{
        //    get { return (double)GetValue(ShadowDepthProperty); }
        //    set { SetValue(ShadowDepthProperty, value); }
        //}

        //public static readonly DependencyProperty ShadowDepthProperty =
        //    DependencyProperty.Register("ShadowDepth", typeof(double), typeof(WcButton), new FrameworkPropertyMetadata(3.0));


        #endregion

        #region 按钮颜色相关属性

        /// <summary>
        /// 鼠标经过背景色
        /// </summary>
        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.Register("MouseOverBackground", typeof(Brush), typeof(WcButton));

        /// <summary>
        /// 鼠标经过背景色
        /// </summary>
        public Brush MouseOverForeground
        {
            get { return (Brush)GetValue(MouseOverForegroundProperty); }
            set { SetValue(MouseOverForegroundProperty, value); }
        }

        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.Register("MouseOverForeground", typeof(Brush), typeof(WcButton));

        /// <summary>
        /// 鼠标经过背景色
        /// </summary>
        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }

        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.Register("PressedBackground", typeof(Brush), typeof(WcButton));



        /// <summary>
        /// 鼠标按钮背景色
        /// </summary>
        public Brush PressedForeground
        {
            get { return (Brush)GetValue(PressedForegroundProperty); }
            set { SetValue(PressedForegroundProperty, value); }
        }

        public static readonly DependencyProperty PressedForegroundProperty =
            DependencyProperty.Register("PressedForeground", typeof(Brush), typeof(WcButton), new FrameworkPropertyMetadata(Brushes.Black));

        #endregion

        static WcButton()
        {
            WcButton.DefaultStyleKeyProperty.OverrideMetadata(typeof(WcButton), new FrameworkPropertyMetadata(typeof(WcButton)));
        }
    }
}
