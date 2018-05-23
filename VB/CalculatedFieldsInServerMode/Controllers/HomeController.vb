Imports DevExpress.Web.Mvc
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace CalculatedFieldsInServerMode.Controllers
	Public Class HomeController
		Inherits Controller

		Public Function Index() As ActionResult
			Return View()
		End Function

		<ValidateInput(False)>
		Public Function GridViewPartial() As ActionResult
			Return PartialView("_GridViewPartial")
		End Function
	End Class
End Namespace