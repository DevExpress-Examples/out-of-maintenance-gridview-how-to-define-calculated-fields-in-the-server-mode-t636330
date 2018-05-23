@Code
    ViewBag.Title = "Calculated Fields Example"
End Code

<h1>
    Calculated Fields In the Server Mode
</h1>

<blockquote>
    <p>
        In this example we demonstrate how you can implement calculated fields when the GridView extension <br />
        is bound to a Server Mode data source.
    </p>

    <p>
        On the side of the SQL server you need to use a Table-Value function and implement all calculated fields there. <br />
        See the <a href="https://docs.microsoft.com/en-us/dotnet/framework/data/adonet/sql/linq/how-to-use-table-valued-user-defined-functions">How to: Use Table-Valued User-Defined Functions</a> link to learn more about Table-Valued functions.
    </p>
    <div class="grid-container">
        @Html.Action("GridViewPartial")

    </div>
    <p>
        In the provided GridView extension only the following fields come from the [Products] table as-is: <i>[Id], [ProductName], [ProductionDate], [ProductPrice], [UnitsInStock]</i>. <br />
        Other fields are calculated in the following manner:
        <ul>
            <li style="margin-top: 0.5em;">
                <i>Product Expires Date</i>
    <p>
        This field is calculated on the SQL server side based on the value passed into the SQL function and the value in the <i>[ProductionDate]</i> field.
    </p>
    <code>
        DATEADD(day, @@daysExpiresOffset, ProductionDate) as ProductExpiresDate
    </code>
    </li>
    <li style="margin-top: 0.5em;">
        <i>Days Until Expires</i>
        <p>
            This field is calculated on the SQL server side based on the current date value passed into the SQL function and the value in the <i>[ProductExpiresDate]</i> field.
        </p>
        <code>
            DATEDIFF(day, @@currentDate, p.ProductExpiresDate) as DaysUntilExpires
        </code>
    </li>
    <li style="margin-top: 0.5em;">
        <i>Product Stock Sum Price</i>
        <p>
            This field is calculated using the built-in Criteria Language Syntax based on the values of the <i>[ProductPrice]</i> and <i>[UnitsInStock]</i> fields.<br />
            See the <a href="https://documentation.devexpress.com/CoreLibraries/4928/DevExpress-Data-Library/Criteria-Language-Syntax">Criteria Language Syntax</a> and <a href="https://documentation.devexpress.com/WindowsForms/6211/Common-Features/Expressions">Unbount Expressions</a> documentation articles to learn more about this approach.
        </p>
        <code>
            <pre>
settings.Columns.Add(col => {
    col.FieldName = "ProductStockSumProce";
    col.UnboundExpression = "[ProductPrice] * [UnitsInStock]";
    ...
});
                    </pre>
        </code>
    </li>
    </ul>
    </p>
</blockquote>
