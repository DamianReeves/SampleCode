using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AvalonDock.Layout;

namespace Fooey.Editor.Framework
{
    public class LayoutInitializer : ILayoutUpdateStrategy
    {
        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
        {
            if (anchorableToShow.Content is ITool)
            {
                var preferredLocation = ((ITool)anchorableToShow.Content).PreferredLocation;
                string paneName = GetPaneName(preferredLocation);
                var toolsPane = layout.Descendents().OfType<LayoutAnchorablePane>().FirstOrDefault(d => d.Name == paneName);
                if (toolsPane == null)
                {
                    switch (preferredLocation)
                    {
                        case Dock.Left:
                            {
                                var parent = layout.Descendents().OfType<LayoutPanel>().First(d => d.Orientation == Orientation.Horizontal);
                                toolsPane = new LayoutAnchorablePane { DockWidth = new GridLength(200, GridUnitType.Pixel) };
                                parent.InsertChildAt(0, toolsPane);
                            }
                            break;
                        case Dock.Right:
                            {
                                var parent = layout.Descendents().OfType<LayoutPanel>().First(d => d.Orientation == Orientation.Horizontal);
                                toolsPane = new LayoutAnchorablePane { DockWidth = new GridLength(200, GridUnitType.Pixel) };
                                parent.Children.Add(toolsPane);
                            }
                            break;
                        case Dock.Bottom:
                            {
                                var parent = layout.Descendents().OfType<LayoutPanel>().First(d => d.Orientation == Orientation.Vertical);
                                toolsPane = new LayoutAnchorablePane { DockHeight = new GridLength(200, GridUnitType.Pixel) };
                                parent.Children.Add(toolsPane);
                            }
                            break;
                        case Dock.Top:
                            {
                                var parent = layout.Descendents().OfType<LayoutPanel>().First(d => d.Orientation == Orientation.Vertical);
                                toolsPane = new LayoutAnchorablePane { DockHeight = new GridLength(200, GridUnitType.Pixel) };
                                parent.InsertChildAt(0, toolsPane);
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
                toolsPane.Children.Add(anchorableToShow);
                return true;
            }

            return false;
        }

        private static string GetPaneName(Dock location)
        {
            switch (location)
            {
                case Dock.Left:
                    return "LeftPane";
                case Dock.Right:
                    return "RightPane";
                case Dock.Bottom:
                    return "BottomPane";
                case Dock.Top:
                    return "TopPane";
                default:
                    throw new ArgumentOutOfRangeException("location");
            }
        }

        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {

        }
    }
}