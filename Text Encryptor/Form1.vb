Public Class Form1
    Dim DES As New System.Security.Cryptography.TripleDESCryptoServiceProvider
    Dim Hash As New System.Security.Cryptography.MD5CryptoServiceProvider

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            DES.Key = Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text))
            DES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESEncrypter As System.Security.Cryptography.ICryptoTransform = DES.CreateEncryptor
            Dim Buffer As Byte() = System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox2.Text)
            TextBox2.Text = Convert.ToBase64String(DESEncrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))

        Catch ex As Exception
            MessageBox.Show("The Following error(s) have occured: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            DES.Key = Hash.ComputeHash(System.Text.ASCIIEncoding.ASCII.GetBytes(TextBox1.Text))
            DES.Mode = Security.Cryptography.CipherMode.ECB
            Dim DESDecrypter As System.Security.Cryptography.ICryptoTransform = DES.CreateDecryptor
            Dim Buffer As Byte() = Convert.FromBase64String(TextBox2.Text)
            TextBox2.Text = System.Text.ASCIIEncoding.ASCII.GetString(DESDecrypter.TransformFinalBlock(Buffer, 0, Buffer.Length))
        Catch ex As Exception
            MessageBox.Show("The following error(s) have occured " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
