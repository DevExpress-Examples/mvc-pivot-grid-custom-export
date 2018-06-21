using DevExpress.Web.ASPxPivotGrid;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using System.Drawing;

public class PivotGridHelper
{
    static PivotGridSettings _settings;
    public static PivotGridSettings Settings
    {
        get
        {
            if (_settings == null)
            {
                _settings = GetSettings();
            }
            return _settings;
        }
    }
    static PivotXlsxExportOptions _xlsOptions;
    public static PivotXlsxExportOptions XlsxOptions
    {
        get
        {
            if (_xlsOptions == null)
            {
                _xlsOptions = GetXlsOptions();
            }
            return _xlsOptions;
        }
    }
    static PivotGridSettings GetSettings()
    {
        PivotGridSettings settings = new PivotGridSettings();
        settings.Name = "PivotGrid";
        settings.CallbackRouteValues = new { Controller = "Home", Action = "PivotGridPartial" };
        settings.OptionsView.HorizontalScrollBarMode = DevExpress.Web.ScrollBarMode.Visible;
        settings.Width = new System.Web.UI.WebControls.Unit(90, System.Web.UI.WebControls.UnitType.Percentage);

        settings.SettingsExport.OptionsPrint.PrintColumnAreaOnEveryPage = true;
        settings.SettingsExport.OptionsPrint.PrintRowAreaOnEveryPage = true;
        settings.SettingsExport.OptionsPrint.PageSettings.Landscape = true;

        settings.SettingsExport.CustomExportCell = (sender, e) =>
        {

            // Determine whether the cell is Grand Total.
            if ((e.ColumnField == null) || (e.RowField == null))
            {
                // Specify the text to display in a cell.
                ((DevExpress.XtraPrinting.TextBrick)e.Brick).Text = string.Format(
                     "=> {0}",
                     ((DevExpress.XtraPrinting.TextBrick)e.Brick).Text);
                // Specify the colors used to paint the cell.
                e.Appearance.BackColor = Color.Gray;
                e.Appearance.ForeColor = Color.Orange;
                return;
            }

            MVCxPivotGrid pivot = ((MVCxPivotGridExporter)sender).PivotGrid as MVCxPivotGrid;
            int lastRowFieldIndex = pivot.Fields.GetVisibleFieldCount(PivotArea.RowArea) - 1;
            int lastColumnFieldIndex = pivot.Fields.GetVisibleFieldCount(PivotArea.ColumnArea) - 1;

            // Determine whether the cell is an ordinary cell.
            if (e.RowField.AreaIndex == lastRowFieldIndex && e.ColumnField.AreaIndex == lastColumnFieldIndex)
            {
                e.Appearance.ForeColor = Color.Gray;
            }
            // The cell is a Total cell.
            else
            {
                e.Appearance.BackColor = Color.DarkOliveGreen;
                e.Appearance.ForeColor = Color.White;
            }
        };

        settings.Fields.Add(field =>
        {
            field.Area = PivotArea.RowArea;
            field.FieldName = "CategoryName";
            field.Caption = "Category";
            field.AreaIndex = 0;
        });
        settings.Fields.Add(field =>
        {
            field.Area = PivotArea.ColumnArea;
            field.FieldName = "Country";
            field.Caption = "Country";
            field.AreaIndex = 0;
        });
        settings.Fields.Add(field =>
        {
            field.Area = PivotArea.DataArea;
            field.FieldName = "Extended Price";
            field.Caption = "Extended_Price";
            field.AreaIndex = 0;
        });
        settings.Fields.Add(field =>
        {
            field.Area = PivotArea.RowArea;
            field.FieldName = "ProductName";
            field.Caption = "Product Name";
            field.AreaIndex = 1;
        });
        settings.Fields.Add(field =>
        {
            field.Area = PivotArea.ColumnArea;
            field.FieldName = "Sales Person";
            field.Caption = "Sales Person";
            field.AreaIndex = 1;
        });

        return settings;
    }

    static PivotXlsxExportOptions GetXlsOptions()
    {
        PivotXlsxExportOptions options = new PivotXlsxExportOptions();
        options.CustomizeCell += Options_CustomizeCell;
        return options;
    }
    static void Options_CustomizeCell(CustomizePivotCellEventArgs e)
    {
        if (e.CellItemInfo != null)
        {
            switch (e.CellItemInfo.ColumnValueType)
            {
                case PivotGridValueType.GrandTotal:
                    // Specify the text to display in a cell.
                    e.Value = string.Format("=> {0}", e.Value.ToString());
                    // Specify the colors used to paint the cell.
                    e.Formatting.BackColor = Color.Gray;
                    e.Formatting.Font.Color = Color.Orange;
                    break;
                case PivotGridValueType.Total:
                    e.Formatting.BackColor = Color.DarkOliveGreen;
                    e.Formatting.Font.Color = Color.White;
                    break;
                case PivotGridValueType.Value:
                    e.Formatting.Font.Color = Color.Gray;
                    break;
            }
            e.Handled = true;
        }
    }
}