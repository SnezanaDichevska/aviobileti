﻿ЗА ПРОБЛЕМОТ СО <<HEAD избришете го од проектот obj фолдерот!!! 

1.Табелата за типКласа не е искористена може да се избрише нека седи сеа за сеа.
2.За да неаме по 100 конекции за секоја стиница тие типовите на багаж,пријавување,итн не користам полнење од база
  за контролите него рачно ги додадов
3.Во MakeAreservation и Showeservation контролите се генрерираат динамички. Додавав празни cells да бидат демек секаде по 3 in a row
  мислев само црн бордер да ставам ама нешто изгледот не ми успевање и нз зашто collspan ,cellspacing ,width,height не ги гледа
  исто и кај гридовите стаив collspan,rowspan, cellspacing не ги гледа =/
4.ИЗгледот несакајќи го изместив во SearchFlights и не знаев баш да го наместам





Поврзување со база ако на прв обид не работи:

0)избриши ја базата од експлорер
1) од фолдерот со базата го бришете aviobileti_log.LDF 
2) додавате постоечка база во ServerExplorer и линкот го водите до нашата база 3) Менувате таму за автентикација преку User во ваш усер и после у web.cofig , conncetionString у АПП го менувате тој дел , да не стои WINDOWS-PC (јас)
