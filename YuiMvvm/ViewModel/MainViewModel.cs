using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using YuiMvvm.Models;
using System;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using YuiMvvm.UserControls;

namespace YuiMvvm.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        #region 构造函数

        public MainViewModel()
        {
            AddDataSource();
        }

        #endregion

        #region 界面绑定属性

        private ObservableCollection<Menu> _menuList;

        /// <summary>
        /// 菜单列表
        /// </summary>
        public ObservableCollection<Menu> MenuList
        {
            get { return _menuList ?? (_menuList = new ObservableCollection<Menu>()); }
            set
            {
                if (!ReferenceEquals(_menuList, value))
                {
                    _menuList = value;
                    RaisePropertyChanged("MenuList");
                }
            }
        }

        private Menu _selectedItem;

        /// <summary>
        /// 选中项
        /// </summary>
        public Menu SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (!ReferenceEquals(_selectedItem, value))
                {
                    _selectedItem = value;
                    RaisePropertyChanged(() => SelectedItem);
                }
            }
        }


        private bool _isChecked = true;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                if (!ReferenceEquals(_isChecked, value))
                {
                    _isChecked = value;
                    RaisePropertyChanged("IsChecked");
                    SetMenuListCollpsed(value);
                }
            }
        }

        private object _content;

        /// <summary>
        /// 主界面展示窗口
        /// </summary>
        public object Content
        {
            get { return _content; }
            set
            {
                if (!ReferenceEquals(_content, value))
                {
                    _content = value;
                    RaisePropertyChanged(() => Content);
                }
            }
        }


        #endregion

        #region 方法
        private void SetMenuListCollpsed(bool ischecked)
        {
            MenuList.ToList().ForEach((p) =>
            {
                p.IsChecked = ischecked;
            });
        }

        /// <summary>
        /// 添加数据源
        /// </summary>
        private void AddDataSource()
        {
            MenuList.Add(new Menu() { DisplayName = "Yui控件样式", SortIndex = 1 });
            MenuList.Add(new Menu() { DisplayName = "随机粒子连线", SortIndex = 2 });
            MenuList.Add(new Menu() { DisplayName = "RadioButtonControl", SortIndex = 3 });
            MenuList.Add(new Menu() { DisplayName = "SearchBoxControl", SortIndex = 4 });
            MenuList.Add(new Menu() { DisplayName = "ComboBoxControl", SortIndex = 5 });
            MenuList.Add(new Menu() { DisplayName = "SliderControl", SortIndex = 6 });
            MenuList.Add(new Menu() { DisplayName = "PictureCarouselControl", SortIndex = 7 });
            MenuList.Add(new Menu() { DisplayName = "KeyWordTextBox", SortIndex = 8 });
            MenuList.Add(new Menu() { DisplayName = "OtherControl", SortIndex = 99 });
        }

        public override void Cleanup()
        {
            base.Cleanup();
        }

        #endregion

        #region 命令

        public RelayCommand SelectionChangedCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var item = SelectedItem;
                    if(item?.DisplayName != null)
                    {
                        switch(item.DisplayName)
                        {
                            case "Yui控件样式":
                                Content = new UctYuiControl();
                                break;
                            case "随机粒子连线":
                                Content = new UctParticleLayer();
                                break;
                            case "KeyWordTextBox":
                                Content = new UctYuiControl();
                                break;
                        }
                    }
                });
            }
        }

        #endregion
    }
}