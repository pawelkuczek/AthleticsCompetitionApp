# AthleticsCompetitionApp

Dla sprawdzającego

Cześć, jest to program do oceniania zawodników na zawodach lekkoatletycznych. Konkurencje są 3: bieg na 100m, skok w dal, pchnięcie kulą (na discordzie wymieniłem 5 konkurencji, ale uznałem, że lepiej będzie zawrzeć 3). W konsoli użytkownik będzie wpisywał wyniki ww. konkurencji dla poszczególnych zawodników biorących udział w zawodach. Program umożliwia zapis tabeli wyników do pliku, odczyt wyników z pliku oraz wyświetlenie tabeli wyników zawodów z pamięci.

Zacząłem od stworzenia interfejsu IAthlete, na podstawie którego stworzyłem klasę abstrakcyjną AthleteBase. Później stworzyłem klasę AthleteInMemory (służy do korzystania z programu, kiedy nie chcemy zapisywać wyników zawodów do pliku), która czerpie z AthleteBase. Po AthleteInMemory przyszedł czas na stworzenie klasy AthleteInFile(służy do zapisywania wyników zawodów do pliku), która dziedziczy po AthleteInMemory i ma dodatkowo swoje metody (SaveAthletesScoreboardToFile i ReadAthletesScoreboardFromFile), delegat AthleteResultsSavedToFileDelegate i event AthleteResultsSavedToFile. Stworzyłem też klasę pomocniczą Competition, która służy do wyłaniania zwycięzców poszczególnych konkurencji, sortowania zawodników w zalezności od zdobytych punktów oraz sprawdzania czy użytkownik dobrze wpisuje datę zawodów, itd.

W program.cs są zawarte 2 wersje programu: jedna do zapisywania wyników zawodów do pliku (ta zakomentowana na górze) oraz druga do odczytu wyników z pamięci.
W klasie competition próbowałem używać przeciążenia metod we wszystkich metodach do sprawdzania zwycięzców poszczególnych konkurencji oraz sortowania zawodników w zależności od punktów (Check100mRunWinner, CheckLongJumpWinner, CheckShotPutWinner, SortAthletesByScore), ale powodowało to stack overflow exception i nie udało mi się tego rozwiązać, więc zostawiłem kod w takiej postaci jak jest.
