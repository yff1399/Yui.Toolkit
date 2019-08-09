using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Effects;
using YuiHelpers.Helpers;

namespace YuiHelpers.Converters
{
    public class ConverterShadow : IValueConverter
    {
        private static readonly IDictionary<ShadowDepth, DropShadowEffect> ShadowsDictionary;
        public static readonly ConverterShadow Instance = new ConverterShadow();

        static ConverterShadow()
        {
            var resourceDictionary = System.Windows.Application.Current.Resources;
            ShadowsDictionary = new Dictionary<ShadowDepth, DropShadowEffect>
            {
                { ShadowDepth.Depth0, null },
                { ShadowDepth.Depth1, (DropShadowEffect)resourceDictionary["DesignShadowDepth1"] },
                { ShadowDepth.Depth2, (DropShadowEffect)resourceDictionary["DesignShadowDepth2"] },
                { ShadowDepth.Depth3, (DropShadowEffect)resourceDictionary["DesignShadowDepth3"] },
                { ShadowDepth.Depth4, (DropShadowEffect)resourceDictionary["DesignShadowDepth4"] },
                { ShadowDepth.Depth5, (DropShadowEffect)resourceDictionary["DesignShadowDepth5"] },
            };
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ShadowDepth)) return null;

            return Clone(ShadowsDictionary[(ShadowDepth)value]);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }

        private static DropShadowEffect Clone(DropShadowEffect dropShadowEffect)
        {
            if (dropShadowEffect == null) return null;
            return new DropShadowEffect()
            {
                BlurRadius = dropShadowEffect.BlurRadius,
                Color = dropShadowEffect.Color,
                Direction = dropShadowEffect.Direction,
                Opacity = dropShadowEffect.Opacity,
                RenderingBias = dropShadowEffect.RenderingBias,
                ShadowDepth = dropShadowEffect.ShadowDepth
            };
        }
    }
}
