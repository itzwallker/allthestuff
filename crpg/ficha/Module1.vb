﻿Imports System
Imports System.Object
Imports System.MarshalByRefObject
Imports System.Globalization
Imports System.IO
Imports System.Xml
Imports System.Drawing
Imports System.Collections
Imports System.Windows.Forms
Imports System.ComponentModel


Module Module1

    Dim index As Integer
    Public idling As Integer
    Dim p As New clsPerson()
    Dim x As New Xml.Serialization.XmlSerializer(p.GetType)

    Function FileExists(FilePath As String) As Boolean
        Dim TestStr As String
        TestStr = ""
        On Error Resume Next
        TestStr = Dir(FilePath)
        On Error GoTo 0
        If TestStr = "" Then
            FileExists = False
        Else
            FileExists = True
        End If
    End Function

    Function Save()
        Dim sw As StreamWriter = New StreamWriter("saves\crpg1.dat")
        x.Serialize(sw, p)
        sw.Close()
        Console.ForegroundColor = ConsoleColor.Green
        Console.WriteLine("d o n e !")
        System.Threading.Thread.Sleep(500)
        Console.Clear()
    End Function

    '=====================================================================================================
    Sub Main()

        If FileExists("saves\crpg1.dat") = False Then

            System.IO.Directory.CreateDirectory("saves\")

            Dim rand As Random = New Random

            'name=========================================================================================
            Console.WriteLine(vbCrLf + "your name?")
            p.name = Console.ReadLine
            Console.Clear()

            'idade========================================================================================
            Console.WriteLine(vbCrLf + "your age?")
            p.idade = Console.ReadLine
            Console.Clear()

            'city=========================================================================================
            Console.WriteLine(vbCrLf + "city?")
            p.city = Console.ReadLine
            Console.Clear()

            'level========================================================================================
            p.level = 1
            Console.Clear()

            'faith========================================================================================
            p.faith = rand.Next(5, 16)
            Console.Clear()

            'forca========================================================================================
            p.forca = rand.Next(5, 16)
            Console.Clear()

            'cons=========================================================================================
            p.con = rand.Next(5, 16)
            Console.Clear()

            'des==========================================================================================
            p.des = rand.Next(5, 16)
            Console.Clear()

            'agi==========================================================================================
            p.agi = rand.Next(5, 16)
            Console.Clear()

            'int==========================================================================================
            p.int = rand.Next(5, 16)
            Console.Clear()

            'will=========================================================================================
            p.will = rand.Next(5, 16)
            Console.Clear()

            'per==========================================================================================
            p.per = rand.Next(5, 16)
            Console.Clear()

            'car==========================================================================================
            p.car = rand.Next(5, 16)
            Console.Clear()

            'save=========================================================================================
            p.hpt = ((p.forca * 100) + (p.con * 100)) * p.level
            p.dano = ((p.con + p.forca) * p.level)
            p.hpa = p.hpt
            p.xpa = 0
            p.cash = 0
            p.xpt = p.level * 100
            x.Serialize(Console.Out, p)
            Console.Write(vbCrLf + "press any key to continue... ")
            Console.ReadKey(True)
            Save()
            index = 1
            Console.Clear()

        Else

            'import=======================================================================================
            Using sr As New StreamReader("saves\crpg1.dat")
                p = x.Deserialize(sr)
            End Using
            index = 1
            idling = 0
            Console.Clear()

        End If

        While index = 1

            Dim hpb As String
            Dim xpb As String


            Console.Clear()
            Console.SetWindowSize(90, 14)

            Console.BufferHeight = 14
            Console.BufferWidth = 90


            Dim prc() As Process = System.Diagnostics.Process.GetProcessesByName("crpgform")
            Try
                For Each p As Process In prc
                    p.Kill()
                Next
            Catch ex As Exception

            End Try


            Console.Title = "c o n s o l e   r p g   i d l e r"

            Console.ForegroundColor = ConsoleColor.White
            Console.BackgroundColor = ConsoleColor.Blue
            Console.SetCursorPosition(0, 0)
            Console.WriteLine($"welcome, {p.name} - [ level: {p.level} ]  |  [ ano: 7 0 7 7]                                              ")

            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.Green
            Console.SetCursorPosition(0, 1)
            Console.WriteLine("|===========[pts]=================|===================[hab]=============================|")

            Console.SetCursorPosition(34, 2)
            Console.WriteLine("|")
            Console.SetCursorPosition(34, 3)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 4)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 5)
            Console.WriteLine("|==================================")
            Console.SetCursorPosition(34, 4)
            Console.WriteLine("|")
            Console.SetCursorPosition(34, 5)
            Console.WriteLine("|=====================================================|")
            Console.SetCursorPosition(88, 2)
            Console.WriteLine("|")
            Console.SetCursorPosition(88, 3)
            Console.WriteLine("|")
            Console.SetCursorPosition(88, 4)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 2)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 3)
            Console.WriteLine("|")
            Console.SetCursorPosition(0, 4)
            Console.WriteLine("|")


            Console.SetCursorPosition(2, 2)
            Console.WriteLine($"hp:    {p.hpa}")

            Console.SetCursorPosition(2, 3)
            Console.WriteLine($"level: {p.level}")

            Console.SetCursorPosition(19, 4)
            Console.WriteLine($"inici: {p.agi}[{p.agi * 4}%]")

            Console.SetCursorPosition(2, 4)
            Console.WriteLine($"idade: {p.idade}")

            Console.SetCursorPosition(19, 2)
            Console.WriteLine($"faith: {p.faith} ")

            Console.SetCursorPosition(19, 3)
            Console.WriteLine($"city:  {p.city}")

            Console.SetCursorPosition(38, 2)
            Console.WriteLine($"for: {p.forca}[{p.forca * 4}%]")

            Console.SetCursorPosition(69, 2)
            Console.WriteLine($"agi:  {p.agi}[{p.agi * 4}%]")

            Console.SetCursorPosition(53, 2)
            Console.WriteLine($"per:  {p.per}[{p.per * 4}%]")

            Console.SetCursorPosition(38, 3)
            Console.WriteLine($"con: {p.con}[{p.con * 4}%]")

            Console.SetCursorPosition(69, 3)
            Console.WriteLine($"int:  {p.int}[{p.int * 4}%]")

            Console.ForegroundColor = ConsoleColor.Gray
            Console.SetCursorPosition(69, 4)
            Console.WriteLine($"pontos:  {(5 * p.idade) + (5 * p.int)}")

            Console.ForegroundColor = ConsoleColor.Green
            Console.SetCursorPosition(53, 3)
            Console.WriteLine($"car:  {p.car}[{p.car * 4}%]")

            Console.SetCursorPosition(38, 4)
            Console.WriteLine($"des: {p.des}[{p.des * 4}%]")

            Console.SetCursorPosition(53, 4)
            Console.WriteLine($"will: {p.will}[{p.will * 4}%]")

            If ((p.hpa / p.hpt) > (0.85)) Then
                hpb = "==================================================================================="

            ElseIf ((p.hpa / p.hpt) <= (0.85)) Then
                If ((p.hpa / p.hpt) <= (0.5)) Then
                    If ((p.hpa / p.hpt) <= (0.25)) Then
                        hpb = "=================------------------------------------------------------------------"
                    Else
                        hpb = "======================================---------------------------------------------"
                    End If
                Else
                    hpb = "=============================================================----------------------"
                End If
            End If

            If ((p.xpa / p.xpt) > (0.85)) Then
                xpb = "==================================================================================="

            ElseIf ((p.xpa / p.xpt) <= (0.85)) Then
                If ((p.xpa / p.xpt) <= (0.5)) Then
                    If ((p.xpa / p.xpt) <= (0.25)) Then
                        xpb = "=================------------------------------------------------------------------"
                    Else
                        xpb = "======================================---------------------------------------------"
                    End If
                Else
                    xpb = "=============================================================----------------------"
                End If
            End If

            Console.SetCursorPosition(0, 7)
            Console.ForegroundColor = ConsoleColor.Red
            Console.WriteLine($"hp: [{hpb}]")

            Console.SetCursorPosition(0, 8)
            Console.ForegroundColor = ConsoleColor.Cyan
            Console.WriteLine($"xp: [{xpb}]")

            Console.SetCursorPosition(0, 10)
            Console.ForegroundColor = ConsoleColor.White
            Console.WriteLine("-----------------------------------------------------------------------------------------")
            Console.BackgroundColor = ConsoleColor.Blue
            Console.WriteLine("====================== commands: edit %% | start | view %% | quit =======================")
            Console.BackgroundColor = ConsoleColor.Black
            Console.WriteLine("-----------------------------------------------------------------------------------------")
            Console.ForegroundColor = ConsoleColor.Yellow

            Dim execute = Console.ReadLine()



            If execute = "edit name" Then
                Console.Clear()
                Console.WriteLine(vbCrLf + $"new name? old[{p.name}]")
                Dim charname As String = Console.ReadLine
                p.name = charname
                Save()

            ElseIf execute = "reset" Then
                Console.Clear()
                Console.WriteLine(vbCrLf + $"u sure nigga?(yes/no)")
                Dim resp = Console.ReadLine()
                If resp = "yes" Then
                    Console.Clear()
                    Console.WriteLine(vbCrLf + $"damnn bro, ok.. wiping dat shit")
                    Dim txtList As String() = Directory.GetFiles("saves\", "*.*")
                    For Each f As String In txtList
                        File.Delete(f)
                    Next
                    System.Threading.Thread.Sleep(1000)
                Else End If

            ElseIf execute = "start" Then
                Console.Clear()
                idling = 1
                Dim r As Random = New Random
                Dim processinfo = "crpgform.exe"
                Process.Start(ProcessInfo)
                Console.SetCursorPosition(0, 10)
                Console.WriteLine("idling started, starting battles..")
                Do

                    p.mhpt = r.Next(p.hpt, p.hpt * 10)
                    p.mhpa = p.mhpt

                    Do
                        p.danototal = p.dano + r.Next(1, 101)
                        p.mdmg = r.Next(p.danototal - 30, p.danototal + 80)
                        p.heal = r.Next(p.mdmg - 20, p.mdmg + 70)
                        Dim rbonus = r.Next(1, 25)
                        Dim rbonus2 = r.Next(6, 10)

                        p.mhpa -= p.danototal
                        p.hpa -= p.mdmg
                        p.xpa += r.Next(1, 20)

                        If rbonus = rbonus2 Then
                            Dim bonus = r.Next(0, 5)
                            If bonus = 1 Then
                                Dim xpbonus = r.Next(600, 5000)
                                p.xpa += xpbonus
                                Console.ForegroundColor = ConsoleColor.Magenta
                                Console.WriteLine($"you gained a xp bonus: [ {xpbonus} ]")
                                Console.WriteLine()
                                System.Threading.Thread.Sleep(500)
                            End If
                            If bonus = 2 Then
                                Dim cashbonus = r.Next(50, 500)
                                p.cash += cashbonus
                                Console.ForegroundColor = ConsoleColor.Magenta
                                Console.WriteLine($"you gained a cash bonus: [ {cashbonus} ]")
                                Console.WriteLine()
                                System.Threading.Thread.Sleep(500)
                            End If
                            If bonus = 3 Then
                                Dim hpbonus = r.Next(300, 1000)
                                p.hpt += hpbonus
                                Console.ForegroundColor = ConsoleColor.Magenta
                                Console.WriteLine($"you gained an hp bonus: [ {hpbonus} ]")
                                Console.WriteLine()
                                System.Threading.Thread.Sleep(500)
                            End If
                            If bonus = 4 Then
                                Dim dmgbonus = r.Next(40, 90)
                                p.dano += dmgbonus
                                Console.ForegroundColor = ConsoleColor.Magenta
                                Console.WriteLine($"you gained a damage bonus: [ {dmgbonus} ]")
                                Console.WriteLine()
                                System.Threading.Thread.Sleep(500)
                            End If
                        End If

                        If (p.hpa < p.hpt) Then
                            p.hpa += p.heal
                        End If

                        If (p.hpa > p.hpt) Then
                            p.hpa = p.hpt
                        End If

                        If (p.xpa > p.xpt) Then
                            p.level += 1
                            p.xpt = p.xpt * 2
                            p.dano += r.Next(80, 221)
                            p.hpt += r.Next(400, 1000)
                            Console.ForegroundColor = ConsoleColor.Magenta
                            Console.WriteLine($"c o n g r a t s ! !   you reached a new level [ {p.level} ]")
                            Console.WriteLine()
                            System.Threading.Thread.Sleep(1000)
                        End If

                        Console.ForegroundColor = ConsoleColor.Red
                        Console.WriteLine($"mob hp :  [{p.mhpa} / {p.mhpt}]")
                        Console.WriteLine($"you took [ {p.mdmg} ] damage from [ 1 ] mob")

                        Console.ForegroundColor = ConsoleColor.DarkGreen
                        Console.Write($"hp: [{p.hpa} / {p.hpt}]")

                        Console.ForegroundColor = ConsoleColor.Cyan
                        Console.Write($"  xp: [{p.xpa} / {p.xpt}]")

                        Console.ForegroundColor = ConsoleColor.Gray
                        Console.Write($"  level: [{p.level}]")

                        Console.ForegroundColor = ConsoleColor.Green
                        Console.WriteLine()
                        Console.WriteLine($"you did [ {p.danototal} ] damage to [ 1 ] mob")
                        Console.WriteLine($"you got healed by [ {p.heal} ] hp")
                        Console.WriteLine()

                        Try
                            Dim sw As StreamWriter = New StreamWriter("saves\crpg1.dat")
                            x.Serialize(sw, p)
                            sw.Close()
                        Catch ex As Exception
                            System.Threading.Thread.Sleep(500)
                            Dim sw As StreamWriter = New StreamWriter("saves\crpg1.dat")
                            x.Serialize(sw, p)
                            sw.Close()
                        End Try


                        Console.WriteLine()

                        If Console.KeyAvailable Then
                            If Console.ReadKey(True).KeyChar = "q"c Then idling = 0
                        End If

                        System.Threading.Thread.Sleep(700)

                    Loop Until idling = 0 Or p.mhpa <= 0

                    If idling = 0 Then
                        Console.ForegroundColor = ConsoleColor.Magenta
                        Console.WriteLine($"API stopped..")
                        'For Each p As Process In prc
                        'p.Kill()
                        'Next
                        System.Threading.Thread.Sleep(1000)
                    Else
                        Console.WriteLine($"c o n g r a t s ! !   you killed [ 1 ] enemy - Reward: [{p.mhpt / 10}] xp")
                        Console.WriteLine()
                        System.Threading.Thread.Sleep(1000)
                        p.xpa += p.mhpt / 10
                    End If

                Loop Until idling = 0



            ElseIf execute = "edit city" Then
                Console.Clear()
                Console.WriteLine(vbCrLf + $"new city? old[{p.city}]")
                Dim charcity As String = Console.ReadLine
                p.city = charcity
                Save()


            ElseIf execute = "edit age" Then
                Console.Clear()
                Console.WriteLine(vbCrLf + $"new age? old[{p.idade}]")
                Dim charidade As String = Console.ReadLine
                p.idade = charidade
                Save()


            ElseIf execute = "quit" Then
                Dim sw As StreamWriter = New StreamWriter("saves\crpg1.dat")
                x.Serialize(sw, p)
                index = 0

            Else

                Console.Clear()

            End If

            ' If index is 0, exit the loop.
            If Index = 0 Then
                Exit Sub
            End If
        End While

    End Sub

End Module
