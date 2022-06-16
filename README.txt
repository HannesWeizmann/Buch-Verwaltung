Die MariaDB wurde über Docker realisiert. Um die Tabellen auf der Datenbank zu erstellen,
muss der SQL-Executor ausgeführt werden. Der Connectionstring muss nicht 
angepasst werden.
Danach kann die BuchWPF-Anwendung ausgeführt werden.

Sonstige Anmerkungen:
Verschieben-Funktion funktioniert nicht vollständig. Es wird bis nur das Objekt gelöscht.
Danach sollte es in die jeweils andere Tabelle eingefügt werden, was allerdings nicht passiert. Funktionen dafür wurden implementiert,
sie erfüllen aber nicht ihren Zweck. Die Aktualisierung der Tabellen sollte funktionieren.

Githublink: https://github.com/HannesWeizmann/Buch-Verwaltung.git
