Imports Microsoft.Win32
Imports System
Imports System.Linq

Namespace Unix_Spoofer
	Friend Class Program
		Shared Sub Main()
			Console.Title = "MONSTERMC Coding | Free HWID Spoofer | Discord: https://discord.gg/QgzvUVHhgF"

			Console.ForegroundColor = ConsoleColor.Cyan

			Console.Clear()

			Console.WriteLine(ControlChars.Lf & ControlChars.Lf & "                       █|  \/  |/ __ \| \ | |/ ____|__   __|  ____|  __ \|  \/  |/ ____|")
			Console.WriteLine("                        | \  / | |  | |  \| | (___    | |  | |__  | |__) | \  / | |     ")
			Console.WriteLine("                        | |\/| | |  | | . ` |\___ \   | |  |  __| |  _  /| |\/| | |     ")
			Console.WriteLine("                        | |  | | |__| | |\  |____) |  | |  | |____| | \ \| |  | | |____ ")
			Console.WriteLine("                        |_|  |_|\____/|_| \_|_____/   |_|  |______|_|  \_\_|  |_|\_____|")
			Console.WriteLine(ControlChars.Lf & "                      ===================================================================")
			Console.WriteLine("                            [1] Check HWID        [2] Spoof HWID         [3] About")
			Console.WriteLine("                      ===================================================================")
			Console.Write(ControlChars.Lf & ">")
			Dim [option] = Console.ReadLine()

			Select Case [option]
				Case "1"
					CheckHWID()

				Case "2"
					SpoofHWID()
				Case "3"
					ABOUT()
			End Select
			Console.ReadKey()
		End Sub

		Public Shared Sub CheckHWID()
			Try
				Console.Clear()

				Dim key As String = "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001"

				Dim guid As String = DirectCast(Registry.GetValue(key, "GUID", DirectCast("default", Object)), String)

				Console.WriteLine("[MONSTERMC] Current HWID: " & guid)

				Console.ReadKey()

				Main()
			Catch e1 As Exception
				Console.Clear()

				Console.ForegroundColor = ConsoleColor.Red

				Console.WriteLine("[MONSTERMC] There was an error while getting your HWID")

				Console.ReadKey()

				Main()
			End Try
		End Sub

		Public Shared Sub SpoofHWID()
			Try
				Console.Clear()

				Dim key As String = "HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\IDConfigDB\Hardware Profiles\0001"

				Dim oldHwid As String = DirectCast(Registry.GetValue(key, "HwProfileGuid", DirectCast("default", Object)), String)

				Dim newHwid As String = "{MONSTERMC-" & GenID(5) & "-" & GenID(5) & "-" & GenID(4) & "-" & GenID(9) & "}"

				Registry.SetValue(key, "GUID", DirectCast(newHwid, Object))

				Registry.SetValue(key, "HwProfileGuid", DirectCast(newHwid, Object))

				Console.WriteLine("[MONSTERMC] Successfully Changed Your HWID!")

				Console.WriteLine(ControlChars.Lf & "[MONSTERMC] Old HWID: " & oldHwid)

				Console.WriteLine(ControlChars.Lf & "[MONSTERMC] New HWID: " & newHwid)

				Console.ReadKey()

				Main()
			Catch e1 As Exception
				Console.Clear()

				Console.ForegroundColor = ConsoleColor.Red

				Console.WriteLine("[MONSTERMC] There was an error while changing your HWID, Try running this tool as an administrator.")

				Console.ReadKey()

				Main()
			End Try
		End Sub
		Public Shared Sub ABOUT()
			Process.Start("https://www.youtube.com/channel/UC358xXdJR-UY1sMtuTVQW8w")
			Process.Start("https://t.me/MONSTERMCSY")
			Process.Start("https://discord.gg/QgzvUVHhgF")
			Process.Start("https://www.facebook.com/developers.syriaa")
		End Sub
		Private Shared random As New Random()

		Public Shared Function GenID(ByVal length As Integer) As String
			Dim chars As String = "123456789"
			Return New String(Enumerable.Repeat(chars, length).Select(Function(s) s(random.Next(s.Length))).ToArray())
		End Function
	End Class
End Namespace
