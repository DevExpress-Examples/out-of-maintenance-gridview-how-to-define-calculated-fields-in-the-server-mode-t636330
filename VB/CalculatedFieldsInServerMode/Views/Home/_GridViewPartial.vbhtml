@Imports CalculatedFieldsInServerMode.Models

@Code
        Dim grid = Html.DevExpress().GridView(Sub(settings)
		    settings.Name = "GridView"
		    settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "GridViewPartial"}
		    settings.KeyFieldName = "Id"
		    settings.SettingsPager.Visible = True
		    settings.Settings.ShowGroupPanel = True
		    settings.Settings.ShowFilterRow = True
		    settings.Settings.ShowHeaderFilterButton = True
		    settings.SettingsBehavior.AllowSelectByRowClick = True
		    settings.Columns.Add("Id")
		    settings.Columns.Add("ProductName")
		    settings.Columns.Add(Sub(col)
			    col.FieldName = "ProductionDate"
			    col.ColumnType = MVCxGridViewColumnType.DateEdit
			    col.SettingsHeaderFilter.Mode = GridHeaderFilterMode.DateRangePicker
		    End Sub)
		    settings.Columns.Add(Sub(col)
			    col.FieldName = "ProductPrice"
			    col.ColumnType = MVCxGridViewColumnType.SpinEdit
			    col.PropertiesEdit.DisplayFormatString = "c"
		    End Sub)
		    settings.Columns.Add("UnitsInStock")
		    settings.Columns.Add(Sub(col)
			    col.FieldName = "ProductExpiresDate"
			    col.ColumnType = MVCxGridViewColumnType.DateEdit
			    col.SettingsHeaderFilter.Mode = GridHeaderFilterMode.DateRangePicker
		    End Sub)
		    settings.Columns.Add("DaysUntilExpires")
		    settings.Columns.Add(Sub(col)
			    col.FieldName = "ProductStockSumProce"
			    col.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
			    col.PropertiesEdit.DisplayFormatString = "c"
			    col.UnboundExpression = "[ProductPrice] * [UnitsInStock]"
		    End Sub)
		    settings.FormatConditions.AddColorScale(Sub(condition)
			    condition.FieldName = "DaysUntilExpires"
			    condition.Format = GridConditionColorScaleFormat.GreenYellowRed
			    condition.MinimumValue = 0
			    condition.MaximumValue = 30
		    End Sub)
	    End Sub)
End Code
@grid.BindToEF("", "", Sub(s, e)
	    Dim db As New CalculatedFieldsTestEntities()
	    e.QueryableSource = db.CustomProducts(15, New Date(2018, 5, 15))
	    e.KeyExpression = "Id"
    End Sub).GetHtml()