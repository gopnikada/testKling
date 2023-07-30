## Kling Automaten Training Quest
### Ben�tigte Tools
- Visual Studio 2019 oder neuer
- DotNet Core 7

### Rahmen
- Google, ChatGpt, StackOverflow ist alles erlaubt
- Nachfragen an die Kollegen sind erlaubt
- Benötigte Softwareinstallationen können jederzeit bei den Kollegen von der IT erfragt werden
- 4 Stunden Zeit f�r die Aufgabe
- Bewertet wird der Fortschritt und der Coding-Stil und Effizienz des Codes
  - Nicht abschliessen ist kein Show-Stopper
- Das Projekt Compiliert ohne �nderungen
- Die Daten f�r das Projekt liegen im Ordner `StaticData` im Backend und werden automatisch beim Build ins Ergebnisverzeichnis kopiert

### Aufgabe
- Im Beispiel wollen wir die Daten von "n" Dateien in einer Tablle zusammenf�hren und diese in einer Blazor Webanwendung darstellen.
  - Alle Dateien m�ssen ber�cksichtigt werden
  - Die Kommunikation Frontend-Backend muss - REST-Konform stattfinden
  - Die Wahl der Nachrichten-Formatierung ist frei (JSON, XML, etc.)
  - Einstiegspunkt im Backend ist der Controller `DbfController`
- Folgende Punkte stehen der freien Kreativit�t offen:
  - Welche Teile der Aufgabe im Backend und welche im Frontend gel�st werden
  - Wie die Oberfl�che detailliert grafisch aussieht (notwendig ist nur eine tabellenartige struktur).

### Hinweise
Als Startprofil für die zwei Anwendungen in der Solution werden folgende Einstellungen empfohlen:
- Server: `Swagger`
- Client: `IISExpress`

### Beispiel Output

|   |  DATEINAME #1  |  DATEINAME #2  |  DATEINAME #3  |
|---|-------------|-------------|-------------|
|TIMESTAMP| VALUE | VALUE | VALUE |
|TIMESTAMP| VALUE | VALUE | VALUE |
|TIMESTAMP| VALUE | VALUE | VALUE |
