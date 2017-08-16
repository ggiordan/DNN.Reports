Imports System.Collections.Generic
Imports System.IO
Imports System.Web.UI

Imports DotNetNuke
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.UI.Utilities
Imports DotNetNuke.Modules.Reports.Extensions



Namespace DotNetNuke.Modules.Reports.Visualizers.Excel


    Partial Class Settings
        Inherits ReportsSettingsBase

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If Not ReportsClientAPI.IsSupported Then
                chkPageData.AutoPostBack = True
                AddHandler chkPageData.CheckedChanged, AddressOf chkPageData_CheckedChanged
            Else
                ReportsClientAPI.Import(Me.Page)
                ReportsClientAPI.ShowHideByCheckBox(Me.Page, chkPageData, rowPageSize)
            End If
        End Sub

        Public Overrides Sub LoadSettings(ByVal VisualizerSettings As Dictionary(Of String, String))
            chkPageData.Checked = SettingsUtil.GetDictionarySetting(Of Boolean)(VisualizerSettings, ReportsController.SETTING_Grid_EnablePaging, False)
            chkSortData.Checked = SettingsUtil.GetDictionarySetting(Of Boolean)(VisualizerSettings, ReportsController.SETTING_Grid_EnableSorting, False)
            txtPageSize.Text = SettingsUtil.GetDictionarySetting(Of String)(VisualizerSettings, ReportsController.SETTING_Grid_PageSize, "10")
            chkShowHeader.Checked = SettingsUtil.GetDictionarySetting(Of Boolean)(VisualizerSettings, ReportsController.SETTING_Grid_ShowHeader, True)
            txtAdditionalCSS.Text = SettingsUtil.GetDictionarySetting(Of String)(VisualizerSettings, ReportsController.SETTING_Grid_AdditionalCSS, "")
            txtCSSClass.Text = SettingsUtil.GetDictionarySetting(Of String)(VisualizerSettings, ReportsController.SETTING_Grid_CSSClass, "")
            Dim gridLines As String = Utilities.GetGridLinesSetting(VisualizerSettings).ToString()
            DropDownUtils.TrySetValue(ddlGridLines,
                                      SettingsUtil.GetDictionarySetting(Of String)(
                                          VisualizerSettings,
                                          ReportsController.SETTING_Grid_GridLines,
                                          ReportsController.DEFAULT_Grid_GridLines),
                                      ReportsController.DEFAULT_Grid_GridLines)
            UpdatePageSizeText()
        End Sub

        Public Overrides Sub SaveSettings(ByVal VisualizerSettings As Dictionary(Of String, String))
            If Not typvalPageSize.IsValid Then
                txtPageSize.Text = "10"
            End If

            VisualizerSettings(ReportsController.SETTING_Grid_EnablePaging) = chkPageData.Checked.ToString()
            VisualizerSettings(ReportsController.SETTING_Grid_EnableSorting) = chkSortData.Checked.ToString()
            VisualizerSettings(ReportsController.SETTING_Grid_PageSize) = txtPageSize.Text
            VisualizerSettings(ReportsController.SETTING_Grid_ShowHeader) = chkShowHeader.Checked.ToString()
            VisualizerSettings(ReportsController.SETTING_Grid_GridLines) = ddlGridLines.SelectedValue()
            VisualizerSettings(ReportsController.SETTING_Grid_AdditionalCSS) = txtAdditionalCSS.Text
            VisualizerSettings(ReportsController.SETTING_Grid_CSSClass) = txtCSSClass.Text
        End Sub

        Private Sub UpdatePageSizeText()
            If chkPageData.Checked Then
                rowPageSize.Style(HtmlTextWriterStyle.Display) = String.Empty
            Else
                rowPageSize.Style(HtmlTextWriterStyle.Display) = "none"
            End If
        End Sub

        Private Sub chkPageData_CheckedChanged(ByVal sender As Object, ByVal args As EventArgs)
            UpdatePageSizeText()
        End Sub

    End Class

End Namespace