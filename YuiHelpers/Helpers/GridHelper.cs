using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace YuiHelpers.Helpers
{

    /// <summary>
    /// Grid定义行和列宽高比例的辅助类，用于简化RowDefinitions和ColumnDefinitions的定义
    /// <para>*表示按同比例，auto自动大小，空（","）表示等比例，数字表示实际像素值</para>
    /// <para>示例：GridHelper.ColumnDefinitions="2*,auto,*"</para>
    /// </summary>
    public class GridHelper
    {
        #region RowDefinitions 附加属性

        /// <summary>
        /// Identified the RowDefinitions attached property
        /// </summary>
        public static readonly DependencyProperty RowDefinitionsProperty =
            DependencyProperty.RegisterAttached("RowDefinitions", typeof(string), typeof(GridHelper), new PropertyMetadata("", OnRowDefinitionsPropertyChanged));

        /// <summary>
        /// Gets the value of the RowDefinitions property
        /// </summary>
        public static string GetRowDefinitions(DependencyObject d)
        {
            return (string)d.GetValue(RowDefinitionsProperty);
        }

        /// <summary>
        /// Sets the value of the RowDefinitions property
        /// </summary>
        public static void SetRowDefinitions(DependencyObject d, string value)
        {
            d.SetValue(RowDefinitionsProperty, value);
        }

        /// <summary>
        /// Handles property changed event for the RowDefinitions property, constructing
        /// the required RowDefinitions elements on the grid which this property is attached to.
        /// </summary>
        private static void OnRowDefinitionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid targetGrid = d as Grid;

            // construct the required row definitions
            targetGrid.RowDefinitions.Clear();
            string rowDefs = e.NewValue as string;
            var rowDefArray = rowDefs.Split(',');
            foreach (string rowDefinition in rowDefArray)
            {
                if (rowDefinition.Trim() == "")
                {
                    targetGrid.RowDefinitions.Add(new RowDefinition());
                }
                else
                {
                    targetGrid.RowDefinitions.Add(new RowDefinition()
                    {
                        Height = ParseLength(rowDefinition)
                    });
                }
            }
        }

        #endregion

        #region ColumnDefinitions 附加属性

        /// <summary>
        /// Identifies the ColumnDefinitions attached property
        /// </summary>
        public static readonly DependencyProperty ColumnDefinitionsProperty =
            DependencyProperty.RegisterAttached("ColumnDefinitions", typeof(string), typeof(GridHelper),
                new PropertyMetadata("", new PropertyChangedCallback(OnColumnDefinitionsPropertyChanged)));

        /// <summary>
        /// Gets the value of the ColumnDefinitions property
        /// </summary>
        public static string GetColumnDefinitions(DependencyObject d)
        {
            return (string)d.GetValue(ColumnDefinitionsProperty);
        }

        /// <summary>
        /// Sets the value of the ColumnDefinitions property
        /// </summary>
        public static void SetColumnDefinitions(DependencyObject d, string value)
        {
            d.SetValue(ColumnDefinitionsProperty, value);
        }

        /// <summary>
        /// Handles property changed event for the ColumnDefinitions property, constructing
        /// the required ColumnDefinitions elements on the grid which this property is attached to.
        /// </summary>
        private static void OnColumnDefinitionsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Grid targetGrid = d as Grid;

            // construct the required column definitions
            targetGrid.ColumnDefinitions.Clear();
            string columnDefs = e.NewValue as string;
            var columnDefArray = columnDefs.Split(',');
            foreach (string columnDefinition in columnDefArray)
            {
                if (columnDefinition.Trim() == "")
                {
                    targetGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }
                else
                {
                    targetGrid.ColumnDefinitions.Add(new ColumnDefinition()
                    {
                        Width = ParseLength(columnDefinition)
                    });
                }
            }
        }

        #endregion

        //拆分字符串，创建GridLength
        private static GridLength ParseLength(string length)
        {
            length = length.Trim();

            if (length.ToLowerInvariant().Equals("auto"))
            {
                return new GridLength(0, GridUnitType.Auto);
            }
            else if (length.Contains("*"))
            {
                length = length.Replace("*", "");
                if (string.IsNullOrEmpty(length)) length = "1";
                return new GridLength(double.Parse(length), GridUnitType.Star);
            }

            return new GridLength(double.Parse(length), GridUnitType.Pixel);
        }
    }
}
