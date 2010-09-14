Public Class frmMain

    Private Sub btnDisplayAccountSummary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplayAccountSummary.Click

        Dim fmtStr As String = "{0, -10}{1, 10}{2, 15}{3, 15}{4, 15}{5, 15}"
        Dim readerVar As IO.StreamReader = IO.File.OpenText("..\..\data.txt")
        Dim strAccountNumber As String = readerVar.ReadLine
        Dim dblPastDueAmount As Double = CDbl(readerVar.ReadLine)
        Dim dblPayments As Double = CDbl(readerVar.ReadLine)
        Dim dblPurchases As Double = CDbl(readerVar.ReadLine)
        Dim dblFinanceCharges As Double = 0
        Dim dblCurrentAmtDue As Double = 0

        'Calculating amt due and finance cahrges
        dblFinanceCharges = (dblPastDueAmount - dblPayments) * 0.015
        dblCurrentAmtDue = (dblPastDueAmount - dblPayments) + dblFinanceCharges + dblPurchases

        'output set zones (make sure you use Courier New)
        'setting the headings
        lstAccountSummary.Items.Add(String.Format(fmtStr, "Account", "Past Due", "", "", "Finance", "Current"))
        lstAccountSummary.Items.Add(String.Format(fmtStr, "Number", "Amount", "Payments", "Purchases", "Charges", "Amt Due"))
        'printing out the first line of data
        lstAccountSummary.Items.Add(String.Format(fmtStr, strAccountNumber, FormatCurrency(dblPastDueAmount), FormatCurrency(dblPayments), FormatCurrency(dblPurchases), FormatCurrency(dblFinanceCharges), FormatCurrency(dblCurrentAmtDue)))

        'reading next line of data
        strAccountNumber = readerVar.ReadLine
        dblPastDueAmount = CDbl(readerVar.ReadLine)
        dblPayments = CDbl(readerVar.ReadLine)
        dblPurchases = CDbl(readerVar.ReadLine)

        ' recalculateing numbers
        dblFinanceCharges = 0
        dblFinanceCharges = (dblPastDueAmount - dblPayments) * 0.015
        dblCurrentAmtDue = (dblPastDueAmount - dblPayments) + dblFinanceCharges + dblPurchases

        ' printing out the second line of data
        lstAccountSummary.Items.Add(String.Format(fmtStr, strAccountNumber, FormatCurrency(dblPastDueAmount), FormatCurrency(dblPayments), FormatCurrency(dblPurchases), FormatCurrency(dblFinanceCharges), FormatCurrency(dblCurrentAmtDue)))

    End Sub
End Class
