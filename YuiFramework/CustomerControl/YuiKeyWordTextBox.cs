using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace YuiFramework.CustomerControl
{
    public class YuiKeyWordTextBox : TextBox
    {
        public const string PART_Show = "PART_Show";
        public const string PART_ContentHost = "PART_ContentHost";
        public const string PART_ContentLayer = "PART_ContentLayer";
        private TextBlock txbShow;
        private ScrollViewer scrollContent;
        private ScrollViewer scrollLayer;
        private string preValue = "";

        private static readonly string KEYWORD = "(auto|double|int|struct|break|else|long|switch|case|" +
                                                 "enum|register|typedef|char|extern|return|union|const|" +
                                                 "float|short|unsigned|continue|for|signed|void|default|" +
                                                 "goto|sizeof|volatile|do|if|static|while|def|yield|and|as|)";

        private static readonly string KEYCHAR = "[\\r\\n\\t\\\\[\\]\\^\\-_*×――(^)$%~!＠@＃#$…&%￥—+=<>《》!！|??？:：•`·、。，；,.;/\'\"{}（）‘’“”-]";
        public string KeyWord
        {
            get { return (string)GetValue(KeyWordProperty); }
            set { SetValue(KeyWordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyWord.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyWordProperty =
            DependencyProperty.Register("KeyWord", typeof(string), typeof(YuiKeyWordTextBox), new PropertyMetadata(KEYWORD));

        public Brush KeyWordColor
        {
            get { return (Brush)GetValue(KeyWordColorProperty); }
            set { SetValue(KeyWordColorProperty, value); }
        }
        // Using a DependencyProperty as the backing store for KeyWordColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyWordColorProperty =
            DependencyProperty.Register("KeyWordColor", typeof(Brush), typeof(YuiKeyWordTextBox), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(69, 147, 214))));

        static YuiKeyWordTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(YuiKeyWordTextBox), new FrameworkPropertyMetadata(typeof(YuiKeyWordTextBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            txbShow = GetTemplateChild(PART_Show) as TextBlock;
            if (!string.IsNullOrWhiteSpace(preValue) && txbShow != null)//trigger OnTextChanged first
                ChangeForeground(preValue);
            scrollContent = GetTemplateChild(PART_ContentHost) as ScrollViewer;
            scrollLayer = GetTemplateChild(PART_ContentLayer) as ScrollViewer;
            if (scrollContent != null)
            {
                scrollContent.ScrollChanged += (sender, args) =>
                {
                    if (!(sender is ScrollViewer sv)) return;
                    if (scrollLayer == null) return;
                    scrollLayer.ScrollToVerticalOffset(sv.VerticalOffset);
                };
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            if (txbShow == null)
            {
                preValue = Text;
                return;
            }
            ChangeForeground(Text);
        }

        private void ChangeForeground(string text)
        {
            txbShow.Text = "";
            txbShow.TextEffects.Clear();
            txbShow.Text = text;
            string s = txbShow.Text;
            Regex r = new Regex(KeyWord);
            MatchCollection mc = r.Matches(this.txbShow.Text);

            int start = 0;
            foreach (Match match in mc)
            {
                int i = s.IndexOf(match.Value, start, StringComparison.Ordinal);
                if (i == -1)
                    continue;

                int iPre = i - 1;
                int iNext = i + match.Length;

                Regex reg = new Regex(KEYCHAR);
                if ((iPre >= 0 && s[iPre] != ' ' && !reg.IsMatch(s[iPre].ToString())) ||
                    (iNext != s.Length && s[iNext] != ' ' && !reg.IsMatch(s[iNext].ToString())))
                {
                    start = i + match.Length;
                    continue;
                }

                TextEffect tex = new TextEffect()
                {
                    Foreground = KeyWordColor,
                    PositionCount = match.Length,
                    PositionStart = i,
                };
                txbShow.TextEffects.Add(tex);
                start = i + match.Length;
            }
        }
    }
}
