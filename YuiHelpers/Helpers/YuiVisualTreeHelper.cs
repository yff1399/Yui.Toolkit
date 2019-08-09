using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace YuiHelpers.Helpers
{
    public class YuiVisualTreeHelper
    {
        /// <summary>
        /// 获取鼠标指向的控件元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetElementUnderMouse<T>() where T : UIElement
        {
            return FindVisualParent<T>(Mouse.DirectlyOver as UIElement);
        }

        /// <summary>
         /// 向上查找父元素
         /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="element"></param>
        /// <returns>返回找到的第一个此类型的父元素</returns>
        private static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;

            while (parent != null)
            {
                var correctlyTyped = parent as T;
                if (correctlyTyped != null)
                    return correctlyTyped;

                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }

            return null;
        }

        /// <summary>
        /// WPF中查找元素的父元素，返回找到的第一个此类型的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="do_LocalElement"></param>
        /// <returns></returns>
        public static T FindParent<T>(DependencyObject do_LocalElement) where T : DependencyObject
        {
            DependencyObject do_Parent = (DependencyObject)VisualTreeHelper.GetParent(do_LocalElement);
            if (do_Parent != null)
            {
                if (do_Parent is T)
                {
                    return (T)do_Parent;
                }
                else
                {
                    do_Parent = FindParent<T>(do_Parent);
                    if (do_Parent != null && do_Parent is T)
                    {
                        return (T)do_Parent;
                    }
                }
            }
            return null;
        }

        /// <summary>
        ///WPF查找元素的子元素，返回找到的第一个此类型的子元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>返回找到的第一个此类型的子元素</returns>
        public static T FindVisualChild<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }

        /// <summary>
        /// 查找某种类型的子元素
        /// </summary>
        /// <param name="parent">A direct parent of the queried item.</param>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="childName">x:Name or Name of child. </param>
        /// <returns>The first parent item that matches the submitted type parameter. 
        /// If not matching item can be found, 
        /// a null parent is being returned.</returns>
        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid. 
            if (parent == null) return null;

            T foundChild = null;

            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }


        /// <summary>
        /// 查找某种类型的子控件，并返回一个List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="typename"></param>
        /// <returns></returns>
        public static List<T> GetChildObjects<T>(DependencyObject obj, Type typename) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T && (((T)child).GetType() == typename))
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child, typename));
            }
            return childList;
        }

        /// <summary>
        /// 通过名称查找子控件，并返回一个List集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<T> GetChildObjects<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject child = null;
            List<T> childList = new List<T>();

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T && (((T)child).GetType().ToString() == name | string.IsNullOrEmpty(name)))
                {
                    childList.Add((T)child);
                }
                childList.AddRange(GetChildObjects<T>(child, name));
            }
            return childList;
        }

        /// <summary>
        /// 通过名称查找某子元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetChildObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject child = null;
            T grandChild = null;

            for (int i = 0; i <= VisualTreeHelper.GetChildrenCount(obj) - 1; i++)
            {
                child = VisualTreeHelper.GetChild(obj, i);

                if (child is T && (((T)child).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)child;
                }
                else
                {
                    grandChild = GetChildObject<T>(child, name);
                    if (grandChild != null)
                        return grandChild;
                }
            }
            return null;
        }

        /// <summary>
        /// 通过名称查找父元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static T GetParentObject<T>(DependencyObject obj, string name) where T : FrameworkElement
        {
            DependencyObject parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T && (((T)parent).Name == name | string.IsNullOrEmpty(name)))
                {
                    return (T)parent;
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }
    }
}
