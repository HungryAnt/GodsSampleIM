using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GodsSampleIM.CommonControls
{
    [TemplatePart(Name = "PART_MainPanel", Type = typeof(Panel))]
    class SearchControl : Control
    {
        static SearchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchControl),
                new FrameworkPropertyMetadata(typeof(SearchControl)));
        }

        public Brush HintBackgroundBrush
        {
            get { return (Brush)GetValue(HintBackgroundBrushProperty); }
            set { SetValue(HintBackgroundBrushProperty, value); }
        }

        public static readonly DependencyProperty HintBackgroundBrushProperty =
            DependencyProperty.Register("HintBackgroundBrush", typeof(Brush), typeof(SearchControl),
                                        new UIPropertyMetadata(new SolidColorBrush(Color.FromRgb(0x23, 0x7D, 0xA4))));

        public string HintText
        {
            get { return (string)GetValue(HintTextProperty); }
            set { SetValue(HintTextProperty, value); }
        }

        public static readonly DependencyProperty HintTextProperty =
            DependencyProperty.Register("HintText", typeof (string), typeof (SearchControl),
                                        new UIPropertyMetadata("搜索"));

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            //Panel mainPanel = GetTemplateChild("PART_MainPanel") as Panel;
            TextBox edit = GetTemplateChild("PART_Edit") as TextBox;
            TextBlock hint = GetTemplateChild("PART_Hint") as TextBlock;
            Panel backPanel = GetTemplateChild("PART_BackPanel") as Panel;

            if (edit != null && backPanel != null && hint != null)
            {
                edit.TextChanged += (sender, e) =>
                    {
                        bool needShowHint = string.IsNullOrEmpty(edit.Text);
                        hint.Visibility = backPanel.Visibility = needShowHint ?
                            Visibility.Visible : Visibility.Hidden;
                    };
            }
        }

    }
}
