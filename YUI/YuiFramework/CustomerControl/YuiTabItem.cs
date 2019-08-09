using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace YuiFramework.CustomerControl
{
    public class YuiTabItem : TabItem
    {
        /*
         * 1.是否首项   
         * 2.是否完成
         * 3.完成背景色 默认为Brushes.SlateGray 
         */

        public bool IsFistTag
        {
            get { return (bool)GetValue(IsFistTagProperty); }
            set { SetValue(IsFistTagProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsFistTag.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsFistTagProperty =
            DependencyProperty.Register("IsFistTag", typeof(bool), typeof(YuiTabItem), new PropertyMetadata(false));


        public bool IsComplete
        {
            get { return (bool)GetValue(IsCompleteProperty); }
            set { SetValue(IsCompleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsComplete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCompleteProperty =
            DependencyProperty.Register("IsComplete", typeof(bool), typeof(YuiTabItem), new PropertyMetadata(false));

        /// <summary>
        /// 是否显示装饰线
        /// </summary>
        public bool IsShowDecorateLine
        {
            get { return (bool)GetValue(IsShowDecorateLineProperty); }
            set { SetValue(IsShowDecorateLineProperty, value); }
        }
        /// <summary>
        /// 是否显示装饰线,默认不显示
        /// </summary>
        public static readonly DependencyProperty IsShowDecorateLineProperty =
            DependencyProperty.Register("IsShowDecorateLine", typeof(bool), typeof(YuiTabItem), new PropertyMetadata(false));


        public TagDrawTypeEnum TagDrawType
        {
            get { return (TagDrawTypeEnum)GetValue(TagDrawTypeProperty); }
            set { SetValue(TagDrawTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagDrawTypeProperty =
            DependencyProperty.Register("TagDrawType", typeof(TagDrawTypeEnum), typeof(YuiTabItem), new PropertyMetadata(TagDrawTypeEnum.Arrow));

        private Grid _grid;
        private Polyline _ccc;
        private Polyline _aaa;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _grid = GetTemplateChild("grid") as Grid;
            _aaa = GetTemplateChild("aaa") as Polyline;
            _ccc = GetTemplateChild("ccc") as Polyline;
            switch (TagDrawType)
            {
                case TagDrawTypeEnum.Arrow:
                    if (IsFistTag == false) Draw_ArrowA();
                    Draw_ArrowC();
                    break;
                case TagDrawTypeEnum.Bevel:
                    if (IsFistTag == false) Draw_BevelA();
                    Draw_BevelC();
                    break;
            }
        }

        /// <summary>
        /// 绘制箭头尾部
        /// </summary>
        private void Draw_ArrowA()
        {
            if (_aaa != null)
            {
                double X = this.Height / 2;
                Point Point0 = new Point(0, 0);
                Point Point1 = new Point(X, 0);
                Point Point2 = new Point(X, this.Height);
                Point Point3 = new Point(0, this.Height);
                Point Point4 = new Point(X - 3, this.Height / 2 + 3);
                Point Point5 = new Point(X, this.Height / 2);
                Point Point6 = new Point(X - 3, this.Height / 2 - 3);



                //定义点集合对象
                PointCollection pointCollection = new PointCollection();
                pointCollection.Add(Point0);
                pointCollection.Add(Point1);
                pointCollection.Add(Point2);
                pointCollection.Add(Point3);
                pointCollection.Add(Point4);
                pointCollection.Add(Point5);
                pointCollection.Add(Point6);
                _aaa.Points = pointCollection;
                //_aaa.Margin = new Thickness(2,0,0,0);
            }
        }
        /// <summary>
        /// 绘制箭头头部
        /// </summary>
        private void Draw_ArrowC()
        {
            if (_ccc != null)
            {
                double X = this.Height / 2;
                Point Point0 = new Point(0, 0);
                Point Point1 = new Point(X - 3, this.Height / 2 - 3);
                Point Point2 = new Point(X, this.Height / 2);
                Point Point3 = new Point(X - 3, this.Height / 2 + 3);
                Point Point4 = new Point(0, this.Height);


                //定义点集合对象
                PointCollection pointCollection = new PointCollection();
                pointCollection.Add(Point0);
                pointCollection.Add(Point1);
                pointCollection.Add(Point2);
                pointCollection.Add(Point3);
                pointCollection.Add(Point4);
                _ccc.Points = pointCollection;
                _ccc.Margin = new Thickness(0, 0, -X + 5, 0);
            }
        }

        /// <summary>
        /// 绘制斜角尾部
        /// </summary>
        private void Draw_BevelA()
        {
            if (_aaa != null)
            {
                double X = this.Height;
                Point Point0 = new Point(0 + 15, 0);
                Point Point1 = new Point(X, 0);
                Point Point2 = new Point(X, this.Height);


                //定义点集合对象
                PointCollection pointCollection = new PointCollection();
                pointCollection.Add(Point0);
                pointCollection.Add(Point1);
                pointCollection.Add(Point2);
                _aaa.Points = pointCollection;
                //_aaa.Margin = new Thickness(2,0,0,0);
            }
        }
        /// <summary>
        /// 绘制斜角头部
        /// </summary>
        private void Draw_BevelC()
        {
            if (_ccc != null)
            {
                double X = this.Height;
                Point Point0 = new Point(0, 0);
                Point Point1 = new Point(X - 15, this.Height);
                Point Point2 = new Point(0, this.Height);


                //定义点集合对象
                PointCollection pointCollection = new PointCollection();
                pointCollection.Add(Point0);
                pointCollection.Add(Point1);
                pointCollection.Add(Point2);
                _ccc.Points = pointCollection;
                _ccc.Margin = new Thickness(0, 0, -X, 0);
            }
        }


        /// <summary>
        /// 箭头类型
        /// </summary>
        public enum TagDrawTypeEnum
        {
            /// <summary>
            /// 箭头类型
            /// </summary>
            Arrow,
            /// <summary>
            /// 斜角类型
            /// </summary>
            Bevel
        }
    }
}
